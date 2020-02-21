    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts.Models
{

    public class CheapAwsomeResponse
    {
        public CheapAwsomeResponse()
        {
            ratesPerBoardType = new List<RatesPerBoardType>();
        }
        public Hotel hotel { get; set; }
        public IList<RatesPerBoardType> ratesPerBoardType { get; set; }
    }

    public class RatesPerBoardType
    {
        public string boardType { get; set; }
        public decimal value { get; set; }
    }
}
