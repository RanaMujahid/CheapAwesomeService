using CheapAwesomeServices.Enums;
using CheapAwesomeServices.Services.Interface;
using CheapAwesomeServices.Utility;
using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CheapAwesomeServices.Services
{
    public class BargainsService : IBargainsService
    {
        private readonly APIGateWay _apigateway;

        public BargainsService(APIGateWay apigateway)
        {
            _apigateway = apigateway;
        }
        public async Task<IEnumerable<CheapAwsomeResponse>> GetBargains(RequestParams request)
        {
            try
            {
                IList<CheapAwsomeResponse> hotelList = new List<CheapAwsomeResponse>();
                var endPoint = "/findBargain?destinationId="+ request.DestinationId + "& nights=" + request.Nights + "&code=" + request.Code;
                var response = await _apigateway.GetAsync<IEnumerable<BargainsReponse>>(endPoint);
                //this will process list parralelly using multiple threads.
                Parallel.ForEach(response, (currentItem) =>
                {
                    CheapAwsomeResponse hotelObj = new CheapAwsomeResponse();
                    Parallel.ForEach(currentItem.rates, (currentRate) =>
                    {
                        if (currentRate.rateType == RateTypes.PerNight.ToString())
                        {
                            currentRate.value = currentRate.value * request.Nights;
                        }
                        hotelObj.ratesPerBoardType.Add(new RatesPerBoardType { boardType = currentRate.boardType, value = currentRate.value });
                    });

                    hotelObj.hotel = currentItem.hotel;
                    hotelList.Add(hotelObj);
                });
                return hotelList;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
