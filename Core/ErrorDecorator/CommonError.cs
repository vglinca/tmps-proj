using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ErrorDecorator
{
	public class CommonError : IError
	{
		private string _message;
		public CommonError(string message)
		{
			_message = message;
		}
		public string ShowErrorMessage()
		{
			return _message;
		}
	}
}
