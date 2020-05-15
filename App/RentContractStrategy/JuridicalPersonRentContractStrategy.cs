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
		{
		}

		

		public override async Task GatherContractInfo()
		{
			Console.WriteLine("Enter company name: ");
			var company = Console.ReadLine();

			Console.WriteLine("Enter company address: ");
			var address = Console.ReadLine();

			Console.WriteLine("Enter company registration date: ");
			DateTime regDate = DateTime.UtcNow;
			while (!DateTime.TryParse(Console.ReadLine(), out regDate))
			{
				Console.WriteLine("Wrong date format. Enter again: ");
			}

			Console.WriteLine("Present Upper House Extract Document: ");
			var upperHouseExtractIdentifier = Console.ReadLine();

			Console.WriteLine("Show administration card: ");
			var card = Console.ReadLine();

			Console.WriteLine("Present driver license: ");
			var driverLicense = Console.ReadLine();

			Console.WriteLine("Present Genreal Manager Approvement: ");
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
				var total = car.PricePerDay * (int) ((startDate - endDate).TotalDays);
				total = CalculateDiscount(total, (int)(startDate - endDate).TotalDays);

				Console.WriteLine($"Total: ${total}");
				Console.WriteLine();
				Console.WriteLine("Enter bank account: ");
				var iban = Console.ReadLine();

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

				await _command.Execute(clientData);
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
				total -= (int) (total * 0.03);
			}
			else if(days < 20 && days < 31 && total > 3000)
			{
				total -= (int) (total * 0.05);
			}
			else if(days >= 31)
			{
				total -= (int) (total * 0.08);
			}
			return total;
		}
	}
}
