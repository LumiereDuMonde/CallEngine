using System;
using System.Collections.Generic;
using System.Text;

namespace CallEngine.Models
{
	public class Digit
	{
		public int Id { get; set; }
		public string Key { get; set; }
		public int ParentActionId { get; set; }		
		public BaseActionModel ParentAction { get; set; }
		public int? NextActionId { get; set; }
		public BaseActionModel NextAction { get; set; }
		public DateTime Created { get; set; } = DateTime.UtcNow;		
	}
}
