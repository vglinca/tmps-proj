using Core.ContractCommand;
using Core.ErrorDecorator;
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
		protected CommonErrorDecorator _commonError = null;
		public RentContractCreationStrategyBase(CreateContractCommandBase command, IRepositoryService service)
		{
			_command = command;
			_service = service;
		}
		public abstract Task GatherContractInfo();
		public abstract int CalculateDiscount(int total, int days);
	}
}
