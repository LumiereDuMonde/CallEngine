using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CallEngine.Models
{
	public class Engagement
	{
		public int Id { get; set; }
		public string Description { get; set; }
		public ICollection<BaseActionModel> Actions { get; set; }
		public DateTime Created { get; set; } = DateTime.UtcNow;
		public int UserId { get; set; }
		public User User { get; set; }
		public ICollection<CallSchedule> CallSchedules { get; set; }
		public ICollection<IncomingCall> IncomingCalls { get; set; }
	}
}
