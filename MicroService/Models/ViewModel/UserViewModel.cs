using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroService.Models.ViewModel
{
    public class UserViewModel: ReturnViewModel<UserViewModel>
    {
        public Guid Gid { get; set; }
        public string Name { get; set; }
        public string Introduction { get; set; }
    }
}
