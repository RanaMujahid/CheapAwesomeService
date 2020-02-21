using CheapAwesomeServices.Services.Interface;
using Contracts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CheapAwesomeServices.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BargainsApiController : ControllerBase
    {
        private readonly IBargainsService _bargainsService;
        private readonly IConfiguration _configuration;
        private readonly string authCode;
        public BargainsApiController(IBargainsService bargainsService, IConfiguration configuration)
        {
            _bargainsService = bargainsService;
            _configuration = configuration;
            authCode = _configuration.GetSection("AuthCode").Value;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBargainsForCouples([FromQuery]RequestParams request)
        {
            try
            {
                if (request == null)
                    return BadRequest();
                if(request.Code != authCode)
                    return Unauthorized();
                //if request is authorized call bargain service to get result
                var result = await _bargainsService.GetBargains(request);
                if (result.Any())
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (Exception)
            {
                throw;
            }
        }
        
    }
}
