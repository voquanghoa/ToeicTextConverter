using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace ConvertTxt
{
	[DataContract]
	public class ChildCompretion
	{
		[DataMember(Name = "paragraph")]
		public string Paragraph { get; set; }

		[DataMember(Name = "answers")]
		public List<string> Answers { get; set; }

		[DataMember(Name = "correct_index")]
		public int CorrectIndex { get; set; }
	}
}
