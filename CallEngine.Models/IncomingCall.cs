using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace CallEngine.Models
{
	public class IncomingCall
	{
		public int Id { get; set; }
		public int? EngagementId { get; set; }
		public Engagement Engagement { get; set; }
		public string CallSid { get; set; }
		public CallStatusType CallStatus { get; set; }
		public int Duration { get; set; }
		public string ANI { get; set; }
		public string DNIS { get; set; }
		public DateTime Created { get; set; } = DateTime.UtcNow;
		public int? UserId { get; set; }
		public User User { get; set; }
	}


}
