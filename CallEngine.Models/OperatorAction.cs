using System;
using System.Collections.Generic;
using System.Text;

namespace CallEngine.Models
{
	public class OperatorAction : RecordFileAction
	{
		public OperatorAction()
		{
			this.Type = CallActionType.Operator;
		}

	}
}
