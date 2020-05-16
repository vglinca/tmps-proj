using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ErrorDecorator
{
	public class NotFoundErrorDecorator : CommonErrorDecorator
	{
		public NotFoundErrorDecorator(IError error, string msg) : base(error, msg)
		{
		}

		public override string ShowErrorMessage()
		{
			return base.ShowErrorMessage() + $" {_msg}";
		}
	}
}
