using Sixeyed.BadApi.Web.Spec;
using System.Web.Http;

namespace Sixeyed.BadApi.Web.Controllers
{
    /// <summary>
    /// Not OK - responses which are not 200s
    /// </summary>
    public class UnauthorizedController : ApiController, IResponseMessageController
    {
        /// <summary>
        /// Returns 401: Unauthorized
        /// </summary>
        public IHttpActionResult Get()
        {
            return Unauthorized();
        }
    }
}

