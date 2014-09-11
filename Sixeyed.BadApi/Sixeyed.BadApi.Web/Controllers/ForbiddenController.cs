using Sixeyed.BadApi.Web.Spec;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sixeyed.BadApi.Web.Controllers
{
    /// <summary>
    /// Not OK - responses which are not 200s
    /// </summary>
    public class ForbiddeController : ApiController, IResponseMessageController
    {
        /// <summary>
        /// Returns 403: Forbidden
        /// </summary>
        public IHttpActionResult Get()
        {
            return ResponseMessage(new HttpResponseMessage(HttpStatusCode.Forbidden));
        }
    }
}

