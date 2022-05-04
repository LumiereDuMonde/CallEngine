using CallEngine.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CallEngine.DAL
{
	public class UsersRepository : IUserRepository
	{
		private readonly CallAppContext _context;

		public UsersRepository(CallAppContext context)
		{
			this._context = context;
		}

		public async Task<User> GetUser(int id)
		{
			return await _context.Users.FirstOrDefaultAsync(v => v.Id == id);
		}

		public async Task<List<User>> GetUsers()
		{
			return await _context.Users.ToListAsync();
		}

		public Task Login(User user)
		{
			throw new NotImplementedException();
		}
	}
}
