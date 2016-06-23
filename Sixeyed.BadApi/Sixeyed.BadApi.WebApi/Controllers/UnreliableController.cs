using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sixeyed.BadApi.Model;
using StackExchange.Redis;
using System;
using System.Net;
using System.Net.Http;

namespace Sixeyed.BadApi.WebApi.Controllers
{
    [Route("[controller]")]
    public class UnreliableController : Controller
    {
        private static Random _Random = new Random();
        private static ConnectionMultiplexer _Multiplexer;

        static UnreliableController()
        {
            _Multiplexer = ConnectionMultiplexer.Connect("redis");
        }

        // GET api/values
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var statusCode = HttpStatusCode.OK;

            //unreliable endpoint - 60% successful 30% 503, 10% 500:
            var mode = _Random.Next(1, 10);
            if (mode == 1)
            {
                statusCode = HttpStatusCode.InternalServerError;
            }
            else if (mode < 5)
            {
                statusCode = HttpStatusCode.ServiceUnavailable;
            }

            var response = new ApiResponse
            {
                Timestamp = DateTime.Now,
                StatusCode = statusCode.ToString(),
                Server = Environment.MachineName
            };

            var subscriber = _Multiplexer.GetSubscriber();
            subscriber.Publish("api-responses", JsonConvert.SerializeObject(response));

            return new HttpResponseMessage(statusCode);
        }
    }
}