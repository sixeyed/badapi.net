using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sixeyed.BadApi.Web.Controllers
{
    /// <summary>
    /// Not OK - responses which are not 200s
    /// </summary>
    public class ServiceUnavailableController : ApiController
    {
        /// <summary>
        /// Returns 503: Service Unavailable
        /// </summary>
        [Route("serviceunavailable")]
        public IHttpActionResult GetServiceUnavailable()
        {
            return ResponseMessage(new HttpResponseMessage(HttpStatusCode.ServiceUnavailable));
        }
    }
}
