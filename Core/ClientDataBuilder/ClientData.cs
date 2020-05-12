using Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ClientDataBuilder
{
	public class ClientData
	{
		public string Name;
		public ClientTypeId ClientTypeId;
		public string Phone;
		public DateTime BirthDate;
		public DateTime RentStartDate;
		public DateTime RentEndDate;
		public string Iban;
		public long CarId;

		public string Idno;
		public string DriverLicenseId;

		public DateTime CompanyRegistrationDate;
		public string CompanyAddress;
		public string UpperHouseExtractIdentifie;
		public string AdministrationPassportIdentifier;
		public string GeneralManagerSignatureIdentifier;

		public string InternationalDriverLicenseId;
		public string PassportIdentifier;
		public string VisaIdentifier;
		public string MigrationNumber;
	}
}
