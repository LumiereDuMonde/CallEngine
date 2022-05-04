using CallEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Twilio.AspNet.Common;
using Twilio.TwiML;

namespace CallEngine.Core
{
	public interface IActionResponse
	{
		Task<VoiceResponse> GetResponse(VoiceRequest incomingCall, BaseActionModel action, VoiceResponse voiceResponse, IDictionary<string, string> values = null);		
	}
}
