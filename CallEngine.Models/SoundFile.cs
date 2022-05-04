using System;
using System.Collections.Generic;
using System.Text;

namespace CallEngine.Models
{
	public class SoundFile
	{
		public int Id { get; set; }
		public string Uri { get; set; }
		public string FileType { get; set; }
		public bool isTTS { get; set; } = false;
		public string TTS { get; set; }
		public string Description { get; set; }
		public DateTime Created { get; set; } = DateTime.UtcNow;
		public int? UserId { get; set; }
		public User User { get; set; }
	}
}
