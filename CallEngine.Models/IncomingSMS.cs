using System;
using System.Collections.Generic;
using System.Text;

namespace CallEngine.Models
{
	public class IncomingSMS
	{
		public int Id { get; set; }
		public string From { get; set; }
		public string To { get; set; }
		public string Message { get; set; }
		public DateTime Created { get; set; } = DateTime.UtcNow;
		public int? UserId { get; set; }
		public User User { get; set; }
	}
}
