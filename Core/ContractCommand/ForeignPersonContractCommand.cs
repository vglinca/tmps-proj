using AutoMapper;
using Core.ClientDataBuilder;
using Core.ContractCommand;
using Core.Services.Interfaces;
using Persistance.ContractFactory;
using Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.ContractCommand
{
	public class ForeignPersonContractCommand : CreateContractCommandBase
	{
		public ForeignPersonContractCommand(IRepositoryService service, IMapper mapper) : base(service, mapper)
		{
		}
		public async override Task Execute(ClientData clientData)
		{
			var contract = new ForeignPersonRentContractFactory().CreateRentContract() as ForeignerRentContract;
			var client = _mapper.Map<Client>(clientData);

			await _service.AddAsync<Client>(client);

			_mapper.Map(clientData, contract);

			contract.ClientId = client.Id;

			await _service.AddAsync<ForeignerRentContract>(contract);
		}
	}
}
