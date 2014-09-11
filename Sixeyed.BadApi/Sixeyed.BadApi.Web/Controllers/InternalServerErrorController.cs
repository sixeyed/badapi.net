using System.Web.Http;

namespace Sixeyed.BadApi.Web.Controllers
{
    /// <summary>
    /// Not OK - responses which are not 200s
    /// </summary>
    public class InternalServerErrorController : ApiController
    {
        /// <summary>
        /// Returns 500: Internal Server Error
        /// </summary>
        [Route("internalservererror")]
        public IHttpActionResult GetInternalServerError()
        {
            return InternalServerError();
        }
    }
}