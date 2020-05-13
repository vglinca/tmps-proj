﻿using AutoMapper;
using Core.ClientDataBuilder;
using Core.Services.Interfaces;
using Persistance.ContractFactory;
using Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.ContractCommand
{
	public class PhysicalPersonContractCommand : CreateContractCommandBase
	{
		public PhysicalPersonContractCommand(IRepositoryService service, IMapper mapper) : base(service, mapper)
		{
		}
		public async override Task Execute(ClientData clientData)
		{
			var contract = new PhysicalPersonRentContractFactory().CreateRentContract() as PhysicalPersonRentContract;
			var client = _mapper.Map<Client>(clientData);

			var car = await _service.GetByIdAsync<Car>(clientData.CarId);

			await _service.AddAsync<Client>(client);

			_mapper.Map(clientData, contract);

			contract.ClientId = client.Id;
			contract.RentCost = car.PricePerDay * (int) ((clientData.RentEndDate - clientData.RentStartDate).TotalDays);

			await _service.AddAsync<PhysicalPersonRentContract>(contract);
		}
	}
}
