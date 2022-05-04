using System;
using System.Collections.Generic;
using System.Text;
using Twilio.AspNet.Common;

namespace CallEngine.Models
{
	public class RecordStatusCallbackRequest : StatusCallbackRequest
	{
		public string RecordingStatus { get; set; }		
	}
}
