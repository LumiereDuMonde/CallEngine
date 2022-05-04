using System;
using System.Collections.Generic;
using System.Text;

namespace CallEngine.Models
{
	public class RecordFileAction : PlayFileAction
	{
		public RecordFileAction()
		{
			this.Type = CallActionType.Record;
			this.Timeout = 5;
		}

	}
}
