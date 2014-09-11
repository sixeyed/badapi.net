using Sixeyed.BadApi.Web.Spec;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sixeyed.BadApi.Web.Controllers
{
    /// <summary>
    /// Not OK - responses which are not 200s
    /// </summary>
    public class ServiceUnavailableController : ApiController, IResponseMessageController
    {
        /// <summary>
        /// Returns 503: Service Unavailable
        /// </summary>
        public IHttpActionResult Get()
        {
            return ResponseMessage(new HttpResponseMessage(HttpStatusCode.ServiceUnavailable));
        }
    }
}
