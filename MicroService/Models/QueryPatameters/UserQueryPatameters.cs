using MicroService.Models.QueryPatameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroService.Models
{
    public class UserQueryPatameters:BaseParameter
    {
        public string Name { get; set; }
    }
}
