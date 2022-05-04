using System;
using System.Collections.Generic;
using System.Text;

namespace CallEngine.Models
{
	public class Operator
	{
		public int Id { get; set; }
		public string Number { get; set; }
		public string CountryCode { get; set; } = "1";
		public int? MailboxId { get; set; }
		public Mailbox Mailbox { get; set; }
		public ICollection<OperatorAction> OperatorActions { get; set; }
		public bool Active { get; set; } = true;
		public bool OnCall { get; set; } = false;
		public int? UserId { get; set; }
		public User User { get; set; }
		public DateTime Created { get; set; } = DateTime.UtcNow;										   
	}
}
