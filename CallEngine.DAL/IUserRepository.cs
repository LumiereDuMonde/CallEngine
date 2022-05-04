using CallEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CallEngine.DAL
{
	public interface IUserRepository
	{
		Task<List<User>> GetUsers();
		Task<User> GetUser(int id);
		Task Login(User user);
	}
}
