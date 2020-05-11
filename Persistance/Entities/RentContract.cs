using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Entities
{
	public abstract class RentContract : BaseEntity
	{
		public long ClientId { get; set; }
		public Client Client { get; set; }
		public DateTime RentStartDate { get; set; }
		public DateTime RentEndDate { get; set; }
		public string Iban { get; set; }
		public int RentCost { get; set; }
		public long CarId { get; set; }
		public Car Car { get; set; }
	}
}
