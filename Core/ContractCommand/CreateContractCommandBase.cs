using AutoMapper;
using Core.ClientDataBuilder;
using Core.Services.Interfaces;
using Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.ContractCommand
{
	public abstract class CreateContractCommandBase
	{
		protected readonly IRepositoryService _service;
		protected readonly IMapper _mapper;
		public CreateContractCommandBase(IRepositoryService service, IMapper mapper)
		{
			_service = service;
			_mapper = mapper;
		}
		public abstract Task<RentContract> Execute(ClientData clientData);
	}
}
