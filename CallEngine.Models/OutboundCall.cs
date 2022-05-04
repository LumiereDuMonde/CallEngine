using System;
using System.Collections.Generic;
using System.Text;

namespace CallEngine.Models
{
	public class OutboundCall
	{
		public int Id { get; set; }
		public string Phonenumber { get; set; }		
		public CallStatusType CallStatus { get; set; }
		public int Duration { get; set; }
		public DateTime Created { get; set; } = DateTime.UtcNow;
		public string Sid { get; set; }
		public string SourceSid { get; set; }
		public int? UserId { get; set; }
		public User User { get; set; }
		public int? EngagementId { get; set; }
		public Engagement Engagement { get; set; }
	}
}
