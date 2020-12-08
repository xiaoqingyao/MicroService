using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Consul;

namespace Client
{
    class Program
    {
        static List<string> Urls = new List<string>();
        static void Main(string[] args)
        {
            Console.WriteLine("开始输出当前所有服务地址");
            Catalog_Nodes().GetAwaiter().GetResult();

            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine("开始随机请求一个地址服务地址");
                int index = new Random().Next(Urls.Count);
                string url = Urls[index];

                Console.WriteLine("请求的随机地址：" + url);
                var result = new HttpClient().GetAsync(url).Result;
                Console.WriteLine($"{result.StatusCode}:{result.Content.ReadAsStringAsync().Result}");
            }
           
            Console.ReadLine();
        }
        public static async Task Catalog_Nodes()
        {
            var client = new ConsulClient();
            var nodeList = await client.Agent.Services();
            var url = nodeList.Response.Values;

            foreach (var item in url)
            {
                string Address = item.Address;
                int port = item.Port;
                string name = item.Service;
                Console.WriteLine($"地址：{Address}:{port},name：{name}");
                Urls.Add($"http://{Address}:{port}/api/Users/GetList");
            }
        }
    }
}
