using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ConvertTxt
{
	[DataContract]
	public class Compretion
	{
		[DataMember(Name = "children")]
		public List<ChildCompretion> Children { get; set; }		
	}
}
