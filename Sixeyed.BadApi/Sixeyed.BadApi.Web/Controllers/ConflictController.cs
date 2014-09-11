using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sixeyed.BadApi.Web.Controllers
{
    /// <summary>
    /// Not OK - responses which are not 200s
    /// </summary>
    public class ConflictController : ApiController
    {
        /// <summary>
        /// Returns 409: Conflict
        /// </summary>
        public IHttpActionResult GetConflict()
        {
            return ResponseMessage(new HttpResponseMessage(HttpStatusCode.Conflict));
        }
    }
}

