using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Consul;
using LinqToDB.Configuration;
using LinqToDB.Data;
using MicroService.AutoMapper;
using MicroService.Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MicroService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperConfig).Assembly);
            services.AddControllers();
            //注册数据库上下文
            services.AddDbContext<SQLDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Main_ReadAndWrite"));
            }, ServiceLifetime.Scoped);

            //使用swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "CoreWebApi", Version = "v1", Description = "CoreWebApi_Description" });

                var basePath = AppDomain.CurrentDomain.BaseDirectory;
                foreach (var name in Directory.GetFiles(basePath, "*.xml", SearchOption.AllDirectories))
                {
                    c.IncludeXmlComments(name);
                }
            });
            //linq2db
            DataConnection.DefaultSettings = new Linq2Sqls.MySettings();
            //var builder = new LinqToDbConnectionOptionsBuilder();
            //builder.UseSqlServer(Configuration.GetConnectionString("Main_ReadAndWrite"));
            //var dc = new DataConnection(builder.Build());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime lifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(p =>
            {
                p.SwaggerEndpoint("/swagger/v1/swagger.json", "CoreWebApi V1");
            });

            //调用注册类
            //new ConsulRegister(Configuration, lifetime).Regist();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
