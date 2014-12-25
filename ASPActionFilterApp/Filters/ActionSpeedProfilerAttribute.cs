using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPActionFilterApp.Filters
{
    //Where the Filter can be used
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)] 
    public class ActionSpeedProfilerAttribute : FilterAttribute, IActionFilter
    {
        private Stopwatch timer;
        public void OnExecuted(ActionExecutedContext filterContext)
        {
            //throw new NotImplementedException();
            timer.Stop();
            if (filterContext.Exception == null)
            {
                string div = string.Format(@"
                    <div style='position:absolute;
                     left:0px; top:0px;
                     width:300px; height:40px;
                     text-align:center;
                     background-color:#000000; color:#FFFFFF'>
                        Action method took: {0} seconds
                    </div>",
                timer.Elapsed.TotalSeconds.ToString("F6"));
                var response = filterContext.HttpContext.Response;

                if (response.ContentType == "text/html")
                {
                    response.Write(div);
                }
            }
        }
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //throw new NotImplementedException();
            timer = Stopwatch.StartNew();
        } 
    }
}