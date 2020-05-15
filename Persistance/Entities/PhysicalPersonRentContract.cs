using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Entities
{
	public class PhysicalPersonRentContract : RentContract
	{
		public string Phone { get; set; }//chosen by client
		public DateTime BirthDate { get; set; }//chosen by client
		public string Idno { get; set; }//chosen by client
		public string DriverLicenseId { get; set; }//chosen by client
	}
}
