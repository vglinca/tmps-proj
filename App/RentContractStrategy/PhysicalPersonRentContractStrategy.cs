using App.RentContractStrategy.Interfaces;
using Core.ClientDataBuilder;
using Core.ContractCommand;
using Core.Services.Interfaces;
using Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Core.Utils.Resolver;

namespace App.RentContractStrategy
{
	public class PhysicalPersonRentContractStrategy : RentContractCreationStrategyBase
	{
		public PhysicalPersonRentContractStrategy(CreateContractCommandBase command, IRepositoryService service) : base(command, service)
		{}

		

		public override async Task GatherContractInfo()
		{
			Console.Write("Your birth date: ");
			var birthDate = Console.ReadLine();

			Console.Write("Your full name: ");
			var fullName = Console.ReadLine();

			Console.Write("Your mobile phone: ");
			var phone = Console.ReadLine();

			Console.Write("Chosen car number: ");
			var carId = long.Parse(Console.ReadLine());

			Console.WriteLine("Enter your idno: ");
			var idno = Console.ReadLine();

			Console.Write("When do You want to take a car? ");
			DateTime startDate = DateTime.UtcNow;
			while (!DateTime.TryParse(Console.ReadLine(), out startDate))
			{
				Console.WriteLine("Wrong date format. Enter again: ");
			}

			Console.Write("What is the end date of rent? ");
			DateTime endDate = DateTime.UtcNow;
			while (!DateTime.TryParse(Console.ReadLine(), out endDate))
			{
				Console.WriteLine("Wrong date format. Enter again: ");
			}

			Console.Write("Present your driver license, please: ");
			var driverLicenseId = Console.ReadLine();

			try
			{
				var car = await _service.GetByIdAsync<Car>(carId);
				var total = car.PricePerDay * (int) ((startDate - endDate).TotalDays);

				Console.WriteLine($"Total: ${total}");
				Console.WriteLine();
				Console.WriteLine("Proceed? \n1 - Yes\n2 - No");
				int yesNo = default;
				while(! int.TryParse(Console.ReadLine(), out yesNo))
				{
					Console.WriteLine("Enter correct value.");
				}

				Console.WriteLine("Enter card number: ");
				var iban = Console.ReadLine();

				Console.WriteLine();

				var clientData = new ClientDataBuilder()
							.BirthDate(DateTime.Parse(birthDate))
							.ClientTypeId(ClientTypeId.PhysicalPerson)
							.Name(fullName)
							.Phone(phone)
							.CarId(carId)
							.Iban(iban)
							.RentStartDate(startDate)
							.RentEndDate(endDate)
							.Idno(idno)
							.DriverLicenseId(driverLicenseId)
							.RentCost(total)
							.Build();

				await _command.Execute(clientData);
			}
			catch (Exception)
			{

				throw;
			}

			
		}

		public override int CalculateDiscount(int total, int days)
		{
			return 0;
		}
	}
}
