using Sixeyed.BadApi.Web.Models.Enums;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Sixeyed.BadApi.Web.Controllers
{
    /// <summary>
    /// Bad Server - random bad server response
    /// </summary>
    public class BadServerController : ApiController
    {
        private static Random _Random = new Random();

        /// <summary>
        /// Equal chance the server will either: be slow (returns 200 after 30 seconds); never respond (actually returns 200 after 5 minutes) ; return 500; return 503
        /// </summary>
        public async Task<IHttpActionResult> GetAsync()
        {
            var action = (BadServer)_Random.Next(1, 4);
            switch(action)
            {
                case BadServer.Slow :
                    await Task.Delay(30 * 1000);
                    return Ok();

                case BadServer.NeverRespond:
                    await Task.Delay(5 * 60 * 1000);
                    return Ok();

                case BadServer.ServiceUnavailable:                    
                    return ResponseMessage(new HttpResponseMessage(HttpStatusCode.ServiceUnavailable));

                case BadServer.InternalServerError:
                    return InternalServerError();
            }

            return Ok();
        }
    }
}