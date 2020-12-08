using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroService.Models.QueryPatameters
{
    public class BaseParameter
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 50;

    }
}
