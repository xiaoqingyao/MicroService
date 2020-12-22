using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroService.MiddleWares
{
    public static class CustomGateway
    {
        public static IApplicationBuilder UseGateway(this IApplicationBuilder app)
        {
            app.MapWhen(context =>
            {
                var url = context.Request.HttpContext.Request.Path.ToString();
                return NoRespondinUrls.IsNoRespondUrl(url);
            }, (_app) =>
            {
                _app.Use(async (context, next) =>
                {
                    context.Response.StatusCode = 500;
                    await next.Invoke();
                });
            });
            return app;
        }
    }
}
