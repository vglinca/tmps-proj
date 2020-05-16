using App.RentContractStrategy.Interfaces;
using Core.ClientDataBuilder;
using Core.ContractCommand;
using Core.ErrorDecorator;
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
			DateTime birthDate = DateTime.Now;
			while (!DateTime.TryParse(Console.ReadLine(), out birthDate))
			{
				Console.WriteLine("Wrong date format. Enter again: ");
			}

			TimeSpan diff = DateTime.UtcNow - birthDate;
			int years = (new DateTime(1, 1, 1) + diff).Year - 1;
			if(years < 18)
			{
				_commonError = new DateTimeErrorDecorator(new CommonError("\nAn error happened."), "\nPerson must be older than 18.");
			}
			
			Console.Write("Your full name: ");
			var fullName = Console.ReadLine();

			Console.Write("Your mobile phone: ");
			var phone = Console.ReadLine();

			Console.Write("Chosen car number: ");
			var carId = long.Parse(Console.ReadLine());

			Console.WriteLine("Enter your idno: ");
			var idno = Console.ReadLine();

			Console.Write("When do You want to take a car? ");
			DateTime startDate = DateTime.Now;
			while (!DateTime.TryParse(Console.ReadLine(), out startDate))
			{
				Console.WriteLine("Wrong date format. Enter again: ");
			}
			if(startDate < DateTime.Now)
			{
				if(_commonError != null)
				{
					_commonError = new DateTimeErrorDecorator(_commonError, $"\nStart date must be a valid date. {startDate} has been entered.");
				}
				else
				{
					_commonError = new DateTimeErrorDecorator(new CommonError("\nAn error happened."), $"\nStart date must be a valid date. {startDate} has been entered.");
				}
			}

			Console.Write("What is the end date of rent? ");
			DateTime endDate = DateTime.Now;
			while (!DateTime.TryParse(Console.ReadLine(), out endDate))
			{
				Console.WriteLine("Wrong date format. Enter again: ");
			}

			if(endDate < DateTime.Now)
			{
				if (_commonError != null)
				{
					_commonError = new DateTimeErrorDecorator(_commonError, $"\nEnding date must be a valid date. {endDate} has been entered.");
				}
				else
				{
					_commonError = new DateTimeErrorDecorator(new CommonError("\nAn error happened."), $"\nEnding date must be a valid date. {endDate} has been entered.");
				}
			}

			Console.Write("Present your driver license, please: ");
			var driverLicenseId = Console.ReadLine();

			try
			{
				if(_commonError != null)
				{
					throw new Exception();
				}

				var car = await _service.GetByIdAsync<Car>(carId);
				var total = car.PricePerDay * (int) ((startDate - endDate).TotalDays);

				total = CalculateDiscount(total, (int) ((startDate - endDate).TotalDays));

				Console.WriteLine($"Total: ${total}");
				Console.WriteLine();
				Console.WriteLine("Proceed? \n1 - Yes\n2 - No");
				int yesNo = default;

				while(! int.TryParse(Console.ReadLine(), out yesNo))
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
							.BirthDate(birthDate)
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
				if(_commonError != null)
				{
					var color = Console.ForegroundColor;
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine(_commonError.ShowErrorMessage());
					Console.ForegroundColor = color;
					Environment.Exit(0);
				}
			}
		}

		public override int CalculateDiscount(int total, int days)
		{
			if(days < 10)
			{
				return total;
			}
			else if (days > 10 && days < 31 && total > 3000)
			{
				Console.WriteLine("We offer a 5% discount.");
				total -= (int) (total * 0.05);
			}
			else if(days >= 31)
			{
				Console.WriteLine("We offer a 10% discount.");
				total -= (int) (total * 0.1);
			}
			return total;
		}
	}
}
