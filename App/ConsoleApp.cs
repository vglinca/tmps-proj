using Core.ClientDataBuilder;
using Core.ContractCommand;
using Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App
{
	public class ConsoleApp
	{
		private readonly IRentCarService _service;
		public ConsoleApp(IRentCarService service)
		{
			_service = service;
		}

		public async Task RunAsync()
		{
			try
			{
				var command = new PhysicalPersonContractCommand(_service);
				var clientData = new ClientDataBuilder()
						.BirthDate(new DateTime(1998, 2, 17))
						.ClientTypeId(Persistance.Entities.ClientTypeId.PhysicalPerson)
						.Name("Vitaly Glinca")
						.Phone("12344555")
						.CarId(1)
						.Iban("rljgbr43tjg")
						.RentStartDate(new DateTime(2020, 5, 17))
						.RentEndDate(new DateTime(2020, 5, 22))
						.Idno("ih484y3f3h4g932fh393h39f")
						.DriverLicenseId("12333200")
						.Build();
				await command.Execute(clientData);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
