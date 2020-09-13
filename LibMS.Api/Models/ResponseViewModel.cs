using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibMS.Api.Models
{
    public class ResponseViewModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
    }
}
