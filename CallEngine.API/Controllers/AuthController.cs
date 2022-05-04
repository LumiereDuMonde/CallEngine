using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using CallEngine.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CallEngine.Core;
using CallEngine.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace CallEngine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
		private readonly IAuthRepository _repo;
		private readonly IConfiguration _config;
		private readonly IMapper _mapper;

		public AuthController(IAuthRepository repo, IConfiguration config, IMapper mapper)
		{
			_repo = repo;
			_config = config;
			_mapper = mapper;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register(UserForRegisterDTO userDTO)
		{
			// don't need validate model if ApiController attribute decorates the class			

			userDTO.Username = userDTO.Username.ToLower();
			if (await _repo.UserExists(userDTO.Username))
				return BadRequest("Username already exists");

			var userToCreate = _mapper.Map<User>(userDTO);

			var createdUser = await _repo.Register(userToCreate, userDTO.Password);

			
			var userToReturn = _mapper.Map<UserForDetailedDTO>(createdUser);

			return Ok();		
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login(UserForLoginDTO userForLoginDTO)
		{

			var userFromRepo = await _repo.Login(userForLoginDTO.Username.ToLower(), userForLoginDTO.Password);

			if (userFromRepo == null)
				return Unauthorized();

			var claims = new[]
			{
				new Claim(ClaimTypes.NameIdentifier,userFromRepo.Id.ToString()),
				new Claim(ClaimTypes.Name, userFromRepo.Username)
			};
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Expires = DateTime.Now.AddDays(7),
				SigningCredentials = creds
			};

			var tokenHandler = new JwtSecurityTokenHandler();

			var token = tokenHandler.CreateToken(tokenDescriptor);

			var user = _mapper.Map<UserForDetailedDTO>(userFromRepo);

			return Ok(new
			{
				token = tokenHandler.WriteToken(token),
				user
			});

		}
	}
}