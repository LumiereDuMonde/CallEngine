using CallEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Twilio.AspNet.Common;
using Twilio.TwiML;

namespace CallEngine.Core
{
	public interface IEngagementService
	{
		BaseActionModel GetInitial(Engagement e, VoiceRequest incomingCall, IDictionary<string, string> values = null);
		BaseActionModel GetNext(Engagement e, VoiceRequest incomingCall, IDictionary<string, string> values = null);
		Task<VoiceResponse> AnswerIncomingCall(VoiceRequest incomingCall);
		Task<VoiceResponse> EndPlay(VoiceRequest incomingCall, IDictionary<string, string> values = null);
		Task<VoiceResponse> EndRecord(RecordStatusCallbackRequest incomingCall, IDictionary<string, string> values = null);
		Task<VoiceResponse> UpdateStatus(StatusCallbackRequest incomingCall);
	}
}
