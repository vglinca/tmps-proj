using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Exceptions
{
	public class EntityNotFoundException : Exception
	{
		public EntityNotFoundException()
		{}

		public EntityNotFoundException(string msg) : base(msg)
		{}
	}
}
