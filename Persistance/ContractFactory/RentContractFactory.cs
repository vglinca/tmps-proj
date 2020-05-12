using Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.ContractFactory
{
	public abstract class RentContractFactory
	{
		public abstract RentContract CreateRentContract();
	}
}
