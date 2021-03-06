﻿using App.RentContractStrategy.Interfaces;
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
	public class ForeignPersonRentContractStrategy : RentContractCreationStrategyBase
	{
		public ForeignPersonRentContractStrategy(CreateContractCommandBase command, IRepositoryService service) : base(command, service)
		{
		}

		public override async Task GatherContractInfo()
		{
			Console.Write("Your full name: ");
			var fullName = Console.ReadLine();

			Console.Write("Present your passport: ");
			var passportId = Console.ReadLine();

			Console.Write("Present visa: ");
			var visaId = Console.ReadLine();

			Console.Write("Present migration card: ");
			var migrationNumber = Console.ReadLine();

			Console.Write("Present International Driver License: ");
			var driverLicenseId = Console.ReadLine();

			Console.Write("Chosen car number: ");
			var carId = long.Parse(Console.ReadLine());

			Console.Write("When do You want to take a car? ");
			DateTime startDate = DateTime.UtcNow;
			while (!DateTime.TryParse(Console.ReadLine(), out startDate))
			{
				Console.WriteLine("Wrong date format. Enter again: ");
			}
			if (startDate < DateTime.Now)
			{
				if (_commonError != null)
				{
					_commonError = new DateTimeErrorDecorator(_commonError, $"\nStart date must be a valid date. {startDate} has been entered.");
				}
				else
				{
					_commonError = new DateTimeErrorDecorator(new CommonError("\nAn error happened."), $"\nStart date must be a valid date. {startDate} has been entered.");
				}
			}

			Console.Write("What is the end date of rent? ");
			DateTime endDate = DateTime.UtcNow;
			while (!DateTime.TryParse(Console.ReadLine(), out endDate))
			{
				Console.WriteLine("Wrong date format. Enter again: ");
			}
			if (endDate < DateTime.Now || endDate < startDate)
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

			try
			{
				if (_commonError != null)
				{
					throw new Exception();
				}
				var car = await _service.GetByIdAsync<Car>(carId);
				if (car == null)
				{
					_commonError = new NotFoundErrorDecorator(_commonError, $"\nEntered car number is wrong. Car with number {carId} doesn't exist.");
				}

				var total = car.PricePerDay * (int) ((endDate- startDate).TotalDays);

				total = CalculateDiscount(total, (int) ((endDate - startDate).TotalDays));

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
						Console.Write("Enter card number: ");
						var iban = Console.ReadLine();

						if (iban.Length != 16)
						{
							_commonError = new InvalidCardNumberErrorDecorator(_commonError, "\nInvalid card number was entered. Card number must contain 16 numbers.");
							throw new Exception();
						}

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
							var rentContract = (ForeignerRentContract)await _command.Execute(clientData);
							Console.ForegroundColor = ConsoleColor.Green;
							Console.WriteLine("Request has been successfully confirmed.....");
							Console.WriteLine();
							Console.ForegroundColor = color;
							Console.WriteLine("\t\t\tCONTRACT DETAILS");
							Console.WriteLine();
							Console.ForegroundColor = ConsoleColor.DarkCyan;
							Console.WriteLine($"Client name: {rentContract.Client.Name}");
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
			catch (Exception)
			{
				if (_commonError != null)
				{
					var color = Console.ForegroundColor;
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine(_commonError.ShowErrorMessage());
					Console.ForegroundColor = color;
					Environment.Exit(0);
				}
				else
				{
					Console.WriteLine("An unexpected fault happened.");
				}
			}
		}

		public override int CalculateDiscount(int total, int days)
		{
			return total;
		}
	}
}
