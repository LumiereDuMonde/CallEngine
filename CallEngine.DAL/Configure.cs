using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CallEngine.DAL
{
	public static class Configure
	{
		public static void ConfigureServices(IServiceCollection services, string connectionString)
		{
			//Context lifetime defaults to "scoped"
			services
				 .AddDbContext<CallAppContext>(options => options.UseSqlServer(connectionString));

			services.BuildServiceProvider().GetService<CallAppContext>().Database.Migrate();
			services
				.AddScoped<IAuthRepository, AuthRepository>()
				.AddScoped<ICallRepository, CallRepository>()
				.AddScoped<IUserRepository, UsersRepository>();
		}
	}
}
