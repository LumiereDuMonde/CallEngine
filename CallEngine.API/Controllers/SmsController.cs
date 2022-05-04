using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CallEngine.API.ActionFilter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twilio.AspNet.Core;
using Twilio.AspNet.Common;
using Twilio.TwiML;
using CallEngine.Models;
using CallEngine.DAL;

namespace CallEngine.API.Controllers
{	
	[ServiceFilter(typeof(LogCallEngineParams))]
	public class SmsController : TwilioController
	{
		private readonly ICallRepository _repo;

		public SmsController(ICallRepository repo)
		{
			_repo = repo;
		}

		[HttpPost]
		public async Task<TwiMLResult> Index(SmsRequest request, int numMedia)
		{
		    var response = new MessagingResponse();
			var user = await _repo.GetUserForSMS(request.To);
			var message = new IncomingSMS
			{
				From = request.From,
				To = request.To,
				Message = request.Body,
				User = user
			};
			_repo.Add(message);
			await _repo.SaveAll();				
			return TwiML(response);
		}

	}
}