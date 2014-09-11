using Sixeyed.BadApi.Web.Spec;
using System.Web.Http;

namespace Sixeyed.BadApi.Web.Controllers
{
    /// <summary>
    /// Not OK - responses which are not 200s
    /// </summary>
    public class BadRequestController : ApiController, IResponseMessageController
    {               
        /// <summary>
        /// Returns 400: BadRequest
        /// </summary>
        public IHttpActionResult Get()
        {
            return BadRequest();
        }
    }
}