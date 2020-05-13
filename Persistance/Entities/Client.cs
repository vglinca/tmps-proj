using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Entities
{
	public class Client : BaseEntity
	{
		public string Name { get; set; }//chosen by client
		public ClientTypeId ClientTypeId { get; set; }
		public virtual ClientType ClientType { get; set; }//chosen by client
		public string Phone { get; set; }//chosen by client
		public DateTime BirthDate { get; set; }//chosen by client
		public virtual ICollection<RentContract> RentContracts { get; set; }
	}
}
