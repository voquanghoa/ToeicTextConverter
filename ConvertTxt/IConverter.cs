using System;
using System.Collections.Generic;

namespace ConvertTxt
{
	public interface IConverter<T>
	{
		T Convert(string text);
		void Verify(T t);
	}
}
