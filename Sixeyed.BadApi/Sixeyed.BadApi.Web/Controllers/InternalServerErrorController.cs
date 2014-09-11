using Sixeyed.BadApi.Web.Spec;
using System.Web.Http;

namespace Sixeyed.BadApi.Web.Controllers
{
    /// <summary>
    /// Not OK - responses which are not 200s
    /// </summary>
    public class InternalServerErrorController : ApiController, IResponseMessageController
    {
        /// <summary>
        /// Returns 500: Internal Server Error
        /// </summary>
        public IHttpActionResult Get()
        {
            return InternalServerError();
        }
    }
}