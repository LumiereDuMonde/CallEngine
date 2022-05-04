using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CallEngine.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CallEngine.API.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class MessagesController : ControllerBase
	{
		private readonly ICallRepository _repo;
		public MessagesController(ICallRepository repo)
		{
			_repo = repo;
		}
		[HttpGet("{userId}/{DNIS}")]
		public async Task<IActionResult> Get(int userId, string DNIS)
		{
			//var DNIS = "+18052108919";
			//var userId = 1;
			// test
			if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
				return Unauthorized();
			var messages = await _repo.GetMessagesForUserAndNumber(userId, DNIS);

			if (messages == null)
				return NotFound();

			return Ok(messages);
		}

	}
}