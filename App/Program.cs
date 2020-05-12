using Core.ClientDataBuilder;
using Core.ContractCommand;
using Core.Services;
using Core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Context;
using Persistance.Repository;
using Persistance.Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace App
{
	class Program
	{
		static async Task Main(string[] args)
		{
			var services = new ServiceCollection();
			var serviceProvider = ConfigureServices(services);

			await serviceProvider.GetService<ConsoleApp>().RunAsync();
		}

		private static IServiceProvider ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<RentCarDbContext>();
			services.AddScoped<IRepository, Repository>();
			services.AddTransient<IRentCarService, RentCarService>();
			services.AddTransient<ConsoleApp>();

			return services.BuildServiceProvider();
		}
	}
}
