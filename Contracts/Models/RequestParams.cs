using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts.Models
{
    public class RequestParams
    {
        public int DestinationId { get; set; }
        public int Nights { get; set; }
        public string Code { get; set; }
    }
}
