using System;
using System.Collections.Generic;
using System.Text;

namespace CallEngine.Models
{
	public class CallSchedule
	{
		public int Id { get; set; }
		public int? EngagementId { get; set; }
		public Engagement Engagement { get; set; }
		public DateTime Created { get; set; } = DateTime.UtcNow;
		public string DNIS { get; set; }
		public string ANI { get; set; }
		public int? UserId { get; set; }
		public User User { get; set; }
	}
}
