using Core.ContractCommand;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.RentContractStrategy.Interfaces
{
	public abstract class RentContractCreationStrategyBase
	{
		private readonly CreateContractCommandBase _command;
		public RentContractCreationStrategyBase(CreateContractCommandBase command)
		{
			_command = command;
		}
		public abstract void GatherContractInfo();
	}
}
