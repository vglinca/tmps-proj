using App.RentContractStrategy.Interfaces;
using Core.ContractCommand;
using Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Core.Utils.Resolver;

namespace App.RentContractStrategy
{
	public class JuridicalPersonRentContractStrategy : RentContractCreationStrategyBase
	{
		public JuridicalPersonRentContractStrategy(CreateContractCommandBase command, IRepositoryService service) : base(command, service)
		{
		}
		public override async Task GatherContractInfo()
		{
		}
	}
}
