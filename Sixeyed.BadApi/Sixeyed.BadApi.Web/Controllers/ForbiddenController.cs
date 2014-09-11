using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sixeyed.BadApi.Web.Controllers
{
    /// <summary>
    /// Not OK - responses which are not 200s
    /// </summary>
    public class ForbiddeController : ApiController
    {
        /// <summary>
        /// Returns 403: Forbidden
        /// </summary>
        public HttpResponseMessage GetForbidden()
        {
            return new HttpResponseMessage(HttpStatusCode.Forbidden);
        }
    }
}

