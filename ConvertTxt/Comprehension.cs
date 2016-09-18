using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace ConvertTxt
{
	[DataContract]
	public class Comprehension
	{
		[DataMember(Name="paragraph")]
		public string Paragraph { get; set; }

		[DataMember(Name="questions")]
		public List<Question> Questions { get; set; }
	}
}
