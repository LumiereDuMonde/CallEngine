using System;
using System.Collections.Generic;
using System.Text;

namespace CallEngine.Models
{
	public class User
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public DateTime Created { get; set; } = DateTime.UtcNow;
		public ICollection<Engagement> Engagements { get; set; }
		public ICollection<CallSchedule> CallSchedules { get; set; }
		public ICollection<Digit> Digits { get; set; }
		public ICollection<BaseActionModel> BaseActionModels { get; set; }
		public ICollection<IncomingCall> IncomingCalls { get; set; }
		public ICollection<Mailbox> MailBoxes { get; set; }
		public ICollection<SoundFile> SoundFiles { get; set; }
		public DateTime LastLogin { get; set; }
		public bool Active { get; set; } = false;
		public bool Enabled { get; set; } = true;
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Phonenumber { get; set; }
		public ICollection<Voicemail> Voicemails { get; set; }
		public ICollection<OperatorGroup> OperatorGroups { get; set; }
		public ICollection<Operator> Operators { get; set; }
		public ICollection<OperatorGroupTracker> OperatorGroupTrackers { get; set; }
		public ICollection<OutboundCall> OutboundCalls { get; set; }
		public byte[] PasswordHash { get; set; }
		public byte[] PasswordSalt { get; set; }
		public ICollection<IncomingSMS> IncomingSMS { get; set; }
		public ICollection<DNIS> DNIS { get; set; }
	}
}
