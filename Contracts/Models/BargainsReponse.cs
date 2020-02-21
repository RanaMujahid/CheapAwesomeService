using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts.Models
{

    public class BargainsReponse
    {
        public Hotel hotel { get; set; }
        public IList<Rate> rates { get; set; }
    }

    public class Rate
    {
        public string rateType { get; set; }
        public string boardType { get; set; }
        public decimal value { get; set; }
    }
}
