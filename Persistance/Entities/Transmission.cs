using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Entities
{
	public class Transmission
	{
		public TransmissionTypeId TransmissionTypeId { get; set; }
		public string Title { get; set; }
		public virtual ICollection<Car> Cars { get; set; }
	}
}
