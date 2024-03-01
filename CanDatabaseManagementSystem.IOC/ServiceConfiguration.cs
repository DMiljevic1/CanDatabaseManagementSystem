﻿using CanDatabaseManagementSystem.Contract;
using CanDatabaseManagementSystem.DAL.DatabaseContext;
using CanDatabaseManagementSystem.DAL.Repositories;
using DomainModels.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CanDatabaseManagementSystem.Service;
using AutoMapper;
using CanDatabaseManagementSystem.Service.Mapping;

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
			services.AddScoped<IDbcFileRepository, DbcFileRepository>();
		}

		private static void ConfigureApplicationServices(IServiceCollection services, IConfiguration configuration)
		{
			var mappingConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new DbcFileProfile());
			});
			services.AddSingleton(mappingConfig.CreateMapper());
			services.AddScoped<IDbcFileService, DbcFileService>();
		}
		public static void ApplyMigrations(this IApplicationBuilder app)
		{
			using IServiceScope scope = app.ApplicationServices.CreateScope();
			using CanDatabaseContext dbContext = scope.ServiceProvider.GetRequiredService<CanDatabaseContext>();

			dbContext.Database.Migrate();
		}
	}
}
