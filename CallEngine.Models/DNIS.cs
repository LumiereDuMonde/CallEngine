using System;
using System.Collections.Generic;
using System.Text;

namespace CallEngine.Models
{
	public class DNIS
	{
		public int Id { get; set; }
		public string Phonenumber { get; set; }
		public int? UserId { get; set; }
		public User User { get; set; }
		public DateTime Created { get; set; } = DateTime.UtcNow;
	}
}
