using CallEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CallEngine.DAL
{
	public interface ICallRepository
	{
		void Add<T>(T entity) where T : class;
		void Delete<T>(T entity) where T : class;
		Task<bool> SaveAll();
		Task<Engagement> GetEngagement(string DNIS);
		Task<Engagement> GetEngagement(string DNIS, string ANI);
		Task<IncomingCall> GetIncomingCall(string Sid);
		Task<Engagement> GetEngagementFromSid(string Sid);
		Task<Operator> GetOperator(int id);
		Task<Mailbox> GetMailbox(int id);
		Task<User> GetUserForSMS(string DNIS);
		Task<User> GetUserForSMS(string DNIS, string ANI);
		Task<List<IncomingSMS>> GetMessagesForUserAndNumber(int userId, string DNIS);
	}
}
