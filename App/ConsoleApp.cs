using App.RentContractStrategy;
using AutoMapper;
using Core.ClientDataBuilder;
using Core.ContractCommand;
using Core.Services;
using Core.Services.Interfaces;
using Persistance.Entities;
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
				const string format = "Car number: {0,6}Model: {1,6}Transmission: {2,20}Engine: {3,20}Price/Day: {4,20}";
				var cars = await _service.GetAllAsync<Car>();

				Console.WriteLine("\t\tCARS");

				foreach (var car in cars)
				{
					Console.WriteLine(string.Format(format, car.Id, car.ModelName, car.TransmissionTypeId.ToString(), car.EngineDetails, $"${car.PricePerDay}"));
				}

				var clientTypes = await _service.GetAllAsync<ClientType>();

				Console.WriteLine("Which client type are You?");
				var i = 0;
				foreach (var type in clientTypes)
				{
					Console.WriteLine($"{i++} - {type.Title}");
				}
				Console.WriteLine("Your type is: ");
				if (int.TryParse(Console.ReadLine(), out var input))
				{
					switch (input)
					{
						case 0:
							await new ForeignPersonRentContractStrategy(
								new ForeignPersonContractCommand(_service, _mapper), _service)
								.GatherContractInfo();
							break;
						case 1:
							await new PhysicalPersonRentContractStrategy(
								new PhysicalPersonContractCommand(_service, _mapper), _service)
								.GatherContractInfo();
							break;
						case 2:
							await new JuridicalPersonRentContractStrategy(
								new JuridicalPersonContractCommand(_service, _mapper), _service)
								.GatherContractInfo();
							break;
						default:
							break;
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
