using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace ConvertTxt
{
	public class ComprehensionConverter : IConverter<Comprehension>
	{
		public void Verify(Comprehension t)
		{
			if (string.IsNullOrEmpty(t.Paragraph))
			{
				throw new Exception("Paragraph empty");
			}

			if (t.Questions == null || t.Questions.Count == 0)
			{
				throw new Exception("No question");
			}

			if (t.Questions.Any(x => x.CorrectIndex < 0 || x.CorrectIndex > 3))
			{
				throw new Exception("Incorrect correct index");
			}

			if (t.Questions.Any(x=>x.Answers == null || x.Answers.Count != 4))
			{
				throw new Exception("Answer count should be 4");
			}

		}

		public Comprehension Convert(string text)
		{
			var comprehension = new Comprehension();

			var lines = text.Split('\n').Select(x=>x.Trim()).ToList();
			var sb = new StringBuilder();

			for (int i = 0; i < lines.Count; i++)
			{
				var isLineEmpty = string.IsNullOrEmpty(lines[i]);

				if (sb != null)
				{
					sb.Append(lines[i] + '\n');
				}

				if (sb != null && isLineEmpty && string.IsNullOrEmpty(lines[i + 1]))
				{
					comprehension.Paragraph = sb.ToString();
					comprehension.Questions = new List<Question>();
					sb = null;
					continue;
				}

				if (sb == null)
				{
					if (isLineEmpty)
					{
						comprehension.Questions.Add(new Question());
						comprehension.Questions.Last().CorrectIndex = -1;
					}
					else 
					{
						var question = comprehension.Questions.Last();
						if (string.IsNullOrEmpty(question.Title))
						{
							question.Title = lines[i];
						}
						else 
						{
							if (question.Answers == null)
							{
								question.Answers = new List<string>();
							}

							if (lines[i].Contains("---Correct"))
							{
								question.CorrectIndex = question.Answers.Count;
							}

							question.Answers.Add(lines[i].Replace("---Correct", string.Empty));
						}
					}
				}
			}

			return comprehension;
		}
	}
}
