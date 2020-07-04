using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filters.Filters
{
    public class LastVisit : Attribute, IResourceFilter, IAsyncResourceFilter
    {
        private int Id { get; set; }
        private Logger _logger;

        public LastVisit(int id)
        {
            Id = id;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            //Will be exception becouse we already started our responce
            //context.HttpContext.Response.Cookies.Append("LastVisit", DateTime.UtcNow.ToString("dd/mm/yyyy  hh-mm-ss"));
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            //Now all good
            context.HttpContext.Response.Cookies.Append("LastVisit", DateTime.UtcNow.ToString("dd/mm/yyyy hh-mm-ss" + "sync"));
        }

        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            context.HttpContext.Response.Cookies.Append("LastVisit", DateTime.UtcNow.ToString("dd/mm/yyyy hh-mm-ss" + "sync"));
            await next();
        }
    }
}
