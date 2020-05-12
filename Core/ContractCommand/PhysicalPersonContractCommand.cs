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
		public PhysicalPersonContractCommand(IRentCarService service) : base(service)
		{
		}
		public async override Task Execute(ClientData clientData)
		{
			var contract = new PhysicalPersonRentContractFactory().CreateRentContract() as PhysicalPersonRentContract;
			var client = new Client
			{
				BirthDate = clientData.BirthDate,
				ClientTypeId = clientData.ClientTypeId,
				Name = clientData.Name,
				Phone = clientData.Phone
			};

			var car = await _service.GetByIdAsync<Car>(clientData.CarId);

			await _service.AddAsync<Client>(client);

			contract.ClientId = client.Id;
			contract.CarId = clientData.CarId;
			contract.Iban = clientData.Iban;
			contract.RentStartDate = clientData.RentStartDate;
			contract.RentEndDate = clientData.RentEndDate;
			contract.RentCost = car.PricePerDay * (int) ((clientData.RentEndDate - clientData.RentStartDate).TotalDays);
			contract.Idno = clientData.Idno;
			contract.DriverLicenseId = clientData.DriverLicenseId;

			await _service.AddAsync<PhysicalPersonRentContract>(contract);
		}
	}
}
