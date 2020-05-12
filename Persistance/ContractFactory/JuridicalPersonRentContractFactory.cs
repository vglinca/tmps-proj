using Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.ContractFactory
{
	public class JuridicalPersonRentContractFactory : RentContractFactory
	{
		public override RentContract CreateRentContract()
		{
			return new JuridicalPersonRentContract();
		}
	}
}
