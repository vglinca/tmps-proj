using AutoMapper;
using Core.ClientDataBuilder;
using Core.ContractCommand;
using Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.ContractCommand
{
	class ForeignPersonContractCommand : CreateContractCommandBase
	{
		public ForeignPersonContractCommand(IRepositoryService service, IMapper mapper) : base(service, mapper)
		{
		}
		public override Task Execute(ClientData clientData)
		{
			return null;
		}
	}
}
