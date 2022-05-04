using System;
using System.Collections.Generic;
using System.Text;

namespace CallEngine.Models
{
	public class CallEngineParamsLog
	{
		public int Id { get; set; }
		public string QueryString { get; set; }
		public string Form { get; set; }
		public DateTime Created { get; set; } = DateTime.UtcNow;
		public string Url { get; set; }
		public string Sid { get; set; }
	}
}
