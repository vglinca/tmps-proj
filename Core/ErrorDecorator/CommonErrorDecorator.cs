using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ErrorDecorator
{
	public abstract class CommonErrorDecorator : IError
	{
		protected IError _error;
		protected string _msg;
		public CommonErrorDecorator(IError error, string msg)
		{
			_error = error;
			_msg = msg;
		}
		public virtual string ShowErrorMessage()
		{
			return _error.ShowErrorMessage();
		}
	}
}
