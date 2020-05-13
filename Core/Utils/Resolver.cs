using Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utils
{
	public static class Resolver
	{
		public delegate IRepositoryService ServiceResolver(ServiceType type);
	}
}
