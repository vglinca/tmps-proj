using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Entities
{
	public class ClientType
	{
		public ClientTypeId ClientTypeId { get; set; }
		public string Title { get; set; }
		public virtual ICollection<Client> Clients { get; set; }
	}
}
