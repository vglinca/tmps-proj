using Core.ContractCommand;
using Core.Services.Interfaces;
using Core.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Core.Utils.Resolver;

namespace App.RentContractStrategy.Interfaces
{
	public abstract class RentContractCreationStrategyBase
	{
		protected readonly CreateContractCommandBase _command;
		protected readonly IRepositoryService _service;
		public RentContractCreationStrategyBase(CreateContractCommandBase command, IRepositoryService service)
		{
			_command = command;
			_service = service;
		}
		public abstract Task GatherContractInfo();
	}
}
