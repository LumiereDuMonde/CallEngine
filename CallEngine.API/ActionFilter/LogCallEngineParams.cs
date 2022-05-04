using CallEngine.DAL;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using CallEngine.Models;

namespace CallEngine.API.ActionFilter
{
	public class LogCallEngineParams : IAsyncActionFilter
	{
		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			var resultsContext = await next();
			var qs = resultsContext.HttpContext.Request.QueryString.ToString();			
			string form = String.Join("&", resultsContext.HttpContext.Request.Form.Select(p => p.Key + "=" + p.Value));
			string sid = resultsContext.HttpContext.Request.Form["CallSid"];
			var url = resultsContext.HttpContext.Request.Path;
			var repo = resultsContext.HttpContext.RequestServices.GetService<ICallRepository>();
			var item = new CallEngineParamsLog()
			{
				Form = form,
				QueryString = qs,
				Url = url,
				Sid = sid
			};
			repo.Add(item);
			await repo.SaveAll();
		}
	}
}
