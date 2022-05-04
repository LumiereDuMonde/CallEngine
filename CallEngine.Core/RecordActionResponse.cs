using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CallEngine.Models;
using Twilio.AspNet.Common;
using Twilio.TwiML;
using Twilio.TwiML.Voice;

namespace CallEngine.Core
{
	public class RecordActionResponse : IActionResponse
	{
		public async Task<VoiceResponse> GetResponse(VoiceRequest incomingCall, BaseActionModel action, VoiceResponse voiceResponse, IDictionary<string, string> values = null)
		{
			var recordAction = (RecordFileAction)action;
			var record = new Record()
			{
				Timeout = recordAction.Timeout,
				FinishOnKey = recordAction.TerminationKey,
				MaxLength = recordAction.MailBox.MaxLength,
				PlayBeep = recordAction.MailBox.PlayBeep,
				RecordingStatusCallback = new Uri("/voice/RecordDone?mailBoxId=" + recordAction.MailBox.Id, UriKind.Relative)
			};
			var recordPlay = new Play(new Uri(recordAction.MailBox.SoundFile.Uri));
			voiceResponse.Append(recordPlay).Append(record);
			return voiceResponse;
		}
	}
}
