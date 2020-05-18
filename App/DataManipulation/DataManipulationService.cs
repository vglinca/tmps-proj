using Core.Services.Interfaces;
using Core.Utils;
using Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.DataManipulation
{
	public class DataManipulationService
	{
		private readonly IRepositoryService _service;

		public DataManipulationService(IRepositoryService service)
		{
			_service = service;
		}

		public async Task HandleAsync()
		{
			var output = "Choose operation to perform:\n1 - GetAll\n2 - Add Car\n3 - Delete Car\n0 - Exit";
			Console.WriteLine(output);
			var input = int.Parse(Console.ReadLine());
			Console.Clear();
			while (input != 0)
			{
				switch (input)
				{
					case 0:
						Environment.Exit(0);
						break;
					case 1:
						await HandleReadingAll();
						break;
					case 2:
						await AddNewCarRecord();
						Console.Clear();
						await OutputCars();
						break;
					case 3:
						await OutputCars();
						Console.Write("Enter car Id, You want to remove: ");
						var carId = long.Parse(Console.ReadLine());
						try
						{
							await _service.DeleteAsync<Car>(carId);
							Thread.Sleep(2000);
							Console.WriteLine("Car successfully deleted...");
							Thread.Sleep(1000);
						}
						catch (Exception)
						{
							Console.WriteLine("An error occured during deletion.");
						}
						finally
						{
							Console.Clear();
							await OutputCars();
						}
						
						break;
					default:
						break;
				}
				Console.WriteLine(output);
				input = int.Parse(Console.ReadLine());
				Console.Clear();
			}
		}

		private async Task HandleReadingAll()
		{
			var output = "Choose entity to read:\n1 - Cars\n2 - Clients\n3 - RentContracts\n4 - Rent Contracts of a Client\n0 - Exit";
			IEnumerable<RentContract> rentContracts = new List<RentContract>();
			Console.WriteLine(output);
			var input = int.Parse(Console.ReadLine());
			Console.Clear();
			while (input != 0)
			{
				switch (input)
				{
					case 0:
						break;
					case 1:
						await OutputCars();
						break;
					case 2:
						var clients = await _service.GetAllAsync<Client>();
						Console.WriteLine("\t{0,-20}{1,-50}{2,-50}", "Id", "Name", "ClientType");
						foreach (var client in clients)
						{
							Console.WriteLine("\t{0,-20}{1,-50}{2,-50}", client.Id, client.Name, client.ClientType.Title);
						}
						break;
					case 3:
						rentContracts = await _service.GetAllAsync<RentContract>();
						Console.WriteLine("\t\t\t\t\t\t\t\tRENT CONTRACTS");
						foreach (var rc in rentContracts)
						{
							IterateThroughObjectFields(rc);
						}
						break;
					case 4:
						clients = await _service.GetAllAsync<Client>();
						Console.WriteLine("\t{0,-20}{1,-50}{2,-50}", "Id", "Name", "ClientType");
						foreach (var client in clients)
						{
							Console.WriteLine("\t{0,-20}{1,-50}{2,-50}", client.Id, client.Name, client.ClientType.Title);
						}
						Console.Write("Client id: ");
						var clientId = long.Parse(Console.ReadLine());
						rentContracts = (await _service.GetAllAsync<RentContract>()).Where(rc => rc.ClientId == clientId);
						foreach (var rc in rentContracts)
						{
							IterateThroughObjectFields(rc);
						}
						break;
					default:
						break;
				}
				Console.WriteLine(output);
				input = int.Parse(Console.ReadLine());
				Console.Clear();
			}
		}

		private async Task AddNewCarRecord()
		{
			var fuelType = await _service.GetAllAsync<FuelType>();
			var transmissionTypes = await _service.GetAllAsync<Transmission>();
			Console.Write("Model: ");
			var model = Console.ReadLine();

			Console.Write("Engine Details: ");
			var engine = Console.ReadLine();

			Console.Write("Color: ");
			var color = Console.ReadLine();

			Console.Write("Price/Day ($): ");
			var priceDay = int.Parse(Console.ReadLine());

			Console.Write("Back type: ");
			var back = Console.ReadLine();

			Console.WriteLine("Fuel: ");
			foreach (var fuel in fuelType)
			{
				Console.WriteLine($"Id - {fuel.Id} | Title: {fuel.Title}");
			}
			Console.Write("Enter fuelId: ");
			var fuelId = long.Parse(Console.ReadLine());

			Console.WriteLine("Transmission: ");
			foreach (var tr in transmissionTypes)
			{
				Console.WriteLine($"Id - {tr.Id} | Title: {tr.Title}");
			}
			Console.Write("Enter fuelId: ");
			var transmissionId = long.Parse(Console.ReadLine());


			var car = new Car
			{
				ModelName = model, EngineDetails = engine, PricePerDay = priceDay,
				Back = back, FuelTypeId = fuelId, Color = color, TransmissionId = transmissionId
			};

			try
			{
				await _service.AddAsync<Car>(car);
				Thread.Sleep(2000);
				Console.WriteLine("Car successfully added to database.");
				Thread.Sleep(1000);
			}
			catch (Exception)
			{
				Console.WriteLine("Some error happened.");
			}
		}

		private void IterateThroughObjectFields(object obj)
		{
			foreach (var propInfo in obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase))
			{
				if (!propInfo.GetGetMethod().IsVirtual)
				{
					Console.WriteLine("\t{0,-50}{1,-40}", propInfo.Name, propInfo.GetValue(obj));
				}
			}
			Console.WriteLine("\n");
		}

		private async Task OutputCars()
		{
			Console.WriteLine("\t\t\t\t\t\t\t\tCARS\n");
			Console.WriteLine("\t{0,-20}{1,-30}{2,-50}{3,-10}{4,-10}", "Car number", "Model", "Engine", "Transmission", "Price/Day ($)");
			var cars = await _service.GetAllAsync<Car>();
			foreach (var car in cars)
			{
				Console.WriteLine("\t{0,-20}{1,-30}{2,-50}{3,-20}{4,-10}", car.Id, car.ModelName, car.EngineDetails, car.Transmission.Title, car.PricePerDay);
			}
		}
	}
}
