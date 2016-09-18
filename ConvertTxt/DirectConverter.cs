using System;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace ConvertTxt
{
	public class DirectConverter<T>
	{
		private IConverter<T> converter;

		public DirectConverter(IConverter<T> converter)
		{
			this.converter = converter;
		}

		public void Convert(String directory)
		{
			var files = Directory.EnumerateFiles(directory, "*.txt");
			foreach (var file in files)
			{
				ConvertFile(file);
			}

			var childDirectories = Directory.EnumerateDirectories(directory);
			foreach (var childDirectory in childDirectories)
			{
				Convert(childDirectory);
			}
		}

		public void ConvertFile(string file)
		{
			var directory = Path.GetDirectoryName(file);
			var textContent = File.ReadAllText(file);
			var t = converter.Convert(textContent);
			try
			{
				converter.Verify(t);
			}
			catch (Exception ex)
			{
				Console.WriteLine("File " + file + " is error. " + ex.Message);
			}


			var desFile = Path.Combine(directory, Path.GetFileNameWithoutExtension(file) + ".json");

			File.WriteAllText(desFile, JsonConvert.SerializeObject(t));
		}
	}
}
