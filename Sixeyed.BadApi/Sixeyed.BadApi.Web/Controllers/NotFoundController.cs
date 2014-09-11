using System.Web.Http;

namespace Sixeyed.BadApi.Web.Controllers
{
    /// <summary>
    /// Not OK - responses which are not 200s
    /// </summary>
    public class NotFoundController : ApiController
    {
        /// <summary>
        /// Returns 404: Not Found
        /// </summary>
        [Route("notfound")]
        public IHttpActionResult GetNotFound()
        {
            return NotFound();
        }
    }
}
