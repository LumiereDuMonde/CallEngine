using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CallEngine.DAL;
using CallEngine.Models;
using Twilio;
using Twilio.AspNet.Common;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML;

namespace CallEngine.Core
{
	public class OperatorActionResponse : IActionResponse
	{
		private readonly ICallRepository _repo;

		public OperatorActionResponse(ICallRepository repo)
		{
			_repo = repo;
		}
		public async Task<VoiceResponse> GetResponse(VoiceRequest incomingCall, BaseActionModel action, VoiceResponse voiceResponse, IDictionary<string, string> values = null)
		{
			var opAction = (OperatorAction)action;
			var response = new VoiceResponse();
			var callerId = incomingCall.To;
			var sourceSid = incomingCall.CallSid;
			string opNumber = "";
			if (action?.OperatorId != null)
			{
				// single call
				var op = await _repo.GetOperator((int)action?.OperatorId);
				opNumber = op.Number;
			}
			response.Enqueue(incomingCall.CallSid, waitUrl: new Uri("/operator/PlayWaitMusic", UriKind.Relative), action: new Uri("/operator/DequeueSource", UriKind.Relative));

			TwilioClient.Init(Globals.ACCOUNT_SID, Globals.AUTH_TOKEN);

			var call = await CallResource.CreateAsync(
				url: new Uri(Globals.BASE_URL + "/operator/destpickup?SourceSid=" + sourceSid),
				to: new Twilio.Types.PhoneNumber(opNumber),
				from: new Twilio.Types.PhoneNumber(callerId),
				statusCallback: new Uri(Globals.BASE_URL + "/operator/deststatus")
			);
			var opCallSid = call.Sid;

			var outboundCall = new OutboundCall()
			{
				EngagementId = opAction.Engagement.Id,
				Sid = opCallSid,
				SourceSid = sourceSid,
				UserId = opAction.Engagement.UserId,
				CallStatus = CallStatusType.ringing
			};
			_repo.Add(outboundCall);
			await _repo.SaveAll();
			
			return response;
		}

		public async Task GetNextCall()
		{

		}

		public async Task<VoiceResponse> FailedCallAction(VoiceRequest outgoingCall, BaseActionModel action, VoiceResponse voiceResponse, IDictionary<string, string> values = null)
		{
			// QueueBackgroundWorkItem  or HangFire for delaying next call?
			var opAction = (OperatorAction)action;
			var response = new VoiceResponse();
			return response;
		}
	}
}
