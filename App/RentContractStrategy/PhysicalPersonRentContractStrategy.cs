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
			var clientDataBuilder = new ClientDataBuilder();

			Console.Write("Your birth date: ");
			var birthDate = Console.ReadLine();

			Console.Write("Your full name: ");
			var fullName = Console.ReadLine();

			Console.Write("Your mobile phone: ");
			var phone = Console.ReadLine();

			Console.Write("Chosen car number: ");
			var carId = long.Parse(Console.ReadLine());

			Console.Write("Enter your iban: ");
			var iban = Console.ReadLine();

			Console.WriteLine("Enter your idno: ");
			var idno = Console.ReadLine();

			Console.Write("When do You want to take a car? ");
			var startDate = Console.ReadLine();

			Console.Write("What is the end date of rent? ");
			var endDate = Console.ReadLine();

			Console.Write("Present your driver license, please: ");
			var driverLicenseId = Console.ReadLine();

			var clientData = new ClientDataBuilder()
						.BirthDate(DateTime.Parse(birthDate))
						.ClientTypeId(ClientTypeId.PhysicalPerson)
						.Name(fullName)
						.Phone(phone)
						.CarId(carId)
						.Iban(iban)
						.RentStartDate(DateTime.Parse(startDate))
						.RentEndDate(DateTime.Parse(endDate))
						.Idno(idno)
						.DriverLicenseId(driverLicenseId)
						.Build();

			await _command.Execute(clientData);
		}
	}
}
