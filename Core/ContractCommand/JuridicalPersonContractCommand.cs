using AutoMapper;
using Core.ClientDataBuilder;
using Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.ContractCommand
{
	public class JuridicalPersonContractCommand : CreateContractCommandBase
	{
		public JuridicalPersonContractCommand(IRepositoryService service, IMapper mapper) : base(service, mapper)
		{
		}
		public override Task Execute(ClientData clientData)
		{
			return null;
		}
	}
}
