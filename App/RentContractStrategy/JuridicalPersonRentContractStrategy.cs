using App.RentContractStrategy.Interfaces;
using Core.ClientDataBuilder;
using Core.ContractCommand;
using Core.Exceptions;
using Core.Services.Interfaces;
using Persistance.Entities;
using System;
using System.Threading.Tasks;

namespace App.RentContractStrategy
{
	public class JuridicalPersonRentContractStrategy : RentContractCreationStrategyBase
	{
		public JuridicalPersonRentContractStrategy(CreateContractCommandBase command, IRepositoryService service) : base(command, service)
		{}
		
		public override async Task GatherContractInfo()
		{
			Console.Write("Enter company name: ");
			var company = Console.ReadLine();

			Console.Write("Enter company address: ");
			var address = Console.ReadLine();

			Console.Write("Enter company registration date: ");
			DateTime regDate = DateTime.UtcNow;
			while (!DateTime.TryParse(Console.ReadLine(), out regDate))
			{
				Console.WriteLine("Wrong date format. Enter again: ");
			}

			Console.Write("Present Upper House Extract Document: ");
			var upperHouseExtractIdentifier = Console.ReadLine();

			Console.Write("Show administration card: ");
			var card = Console.ReadLine();

			Console.Write("Present driver license: ");
			var driverLicense = Console.ReadLine();

			Console.Write("Present Genreal Manager Approvement: ");
			var signature = Console.ReadLine();

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
				var total = car.PricePerDay * (int) ((endDate - startDate).TotalDays);

				total = CalculateDiscount(total, (int)(endDate - startDate).TotalDays);

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
						Console.Write("Enter debit card number: ");
						var iban = Console.ReadLine();

						Console.WriteLine();
						var clientData = new ClientDataBuilder()
							.ClientTypeId(ClientTypeId.JuridicalPerson)
							.Name(company)
							.CompanyAddress(address)
							.CompanyRegistrationDate(regDate)
							.UpperHouseExtractIdentifier(upperHouseExtractIdentifier)
							.AdministrationPassportIdentifier(card)
							.DriverLicenseId(driverLicense)
							.GeneralManagerSignatureIdentifier(signature)
							.RentStartDate(startDate)
							.RentEndDate(endDate)
							.CarId(carId)
							.Iban(iban)
							.RentCost(total)
							.Build();

						var color = Console.ForegroundColor;
						try
						{
							var rentContract = (JuridicalPersonRentContract)await _command.Execute(clientData);
							Console.ForegroundColor = ConsoleColor.Green;
							Console.WriteLine("Request has been successfully confirmed.....");
							Console.WriteLine();
							Console.ForegroundColor = color;
							Console.WriteLine("\t\t\tCONTRACT DETAILS");
							Console.WriteLine();
							Console.ForegroundColor = ConsoleColor.DarkCyan;
							Console.WriteLine($"Company: {rentContract.Client.Name}");
							Console.WriteLine($"Registered on {rentContract.CompanyRegistrationDate.ToShortDateString()}");
							Console.WriteLine($"Rent from {rentContract.RentStartDate.ToShortDateString()} to {rentContract.RentEndDate.ToShortDateString()}");
							Console.WriteLine($"Auto: {rentContract.Car.ModelName}");
							Console.WriteLine($"\t\tTotal: ${rentContract.RentCost}");
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
			catch (EntityNotFoundException ex)
			{

				throw;
			}
			
		}

		public override int CalculateDiscount(int total , int days)
		{
			if(days > 20 && days < 31 && total < 3000)
			{
				Console.WriteLine("We offer a 3% discount.");
				total -= (int) (total * 0.03);
			}
			else if(days < 20 && days < 31 && total > 3000)
			{
				Console.WriteLine("We offer a 5% discount.");
				total -= (int) (total * 0.05);
			}
			else if(days >= 31)
			{
				Console.WriteLine("We offer a 8% discount.");
				total -= (int) (total * 0.08);
			}
			return total;
		}
	}
}
