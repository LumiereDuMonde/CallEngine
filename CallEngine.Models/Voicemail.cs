using System;
using System.Collections.Generic;
using System.Text;

namespace CallEngine.Models
{
	public class Voicemail
	{
		public int Id { get; set; }
		public string Uri { get; set; }
		public string RemoteUrl { get; set; }
		public float Duration { get; set; }
		public string ANI { get; set; }
		public DateTime Created { get; set; } = DateTime.UtcNow;
		public string Transcription { get; set; }
		public bool Downloaded { get; set; } = false;
		public int MailboxId { get; set; }
		public Mailbox Mailbox { get; set; }
		public bool New { get; set; } = true;
		public int? UserId { get; set; }
		public User User { get; set; }
		public string Sid { get; set; }
	}
}
