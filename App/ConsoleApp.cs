using AutoMapper;
using Core.ClientDataBuilder;
using Core.ContractCommand;
using Core.Services;
using Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Core.Utils.Resolver;

namespace App
{
	public class ConsoleApp
	{
		private readonly IRepositoryService _service;
		private readonly IMapper _mapper;
		public ConsoleApp(ServiceResolver resolver, IMapper mapper)
		{
			_service = resolver(Core.Utils.ServiceType.RentCarService);
			_mapper = mapper;
		}

		public async Task RunAsync()
		{
			try
			{
				var command = new PhysicalPersonContractCommand(_service, _mapper);
				var clientData = new ClientDataBuilder()
						.BirthDate(new DateTime(1995, 11, 22))
						.ClientTypeId(Persistance.Entities.ClientTypeId.PhysicalPerson)
						.Name("Vasya Ivanov")
						.Phone("836583")
						.CarId(1)
						.Iban($"{Guid.NewGuid().ToString()}")
						.RentStartDate(new DateTime(2020, 5, 20))
						.RentEndDate(new DateTime(2020, 5, 28))
						.Idno($"{Guid.NewGuid().ToString()}")
						.DriverLicenseId("985777")
						.Build();
				await command.Execute(clientData);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
