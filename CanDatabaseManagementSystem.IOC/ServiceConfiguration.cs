using CanDatabaseManagementSystem.DAL.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CanDatabaseManagementSystem.IOC
{
	public static class ServiceConfiguration
	{
		public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
		{
			ConfigureRepositories(services, configuration);
			ConfigureApplicationServices(services, configuration);
		}
		private static void ConfigureRepositories(IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<CanDatabaseContext>(options => options.UseSqlServer(
			configuration.GetConnectionString("CanDatabaseConnection")
			));
		}

		private static void ConfigureApplicationServices(IServiceCollection services, IConfiguration configuration)
		{
			
		}

	}
}
