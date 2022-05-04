using AutoMapper;
using System.Linq;
using CallEngine.Models;

namespace CallEngine.Core.Helper
{
	public class AutoMapperProfiles : Profile
	{
		public AutoMapperProfiles()
		{
			CreateMap<UserForRegisterDTO, User>();
			CreateMap<User, UserForDetailedDTO>();
		}
	}
}
