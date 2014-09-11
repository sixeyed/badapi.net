using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sixeyed.BadApi.Web.Controllers
{
    /// <summary>
    /// Status - return a specific code and reason
    /// </summary>
    public class NotOkController : ApiController
    {
        /// <summary>
        /// Returns the provided status code 
        /// </summary>
        /// <param name="code">HTTP status code to return</param>
        /// <param name="reason">[Optional] reason phrase</param>
        /// <returns></returns>
        [Route("status/{code}")]
        public IHttpActionResult GetStatusCode(string code, string reason = "")
        {
            var statusCode = HttpStatusCode.BadRequest;
            if (!Enum.TryParse<HttpStatusCode>(code, out statusCode))
            {
                reason = code + " is not a valid HTTP status code";
            }
            return ResponseMessage(new HttpResponseMessage { StatusCode = statusCode, ReasonPhrase = reason });
        }
    }
}

