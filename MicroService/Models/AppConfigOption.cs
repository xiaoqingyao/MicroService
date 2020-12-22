using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroService.Models
{
    public class AppConfigOption
    {
        public const string DomainConfigNode = "APPConfig";
        //是否开启性能监控
        public bool OpenPerformanceMonitor { get; set; }
    }
}
