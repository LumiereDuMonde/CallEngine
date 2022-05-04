using System;
using System.Collections.Generic;
using System.Text;

namespace CallEngine.Models
{
	public class Mailbox
	{
		public int Id { get; set; }
		public string BoxNumber { get; set; }
		public string PIN { get; set; }
		public int? SoundFileId { get; set; }
		public SoundFile SoundFile { get; set; }
		public DateTime Created { get; set; } = DateTime.UtcNow;
		public int UserId { get; set; }
		public User User { get; set; }
		public ICollection<Voicemail> Voicemails { get; set; }
		public bool SaveToSoundFiles { get; set; } = false;
		public ICollection<BaseActionModel> RecordFileActions { get; set; }
		public bool PlayBeep { get; set; } = true;
		public int MaxLength { get; set; } = 300;
		public string Description { get; set; }
	}
}
