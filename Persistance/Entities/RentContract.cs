using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Entities
{
	public abstract class RentContract : BaseEntity
	{
		public long ClientId { get; set; }
		public Client Client { get; set; }
		public DateTime RentStartDate { get; set; }//chosen by client
		public DateTime RentEndDate { get; set; }////chosen by client
		public string Iban { get; set; }//chosen by client
		public int RentCost { get; set; }
		public long CarId { get; set; }//chosen by client
		public Car Car { get; set; }
	}
}
