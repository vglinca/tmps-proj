using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Entities
{
	public class ForeignerRentContract : RentContract
	{
		public string InternationalDriverLicenseId { get; set; }//chosen by client
		public string PassportIdentifier { get; set; }//chosen by client
		public string VisaIdentifier { get; set; }//chosen by client
		public string MigrationNumber { get; set; }//chosen by client
	}
}
