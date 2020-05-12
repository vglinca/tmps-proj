using Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.ContractFactory
{
	public class ForeignPersonRentContractFactory : RentContractFactory
	{
		public override RentContract CreateRentContract()
		{
			return new ForeignerRentContract();
		}
	}
}
