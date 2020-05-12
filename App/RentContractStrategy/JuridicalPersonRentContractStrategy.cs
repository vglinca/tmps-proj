using App.RentContractStrategy.Interfaces;
using Core.ContractCommand;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.RentContractStrategy
{
	public class JuridicalPersonRentContractStrategy : RentContractCreationStrategyBase
	{
		public JuridicalPersonRentContractStrategy(CreateContractCommandBase command) : base(command)
		{
		}
		public override void GatherContractInfo()
		{
		}
	}
}
