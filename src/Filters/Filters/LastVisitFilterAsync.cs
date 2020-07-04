using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filters.Filters
{
    public class LastVisitFilterAsync : Attribute, IAsyncResourceFilter
    {
        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            //If we have to realization default use async filter
            context.HttpContext.Response.Cookies.Append("LastVisit", DateTime.UtcNow.ToString("dd/mm/yyyy hh-mm-ss"));
            await next();
        }
    }
}
