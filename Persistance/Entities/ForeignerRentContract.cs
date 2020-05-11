using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Entities
{
	public class ForeignerRentContract : RentContract
	{
		public string InternationalDriverLicenseId { get; set; }
		public string PassportIdentifier { get; set; }
		public string VisaIdentifier { get; set; }
		public string MigrationNumber { get; set; }
	}
}
