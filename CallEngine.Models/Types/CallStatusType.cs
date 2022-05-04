using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CallEngine.Models
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum CallStatusType
	{
		completed,
		ringing,
		[EnumMember(Value = "in-progress")]
		inprogress,
		queued,
		canceled,
		busy,
		failed
	}
}
