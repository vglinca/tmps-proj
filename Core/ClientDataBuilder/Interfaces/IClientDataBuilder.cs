using Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ClientDataBuilder.Interfaces
{
	public interface IClientDataBuilder
	{
		IClientDataBuilder Name(string name);
		IClientDataBuilder ClientTypeId(ClientTypeId id);
		IClientDataBuilder Phone(string phone);
		IClientDataBuilder BirthDate(DateTime birthDate);
		IClientDataBuilder RentStartDate(DateTime startDate);
		IClientDataBuilder RentEndDate(DateTime endDate);
		IClientDataBuilder Iban(string iban);
		IClientDataBuilder CarId(long carId);
		IClientDataBuilder Idno(string idno);
		IClientDataBuilder DriverLicenseId(string driverLicenseId);
		IClientDataBuilder CompanyRegistrationDate(DateTime registrationDate);
		IClientDataBuilder CompanyAddress(string companyAddress);
		IClientDataBuilder UpperHouseExtractIdentifier(string upperHouseExtractIdentifier);
		IClientDataBuilder AdministrationPassportIdentifier(string administrationPassportIdentifier);
		IClientDataBuilder GeneralManagerSignatureIdentifier(string signature);
		IClientDataBuilder InternationalDriverLicenseId(string internationalDriverLicenseId);
		IClientDataBuilder PassportIdentifier(string passportIdentifier);
		IClientDataBuilder VisaIdentifier(string visaIdentifier);
		IClientDataBuilder MigrationNumber(string migrationNumber);
		IClientDataBuilder RentCost(int rentCost);
		ClientData Build();
	}
}
