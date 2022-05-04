using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CallEngine.Models;
using Twilio.AspNet.Common;
using Twilio.TwiML;

namespace CallEngine.Core
{
	public class PlayActionResponse : IActionResponse
	{
		public async Task<VoiceResponse> GetResponse(VoiceRequest incomingCall, BaseActionModel playAction, VoiceResponse voiceResponse, IDictionary<string, string> values = null)
		{
			var action = (PlayFileAction)playAction;
			var gather = new Twilio.TwiML.Voice.Gather();
			gather.Action = new Uri("/voice/EndPlay?id=" + action?.Id, UriKind.Relative);			
			gather.NumDigits = action.NumberOfDigits;
			gather.Timeout = action.Timeout;
			gather.FinishOnKey = action.TerminationKey;
			if (action?.SoundFile?.isTTS ?? false)
			{
				var say = new Twilio.TwiML.Voice.Say(action.SoundFile.TTS, loop: 1);
				gather.Append(say);
			}
			else
			{
				var play = new Twilio.TwiML.Voice.Play(new Uri(action.SoundFile.Uri), loop: 1);
				gather.Append(play);
			}

			var newGather = voiceResponse.Append(gather);

			return newGather;
		}


	}
}
