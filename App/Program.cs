using AutoMapper;
using Core.ClientDataBuilder;
using Core.ContractCommand;
using Core.Services;
using Core.Services.Interfaces;
using Core.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Context;
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
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			services.AddDbContext<RentCarDbContext>();
			services.AddTransient<Repository>();
			services.AddTransient<RentCarService>();
			services.AddTransient<Resolver.ServiceResolver>(provider => key =>
			{
				switch (key)
				{
					case ServiceType.Repository:
						return provider.GetService<Repository>();
					case ServiceType.RentCarService:
						return provider.GetService<RentCarService>();
					default:
						return null;
				}
			});
			services.AddTransient<ConsoleApp>();

			return services.BuildServiceProvider();
		}
	}
}
