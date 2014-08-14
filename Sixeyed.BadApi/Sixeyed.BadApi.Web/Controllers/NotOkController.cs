using Sixeyed.BadApi.Web.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Sixeyed.BadApi.Web.Controllers
{
    /// <summary>
    /// Not OK - responses which are not 200s
    /// </summary>
    public class NotOkController : ApiController
    {               
        /// <summary>
        /// Returns 500: Internal Server Error
        /// </summary>
        [Route("internalservererror")]
        public IHttpActionResult GetInternalServerError()
        {
            return InternalServerError();
        }

        /// <summary>
        /// Returns 400: BadRequest
        /// </summary>
        [Route("badrequest")]
        public IHttpActionResult GetBadRequest()
        {
            return BadRequest();
        }

        /// <summary>
        /// Returns 404: Not Found
        /// </summary>
        [Route("notfound")]
        public IHttpActionResult GetNotFound()
        {
            return NotFound();
        }

        /// <summary>
        /// Returns 401: Unauthorized
        /// </summary>
        [Route("unauthorized")]
        public IHttpActionResult GetUnauthorized()
        {
            return Unauthorized();
        }

        /// <summary>
        /// Returns 403: Forbidden
        /// </summary>
        [Route("forbidden")]
        public HttpResponseMessage GetForbidden()
        {
            return new HttpResponseMessage(HttpStatusCode.Forbidden);
        }

        /// <summary>
        /// Returns 409: Conflict
        /// </summary>
        [Route("conflict")]
        public HttpResponseMessage GetConflict()
        {
            return new HttpResponseMessage(HttpStatusCode.Conflict);
        }


        /// <summary>
        /// Returns the provided status code 
        /// </summary>
        /// <param name="code">HTTP status code to return</param>
        /// <param name="reason">[Optional] reason phrase</param>
        /// <returns></returns>
        [Route("status/{code}")]
        public HttpResponseMessage GetStatusCode(string code, string reason = "")
        {
            var statusCode = HttpStatusCode.BadRequest;
            if (!Enum.TryParse<HttpStatusCode>(code, out statusCode))
            {
                reason = code + " is not a valid HTTP status code";
            }
            return new HttpResponseMessage { StatusCode = statusCode, ReasonPhrase = reason };
        }
    }
}
