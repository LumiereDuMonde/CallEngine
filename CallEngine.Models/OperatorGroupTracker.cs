using System;
using System.Collections.Generic;
using System.Text;

namespace CallEngine.Models
{
	public class OperatorGroupTracker
	{
		public int Id { get; set; }
		public int? OperatorId { get; set; }
		public Operator Operator { get; set; }
		public int OperatorGroupId { get; set; }
		public OperatorGroup OperatorGroup { get; set; }
		public DateTime? LastCallAttempt { get; set; }
		public int Order { get; set; } = 0;
		public int? UserId { get; set; }
		public User User { get; set; }
	}
}
