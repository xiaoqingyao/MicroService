using Consul;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroService.Consul
{
    public class ConsulRegister
    {
        private IConfiguration _configuration;
        private IHostApplicationLifetime _lifetime;
        public ConsulRegister(IConfiguration configuration, IHostApplicationLifetime lifetime)
        {
            this._configuration = configuration;
            this._lifetime = lifetime;
        }
        public void Regist()
        {

            String ip = _configuration["ip"];//部署到不同服务器的时候不能写成127.0.0.1或者0.0.0.0，因为这是让服务消费者调用的地址
            int port = int.Parse(_configuration["port"]);//获取服务端口 命令行参数
            Console.WriteLine($"http://{ip}:{port}/api/Health/index");
            var client = new ConsulClient(ConfigurationOverview); //回调获取
            string serverId = "ServerNameFirst-" + Guid.NewGuid();//服务编号保证不重复
            var result = client.Agent.ServiceRegister(new AgentServiceRegistration()
            {
                ID = serverId,
                Name = "BaseDataServer",//服务的名称
                Address = ip,//服务ip地址
                Port = port,//服务端口
                Check = new AgentServiceCheck //健康检查
                {
                    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),//服务启动多久后反注册
                    Interval = TimeSpan.FromSeconds(10),//健康检查时间间隔，或者称为心跳间隔（定时检查服务是否健康）
                    HTTP = $"http://{ip}:{port}/api/Health/Index",//健康检查地址
                    Timeout = TimeSpan.FromSeconds(5)//服务的注册时间
                }
            });
            _lifetime.ApplicationStopping.Register(() =>
            {
                Console.WriteLine($"服务停止{ip}:{port}");
                client.Agent.ServiceDeregister(serverId).Wait();
            });
        }
        private static void ConfigurationOverview(ConsulClientConfiguration obj)
        {
            //consul的地址
            obj.Address = new Uri("http://127.0.0.1:8500");
            //数据中心命名
            obj.Datacenter = "UserCenter";
        }
    }
}
