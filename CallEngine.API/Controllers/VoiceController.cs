using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CallEngine.API.ActionFilter;
using CallEngine.Core;
using CallEngine.DAL;
using CallEngine.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Twilio.AspNet.Common;
using Twilio.AspNet.Core;
using Twilio.TwiML;
using Twilio.TwiML.Voice;

namespace CallEngine.API.Controllers
{	
	[ServiceFilter(typeof(LogCallEngineParams))]
	public class VoiceController : TwilioController
	{
		private readonly ICallRepository _repo;
		private readonly IEngagementService _engagementService;

		public VoiceController(ICallRepository repo, IEngagementService engagementService)
		{
			_repo = repo;
			_engagementService = engagementService;
		}

		// Start the call
		[HttpPost]
        public async Task<TwiMLResult> Index(VoiceRequest incomingCall, [FromQuery] int? id)
        {			
			var voiceResponse = await _engagementService.AnswerIncomingCall(incomingCall);
			
			return TwiML(voiceResponse);
		}

		//Finish Play
		[HttpPost]
		public async Task<TwiMLResult> EndPlay(RecordStatusCallbackRequest incomingCall, [FromQuery] int? id)
		{			
			var dict = new Dictionary<string, string>();
			dict.Add("id", Convert.ToString(id));
			var voiceResponse = await _engagementService.EndPlay(incomingCall, dict);
			return TwiML(voiceResponse);
		}

		//Finish Record
		[HttpPost]
		public async Task<TwiMLResult> RecordDone(RecordStatusCallbackRequest incomingCall, [FromQuery] int? mailBoxId)
		{
			var dict = new Dictionary<string, string>();
			dict.Add("mailBoxId", Convert.ToString(mailBoxId));

			var voiceResponse = await _engagementService.EndRecord(incomingCall, dict);
		
			return TwiML(voiceResponse);
		}

		// Finish Call
		[HttpPost]
		public async Task<TwiMLResult> Status(StatusCallbackRequest incomingCall)
		{

			var voiceResponse = await _engagementService.UpdateStatus(incomingCall);
			return TwiML(voiceResponse);
		}
	}
}