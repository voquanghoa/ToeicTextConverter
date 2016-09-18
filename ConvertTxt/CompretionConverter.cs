using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ConvertTxt
{
	public class CompretionConverter : IConverter<Compretion>
	{
		public Compretion Convert(string text)
		{
			var lines = text.Split('\n').Select(x => x.Trim()).ToList();
			var compretion = new Compretion()
			{
				Children = new List<ChildCompretion>()
			};

			ChildCompretion current = null;
			foreach (var line in lines)
			{
				if (current == null)
				{
					current = new ChildCompretion();
				}

				if (Regex.IsMatch(line, "^\\d{3}\\.$"))
				{
					compretion.Children.Add(current);
					current = new ChildCompretion()
					{
						Answers = new List<string>(),
						CorrectIndex = -1
					};
					continue;

				}

				if (current.Answers == null)
				{
					current.Paragraph += line + "\n";
				}
				else 
				{
					if (line.Contains("---Correct"))
					{
						current.CorrectIndex = current.Answers.Count;
						current.Answers.Add(line.Replace("---Correct", ""));
					}
					else 
					{
						current.Answers.Add(line);
					}

					if (current.Answers.Count == 4)
					{
						compretion.Children.Add(current);
						current = null;
					}
				}
			}
			return compretion;
		}

		public void Verify(Compretion t)
		{
			if (t == null || t.Children == null)
			{
				throw new Exception("Object is null or children is null");
			}

			for (int i = 0; i < t.Children.Count; i++)
			{
				var child = t.Children[i];

				if (i % 2 == 0)
				{
					if (string.IsNullOrEmpty(child.Paragraph))
					{
						throw new Exception("Paragraph is null");
					}

					if (child.Answers !=null)
					{
						throw new Exception("Answer should be null");
					}
				}
				else 
				{
					if (!string.IsNullOrEmpty(child.Paragraph))
					{
						throw new Exception("Paragraph should be null");
					}

					if (child.Answers == null || child.Answers.Count != 4)
					{
						throw new Exception("Answer should not be null and has 4 children");
					}

					if (child.CorrectIndex < 0 || child.CorrectIndex > 3)
					{
						throw new Exception("Invalid correct index");
					}
				}
			}
		}
	}
}
