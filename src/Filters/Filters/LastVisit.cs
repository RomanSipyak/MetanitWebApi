using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filters.Filters
{
    public class LastVisit : Attribute, IResourceFilter
    {
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
    }
}
