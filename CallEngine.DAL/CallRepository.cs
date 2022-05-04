using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallEngine.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CallEngine.DAL
{	
	public class CallRepository : ICallRepository
	{

		private readonly CallAppContext _context;

		public CallRepository(CallAppContext context)
		{
			_context = context;
		}
		public void Add<T>(T entity) where T : class
		{
			_context.Add(entity);
		}

		public void Delete<T>(T entity) where T : class
		{
			_context.Remove(entity);
		}

		public async Task<Engagement> GetEngagement(string dnis)
		{
			var engagement = await _context.Engagements
				.Include(x => x.Actions)
					.ThenInclude(x => x.Digits)
				.Include(x => x.Actions)
					.ThenInclude(x => x.SoundFile)
				.FirstOrDefaultAsync(x => x.Id == 1);			
			return engagement;
		}

		public async Task<Engagement> GetEngagement(string dnis, string ani)
		{
			var engagement = await _context.CallSchedules
				.Include(e => e.Engagement)
				.Where(e => e.DNIS == dnis && (e.ANI == null || e.ANI == ani))
				.OrderBy(e => e.ANI)
				.Select(e => e.Engagement)
				.Include(a => a.Actions)
					.ThenInclude(s => s.SoundFile)					
				.Include(a => a.Actions)
					.ThenInclude(d => d.Digits)
				.Include(a => a.Actions)
					.ThenInclude(m => m.MailBox)
						.ThenInclude(s => s.SoundFile)
				.FirstOrDefaultAsync();
			
			return engagement;

		}

		public async Task<Engagement> GetEngagementFromSid(string Sid)
		{
			var engagement = await _context.IncomingCalls
				.Include(e => e.Engagement)
				.Where(i => i.CallSid == Sid)				
				.Select(e => e.Engagement)
				.Include(a => a.Actions)
					.ThenInclude(s => s.SoundFile)
				.Include(a => a.Actions)
					.ThenInclude(d => d.Digits)
				.Include(a => a.Actions)
					.ThenInclude(m => m.MailBox)
						.ThenInclude(s => s.SoundFile)
				.FirstOrDefaultAsync();

			return engagement;
		}

		public async Task<Operator> GetOperator(int id) 
		{
			var op = await _context.Operators.FirstOrDefaultAsync(o => o.Id == id);
			return op;
		}

		public async Task<IncomingCall> GetIncomingCall(string Sid)
		{
			return await _context.IncomingCalls.FirstOrDefaultAsync(i => i.CallSid == Sid);
		}

		public async Task<Mailbox> GetMailbox(int id)
		{
			return await _context.MailBoxes.FirstOrDefaultAsync(m => m.Id == id);
		}

		public async Task<bool> SaveAll()
		{
			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<User> GetUserForSMS(string DNIS)
		{
			var dnis = await _context.DNIS.Include(d => d.User).FirstOrDefaultAsync(i => i.Phonenumber == DNIS);
			return dnis?.User;
		}

		public async Task<User> GetUserForSMS(string DNIS, string ANI)
		{
			throw new NotImplementedException();
		}

		public async Task<List<IncomingSMS>> GetMessagesForUserAndNumber(int userId, string DNIS)
		{
			var messages = await _context.IncomingSMS.Where(m => m.UserId == userId && m.To == DNIS).ToListAsync();
			return messages;
		}
	}
}
