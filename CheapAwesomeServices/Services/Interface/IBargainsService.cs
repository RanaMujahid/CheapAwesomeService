using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheapAwesomeServices.Services.Interface
{
    public interface IBargainsService
    {
        Task<IEnumerable<CheapAwsomeResponse>> GetBargains(RequestParams request);
    }
}
