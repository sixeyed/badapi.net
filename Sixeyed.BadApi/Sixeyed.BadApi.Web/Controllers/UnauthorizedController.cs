using System.Web.Http;

namespace Sixeyed.BadApi.Web.Controllers
{
    /// <summary>
    /// Not OK - responses which are not 200s
    /// </summary>
    public class UnauthorizedController : ApiController
    {
        /// <summary>
        /// Returns 401: Unauthorized
        /// </summary>
        [Route("unauthorized")]
        public IHttpActionResult GetUnauthorized()
        {
            return Unauthorized();
        }
    }
}

