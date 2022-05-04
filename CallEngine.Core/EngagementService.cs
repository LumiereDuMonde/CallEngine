using CallEngine.DAL;
using CallEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.AspNet.Common;
using Twilio.TwiML;


namespace CallEngine.Core
{
	public class EngagementService : IEngagementService
	{
		private readonly ICallRepository _repo;
		private readonly IActionResponse _playActionResponse;
		private readonly IActionResponse _recordActionResponse;
		private readonly IActionResponse _operatorResponse;

		public EngagementService(ICallRepository repo, PlayActionResponse playActionResponse, RecordActionResponse recordActionResponse, OperatorActionResponse operatorActionResponse)
		{
			_repo = repo;
			_playActionResponse = playActionResponse;
			_recordActionResponse = recordActionResponse;
			_operatorResponse = operatorActionResponse;
		}

		private async Task<VoiceResponse> GetResponse(VoiceResponse voiceResponse, BaseActionModel action, VoiceRequest incomingCall, IDictionary<string, string> values = null)
		{
			switch(action.Type)
			{
				case CallActionType.Operator:
					return await _operatorResponse.GetResponse(incomingCall, action, voiceResponse, values);
				
				case CallActionType.Record:
					return await _recordActionResponse.GetResponse(incomingCall, action, voiceResponse, values);					
				case CallActionType.PlayFile:
				case CallActionType.PlayTTS:
					return await _playActionResponse.GetResponse(incomingCall, action, voiceResponse, values);
				default:
					return voiceResponse.Hangup();
			}
		}

		public async Task<VoiceResponse> AnswerIncomingCall(VoiceRequest incomingCall)
		{
			var voiceResponse = new VoiceResponse();
			Engagement e = null;
			if (incomingCall?.CallStatus == "ringing")
			{
				e = await _repo.GetEngagement(incomingCall.To, incomingCall.From);
				var ic = new IncomingCall
				{
					DNIS = incomingCall.To,
					ANI = incomingCall.From,
					CallStatus = CallStatusType.inprogress,
					CallSid = incomingCall.CallSid,
					UserId = e.UserId,
					Duration = 0,
					EngagementId = e.Id
				};
				_repo.Add(ic);
				await _repo.SaveAll();
			}

			if (e == null) return voiceResponse.Reject();

			var action = GetInitial(e, incomingCall);

			if (action == null) return voiceResponse.Reject();

			voiceResponse = await GetResponse(voiceResponse, action, incomingCall);

			return voiceResponse;
		}

		public BaseActionModel GetInitial(Engagement e, VoiceRequest incomingCall, IDictionary<string, string> values = null)
		{
			return e.Actions?.FirstOrDefault(x => x.Initial);
		}

		public BaseActionModel GetNext(Engagement e, VoiceRequest incomingCall, IDictionary<string, string> values = null)
		{
			// TODO: log digits
			var digits = incomingCall.Digits;
			var id = 0;
			Int32.TryParse(values?["id"], out id);
			var lastAction = e.Actions?.FirstOrDefault(x => x.Id == id);
			return lastAction?.Digits?.FirstOrDefault(x => x.Key == digits)?.NextAction;
		}

		public async Task<VoiceResponse> EndPlay(VoiceRequest incomingCall, IDictionary<string, string> values = null)
		{
			var voiceResponse = new VoiceResponse();
			var e = await _repo.GetEngagementFromSid(incomingCall.CallSid);
			if (e == null) return voiceResponse.Hangup();
			var action = GetNext(e, incomingCall, values);
			if (action == null) return voiceResponse.Hangup();
			voiceResponse = await GetResponse(voiceResponse, action, incomingCall, values);

			return voiceResponse;
		}

		public async Task<VoiceResponse> EndRecord(RecordStatusCallbackRequest incomingCall, IDictionary<string, string> values = null)
		{
			int mailBoxId = 0;
			Int32.TryParse(values?["mailBoxId"], out mailBoxId);
			if (incomingCall.RecordingStatus == "completed" && mailBoxId != 0)
			{
				var mb = await _repo.GetMailbox((int)mailBoxId);
				int result;
				var message = new Voicemail
				{
					MailboxId = mb.Id,
					Duration = int.TryParse(incomingCall.RecordingDuration, out result) ? result : 0,
					UserId = mb.UserId,
					RemoteUrl = incomingCall.RecordingUrl,
					Sid = incomingCall.RecordingSid,
					ANI = incomingCall.From
				};
				_repo.Add(message);
				if (!await _repo.SaveAll())
				{
					throw new UnauthorizedAccessException("Unable to save recording in record done");
				}
			}
			return new VoiceResponse();
		}

		public async Task<VoiceResponse> UpdateStatus(StatusCallbackRequest incomingCall)
		{
			if (incomingCall.CallStatus == "completed")
			{
				var ic = await _repo.GetIncomingCall(incomingCall.CallSid);
				if (ic != null)
				{
					ic.CallStatus = CallStatusType.completed;
					ic.Duration = (int)incomingCall.CallDuration;
					await _repo.SaveAll();
				}
			}
			return new VoiceResponse();
		}
	}
}
