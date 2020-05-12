using Core.ClientDataBuilder;
using Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.ContractCommand
{
	public abstract class CreateContractCommandBase
	{
		protected readonly IRentCarService _service;
		public CreateContractCommandBase(IRentCarService service)
		{
			_service = service;
		}
		public abstract Task Execute(ClientData clientData);
	}
}
