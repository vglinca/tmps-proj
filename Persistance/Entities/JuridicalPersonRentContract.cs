using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Entities
{
	public class JuridicalPersonRentContract : RentContract
	{
		public DateTime CompanyRegistrationDate { get; set; }//chosen by client
		public string CompanyAddress { get; set; }//chosen by client
		public string UpperHouseExtractIdentifier { get; set; } //Выписка Государственной регистрационной палаты;
		public string AdministrationPassportIdentifier { get; set; }//chosen by client
		public string DriverLicenseIdentifier { get; set; }//chosen by client
		public string GeneralManagerSignatureIdentifier { get; set; }//chosen by client
	}
}
