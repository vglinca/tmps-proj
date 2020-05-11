using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Entities
{
	public class Client : BaseEntity
	{
		public string Name { get; set; }
		public ClientTypeId ClientTypeId { get; set; }
		public ClientType ClientType { get; set; }
		public string Phone { get; set; }
		public DateTime BirthDate { get; set; }
		public virtual ICollection<RentContract> RentContracts { get; set; }
	}
}
