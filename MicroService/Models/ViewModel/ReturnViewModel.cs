using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroService.Models.ViewModel
{
    public class ReturnViewModel<T>
    {
        public int TotalCount { get; set; }
        public EReturnCode ReturnCode { get; set; }
        public string ReturnMessage { get; set; }
        public List<T> Records { get; set; }
    }
    public enum EReturnCode
    {
        Success,
        Failed,
        Error
    }
}
