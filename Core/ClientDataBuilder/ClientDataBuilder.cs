using Core.ClientDataBuilder.Interfaces;
using Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ClientDataBuilder
{
	public class ClientDataBuilder : IClientDataBuilder
	{
		private ClientData _clientData;
		public IClientDataBuilder AdministrationPassportIdentifier(string administrationPassportIdentifier)
		{
			_clientData.AdministrationPassportIdentifier = administrationPassportIdentifier;
			return this;
		}

		public IClientDataBuilder BirthDate(DateTime birthDate)
		{
			_clientData.BirthDate = birthDate;
			return this;
		}

		public IClientDataBuilder CarId(long carId)
		{
			_clientData.CarId = carId;
			return this;
		}

		public IClientDataBuilder ClientTypeId(ClientTypeId id)
		{
			_clientData.ClientTypeId = id;
			return this;
		}

		public IClientDataBuilder CompanyAddress(string companyAddress)
		{
			_clientData.CompanyAddress = companyAddress;
			return this;
		}

		public IClientDataBuilder CompanyRegistrationDate(DateTime registrationDate)
		{
			_clientData.CompanyRegistrationDate = registrationDate;
			return this;
		}

		public IClientDataBuilder DriverLicenseId(string driverLicenseId)
		{
			_clientData.DriverLicenseId = driverLicenseId;
			return this;
		}

		public IClientDataBuilder GeneralManagerSignatureIdentifier(string signature)
		{
			_clientData.GeneralManagerSignatureIdentifier = signature;
			return this;
		}

		public IClientDataBuilder Iban(string iban)
		{
			_clientData.Iban = iban;
			return this;
		}

		public IClientDataBuilder Idno(string idno)
		{
			_clientData.Idno = idno;
			return this;
		}

		public IClientDataBuilder InternationalDriverLicenseId(string internationalDriverLicenseId)
		{
			_clientData.InternationalDriverLicenseId = internationalDriverLicenseId;
			return this;
		}

		public IClientDataBuilder MigrationNumber(string migrationNumber)
		{
			_clientData.MigrationNumber = migrationNumber;
			return this;
		}

		public IClientDataBuilder Name(string name)
		{
			_clientData.Name = name;
			return this;
		}

		public IClientDataBuilder PassportIdentifier(string passportIdentifier)
		{
			_clientData.PassportIdentifier = passportIdentifier;
			return this;
		}

		public IClientDataBuilder Phone(string phone)
		{
			_clientData.Phone = phone;
			return this;
		}

		public IClientDataBuilder RentEndDate(DateTime endDate)
		{
			_clientData.RentEndDate = endDate;
			return this;
		}

		public IClientDataBuilder RentStartDate(DateTime startDate)
		{
			_clientData.RentStartDate = startDate;
			return this;
		}

		public IClientDataBuilder UpperHouseExtractIdentifier(string upperHouseExtractIdentifier)
		{
			_clientData.UpperHouseExtractIdentifie = upperHouseExtractIdentifier;
			return this;
		}

		public IClientDataBuilder VisaIdentifier(string visaIdentifier)
		{
			_clientData.VisaIdentifier = visaIdentifier;
			return this;
		}

		public ClientData Build()
		{
			return _clientData;
		}
	}
}
