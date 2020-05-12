using Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ClientDataBuilder
{
	public class ClientData
	{
		internal string Name;
		internal ClientTypeId ClientTypeId;
		internal string Phone;
		internal DateTime BirthDate;
		internal DateTime RentStartDate;
		internal DateTime RentEndDate;
		internal string Iban;
		internal long CarId;
		
		internal string Idno;
		internal string DriverLicenseId;
		
		internal DateTime CompanyRegistrationDate;
		internal string CompanyAddress;
		internal string UpperHouseExtractIdentifie;
		internal string AdministrationPassportIdentifier;
		internal string GeneralManagerSignatureIdentifier;
		
		internal string InternationalDriverLicenseId;
		internal string PassportIdentifier;
		internal string VisaIdentifier;
		internal string MigrationNumber;
	}
}
