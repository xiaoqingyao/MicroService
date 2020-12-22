using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroService.MiddleWares
{
    public static class NoRespondinUrls
    {
        public static void Add(string Url)
        {
            Dic.Add(Url);
        }
        public static bool IsNoRespondUrl(string Url)
        {
            return Dic.Contains(Url);
        }
        public static List<string> Dic { get; set; } = new List<string>();
    }
}
