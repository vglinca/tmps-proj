using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ErrorDecorator
{
	public class InvalidCardNumberErrorDecorator : CommonErrorDecorator
	{
		public InvalidCardNumberErrorDecorator(IError error, string msg) : base(error, msg)
		{
		}

		public override string ShowErrorMessage()
		{
			return base.ShowErrorMessage() + $" {_msg}";
		}
	}
}
