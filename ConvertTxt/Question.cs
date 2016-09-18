using System;

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ConvertTxt
{
	[DataContract]
	public class Question
	{
		[DataMember(Name = "title")]
		public string Title { get; set; }

		[DataMember(Name="answers")]
		public List<string> Answers { get; set; }

		[DataMember(Name="correct_index")]
		public int CorrectIndex { get; set; }
	}
}
