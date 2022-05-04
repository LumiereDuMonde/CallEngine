using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CallEngine.API.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]	
	public class ValuesController : ControllerBase
	{

		// GET api/values/5
		[AllowAnonymous]
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			return Ok(id + 1);
		}
	}
}