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
	public class ForeignPersonRentContractStrategy : RentContractCreationStrategyBase
	{
		public ForeignPersonRentContractStrategy(CreateContractCommandBase command, IRepositoryService service) : base(command, service)
		{
		}

		public override async Task GatherContractInfo()
		{
			Console.Write("Your full name: ");
			var fullName = Console.ReadLine();

			Console.WriteLine("Present your passport: ");
			var passportId = Console.ReadLine();

			Console.WriteLine("Present visa: ");
			var visaId = Console.ReadLine();

			Console.WriteLine("Present migration card: ");
			var migrationNumber = Console.ReadLine();

			Console.WriteLine("Present International Driver License: ");
			var driverLicenseId = Console.ReadLine();

			Console.Write("Chosen car number: ");
			var carId = long.Parse(Console.ReadLine());

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

			try
			{
				var car = await _service.GetByIdAsync<Car>(carId);
				var total = car.PricePerDay * (int) ((startDate - endDate).TotalDays);

				total = CalculateDiscount(total, (int) ((startDate - endDate).TotalDays));

				Console.WriteLine($"Total: ${total}");
				Console.WriteLine();
				Console.WriteLine("Proceed? \n1 - Yes\n2 - No");
				int yesNo = default;

				while (!int.TryParse(Console.ReadLine(), out yesNo))
				{
					Console.WriteLine("Enter correct value.");
				}
				switch (yesNo)
				{
					case 1:
						Console.WriteLine("Enter card number: ");
						var iban = Console.ReadLine();

						Console.WriteLine();
						var clientData = new ClientDataBuilder()
							.ClientTypeId(ClientTypeId.Foreigner)
							.Name(fullName)
							.PassportIdentifier(passportId)
							.VisaIdentifier(visaId)
							.MigrationNumber(migrationNumber)
							.CarId(carId)
							.Iban(iban)
							.RentStartDate(startDate)
							.RentEndDate(endDate)
							.DriverLicenseId(driverLicenseId)
							.RentCost(total)
							.Build();

						var color = Console.ForegroundColor;
						try
						{
							await _command.Execute(clientData);
							Console.ForegroundColor = ConsoleColor.Green;
							Console.WriteLine("Request has been successfully confirmed.....");
						}
						catch (Exception)
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("An error occured during transaction....");
							throw;
						}
						finally
						{
							Console.ForegroundColor = color;
						}
						break;
					case 2:
						Environment.Exit(0);
						break;
					default:
						break;
				}
			}
			catch (Exception)
			{

				throw;
			}
		}

		public override int CalculateDiscount(int total, int days)
		{
			return total;
		}
	}
}
