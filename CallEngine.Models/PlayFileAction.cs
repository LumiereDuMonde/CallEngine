using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CallEngine.Models
{	
	public class PlayFileAction : BaseActionModel
	{
		public PlayFileAction()
		{
			this.Type = CallActionType.PlayFile;
		}
		public string TerminationKey { get; set; } = "#";
		public int Timeout = 3;
		public int NumberOfDigits = 1;
	}

	
}
