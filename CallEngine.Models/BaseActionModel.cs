using System;
using System.Collections.Generic;
using System.Text;

namespace CallEngine.Models
{
	public class BaseActionModel
	{
		public int Id { get; set; }
		public CallActionType Type { get; set; }		
		public Engagement Engagement { get; set; }
		public bool Initial { get; set; } = false;
		public ICollection<Digit> Digits { get; set; }
		public DateTime Created { get; set; } = DateTime.UtcNow;
		public int? SoundFileId { get; set; }
		public SoundFile SoundFile { get; set; }
		public int? MailBoxId { get; set; }
		public Mailbox MailBox { get; set; }
		public int? OperatorId { get; set; }
		public Operator Operator { get; set; }
		public int? OperatorGroupId { get; set; }
		public OperatorGroup OperatorGroup { get; set; }
		// when null, retry call if not in group
		public int? NextActionAfterOpId { get; set; }
	}

	//[JsonConverter(typeof(StringEnumConverter))]
	public enum CallActionType
	{
		PlayFile,
		PlayTTS,
		Operator,		
		Record
	}
}
