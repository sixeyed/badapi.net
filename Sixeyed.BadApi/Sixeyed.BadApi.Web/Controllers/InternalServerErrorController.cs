using System.Net;

namespace Sixeyed.BadApi.Web.Controllers
{
    public class InternalServerErrorController : ResponseMessageController
    {
        public override HttpStatusCode ResponseStatusCode
        {
            get { return HttpStatusCode.InternalServerError; }
        }
    }
}