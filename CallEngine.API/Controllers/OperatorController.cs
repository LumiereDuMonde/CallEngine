using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Twilio;
using Twilio.AspNet.Common;
using Twilio.AspNet.Core;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML;
using Twilio.TwiML.Voice;
using CallEngine.API.ActionFilter;

namespace CallEngine.API.Controllers
{
	[ServiceFilter(typeof(LogCallEngineParams))]
	public class OperatorController : TwilioController
	{
		[HttpPost]
		public async Task<TwiMLResult> Index(VoiceRequest incomingCall, [FromQuery] int? id)
		{
			var response = new VoiceResponse();

			response.Enqueue("OpCall",waitUrl: new Uri("/operator/PlayWaitMusic", UriKind.Relative), action: new Uri("/operator/DequeueSource", UriKind.Relative));
			const string accountSid = "AC429400933718bce97a62a1257a243a41";
			const string authToken = "3d6519be651da697ec04aec05580c3df";

			TwilioClient.Init(accountSid, authToken);
			
			var call = CallResource.Create(
				url: new Uri("http://2bf482c6.ngrok.io/operator/destpickup"),
				to: new Twilio.Types.PhoneNumber("+18056247045"),
				from: new Twilio.Types.PhoneNumber("+18052108919"),
				statusCallback: new Uri("http://2bf482c6.ngrok.io/operator/deststatus")
			);


			Console.WriteLine(response.ToString());
			return TwiML(response);
		}

		[HttpPost]
		public async Task<TwiMLResult> DestPickup(StatusCallbackRequest incomingCall, string SourceSid)
		{
			var voiceResponse = new VoiceResponse();
			var dial = new Dial().Queue(SourceSid);
			voiceResponse.Append(dial);
			return TwiML(voiceResponse);
		}


		[HttpPost]
		public async Task<TwiMLResult> PlayWaitMusic(StatusCallbackRequest incomingCall)
		{

			var voiceResponse = new VoiceResponse();
			voiceResponse.Play(new Uri("http://com.twilio.sounds.music.s3.amazonaws.com/MARKOVICHAMP-Borghestral.mp3"), loop: 0);			
			return TwiML(voiceResponse);
		}

		[HttpPost]
		public async Task<TwiMLResult> DequeueSource(StatusCallbackRequest incomingCall)
		{
			// This will hang up inbound source call
			var voiceResponse = new VoiceResponse();						
			return TwiML(voiceResponse);
		}
				
		[HttpPost]
		public async Task<TwiMLResult> DestStatus(StatusCallbackRequest incomingCall)
		{
			// This will hang up operator leg or let you know it failed
			var voiceResponse = new VoiceResponse();
			return TwiML(voiceResponse);
		}
	}
}