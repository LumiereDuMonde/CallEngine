using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CallEngine.Core
{
	public static class Configure
	{
		public static void ConfigureServices(IServiceCollection services)
		{

			services
				.AddScoped<PlayActionResponse>()
				.AddScoped<RecordActionResponse>()
				.AddScoped<OperatorActionResponse>()
				.AddScoped<IActionResponse, PlayActionResponse>()
				.AddScoped<IEngagementService, EngagementService>();			
		}

	}
}
