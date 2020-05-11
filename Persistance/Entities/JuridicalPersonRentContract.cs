using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Entities
{
	public class JuridicalPersonRentContract : RentContract
	{
		public DateTime CompanyRegistrationDate { get; set; }
		public string CompanyAddress { get; set; }
		public string UpperHouseExtractIdentifier { get; set; } //Выписка Государственной регистрационной палаты;
		public string AdministrationPassportIdentifier { get; set; }
		public string DriverLicenseIdentifier { get; set; }
		public string GeneralManagerSignatureIdentifier { get; set; }
	}
}
