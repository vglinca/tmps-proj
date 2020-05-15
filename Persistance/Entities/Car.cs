using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Entities
{
	public class Car : BaseEntity
	{
		public string ModelName { get; set; }
		public int PricePerDay { get; set; }
		public string EngineDetails { get; set; }
		public long FuelTypeId { get; set; }
		public virtual FuelType FuelType { get; set; }
		public string Color { get; set; }
		public string Back { get; set; }
		public long TransmissionId { get; set; }
		public virtual Transmission Transmission { get; set; }
		public virtual ICollection<RentContract> RentContracts { get; set; }
	}
}
