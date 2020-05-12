using App.RentContractStrategy.Interfaces;
using Core.ContractCommand;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.RentContractStrategy
{
	public class PhysicalPersonRentContractStrategy : RentContractCreationStrategyBase
	{
		public PhysicalPersonRentContractStrategy(CreateContractCommandBase command) : base(command)
		{
		}
		public override void GatherContractInfo()
		{
		}
	}
}
