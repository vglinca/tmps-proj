using App.RentContractStrategy.Interfaces;
using Core.ContractCommand;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.RentContractStrategy
{
	public class ForeignPersonRentContractStrategy : RentContractCreationStrategyBase
	{
		public ForeignPersonRentContractStrategy(CreateContractCommandBase command) : base(command)
		{
		}

		public override void GatherContractInfo()
		{
		}
	}
}
