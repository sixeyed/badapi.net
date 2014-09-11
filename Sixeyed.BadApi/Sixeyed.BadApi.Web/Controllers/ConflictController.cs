using Sixeyed.BadApi.Web.Spec;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sixeyed.BadApi.Web.Controllers
{
    /// <summary>
    /// Not OK - responses which are not 200s
    /// </summary>
    public class ConflictController : ApiController, IResponseMessageController
    {
        /// <summary>
        /// Returns 409: Conflict
        /// </summary>
        public IHttpActionResult Get()
        {
            return ResponseMessage(new HttpResponseMessage(HttpStatusCode.Conflict));
        }
    }
}

