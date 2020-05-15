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
			Console.SetWindowSize( (int)(Console.WindowWidth * 1.2), Console.WindowHeight);
			try
			{
				var cars = await _service.GetAllAsync<Car>();

				Console.WriteLine("\t\tCARS");
				Console.WriteLine("{0,-20}{1,-30}{2,-50}{3,-20}{4,-10}", "Car number", "Model", "Engine", "Transmission", "Price/Day ($)");
				foreach (var car in cars)
				{
					Console.WriteLine("{0,-20}{1,-30}{2,-50}{3,-20}{4,-10}", car.Id, car.ModelName, car.EngineDetails, car.Transmission.Title, car.PricePerDay);
				}

				var clientTypes = await _service.GetAllAsync<ClientType>();
				Console.WriteLine();
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
