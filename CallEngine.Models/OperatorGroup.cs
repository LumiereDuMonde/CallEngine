using System;
using System.Collections.Generic;
using System.Text;

namespace CallEngine.Models
{
	public class OperatorGroup
	{
		public int Id { get; set; }		
		public int? MailboxId { get; set; }
		public Mailbox Mailbox { get; set; }
		public ICollection<OperatorAction> OperatorActions { get; set; }
		public ICollection<OperatorGroupTracker> OperatorGroupTrackers { get; set; }		
		public int UserId { get; set; }
		public User User { get; set; }
	}

	public enum OperatorDialSequence
	{
		Sequential,
		RoundRobin
	}
}
