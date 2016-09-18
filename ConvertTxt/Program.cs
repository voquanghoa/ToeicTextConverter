using System;

namespace ConvertTxt
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var directory1 = "/Users/osx/Desktop/TxtJson/Comprehension";
			var directory2 = "/Users/osx/Desktop/TxtJson/Text Completion 5";

			new DirectConverter<Comprehension>(new ComprehensionConverter()).Convert(directory1);

			new DirectConverter<Compretion>(new CompretionConverter()).Convert(directory2);

		}
	}
}
