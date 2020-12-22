using MicroService.MiddleWares;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MicroService.Filters
{
    public class PerformanceFilter : ActionFilterAttribute
    { 
        public PerformanceFilter()
        {
        }
        Stopwatch sw = new Stopwatch();

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            sw.Start();
            base.OnActionExecuting(context);
        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            base.OnResultExecuted(context);
            sw.Stop();
            var elapsedSeconds = sw.ElapsedMilliseconds / 1000;

            //如果大于20秒，则认为该接口出问题了
            if (elapsedSeconds > 10)
            {
                var path = context.HttpContext.Request.Path.ToString();
                if (path.Contains("Error"))
                {
                    NoRespondinUrls.Add(path);
                }
            }
            //_logger.LogError($"地址：{path}，请求时间：{elapsedSeconds}秒");
        }
    }
}
