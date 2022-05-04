using CallEngine.DAL;
using CallEngine.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Tests
{
	public class Tests
	{
		private CallAppContext _context;
		private CallRepository _repo;
		[SetUp]
		public void Setup()
		{
			var options = new DbContextOptionsBuilder<CallAppContext>()
						   .UseSqlServer("Data Source=DESKTOP-GK9827F\\SQLEXPRESS;Initial Catalog=CallingApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
						   .Options;
			_context = new CallAppContext(options);
			_repo = new CallRepository(_context);
		}

		[Test]
		public async Task Test1()
		{
			var engagement = await _repo.GetEngagement("+18052108919");
			var firstAction = engagement.Actions?.FirstOrDefault(x => x.Initial);
			Assert.Pass();
		}

		[Test]
		public async Task Test2()
		{
			var engagement = await _repo.GetEngagement("+18052108919","");
			var firstAction = engagement.Actions?.FirstOrDefault(x => x.Initial);
			Assert.Pass();
		}

		[Test]
		public async Task Test3()
		{
			var incomingCall = new IncomingCall
			{
				DNIS = "8055551212",
				ANI = "8185551212",
				CallStatus = CallStatusType.inprogress,
				Duration = 0				
			};
			_repo.Add<IncomingCall>(incomingCall);
			var result = await _repo.SaveAll();
			Assert.IsTrue(result);
		}

		[Test]
		public async Task Test4()
		{
			var engagement = await _repo.GetEngagement("+18052108919", "");
			var firstAction = engagement.Actions?.FirstOrDefault(x => x.Initial);
			var incomingCall = new IncomingCall
			{
				DNIS = "8055551212",
				ANI = "8185551212",
				CallStatus = CallStatusType.inprogress,
				Duration = 0,
				Engagement = engagement,
				UserId = engagement.UserId
			};
			_repo.Add<IncomingCall>(incomingCall);
			var result = await _repo.SaveAll();
			try
			{
				var test = JsonConvert.SerializeObject(incomingCall, new JsonSerializerSettings
						{
							ReferenceLoopHandling = ReferenceLoopHandling.Ignore
						}
					);
				Console.WriteLine(test);
			} catch (Exception e)
			{
				Console.WriteLine(e);
			}
			
			Assert.IsTrue(result);

			
		}
	}
}