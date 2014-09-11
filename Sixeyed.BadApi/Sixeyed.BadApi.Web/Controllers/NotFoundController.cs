using Sixeyed.BadApi.Web.Spec;
using System.Web.Http;

namespace Sixeyed.BadApi.Web.Controllers
{
    /// <summary>
    /// Not OK - responses which are not 200s
    /// </summary>
    public class NotFoundController : ApiController, IResponseMessageController
    {
        /// <summary>
        /// Returns 404: Not Found
        /// </summary>
        public IHttpActionResult Get()
        {
            return NotFound();
        }
    }
}
