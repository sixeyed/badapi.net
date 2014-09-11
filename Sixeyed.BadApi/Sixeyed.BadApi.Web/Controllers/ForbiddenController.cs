using System.Net;

namespace Sixeyed.BadApi.Web.Controllers
{
    public class ForbiddenController : ResponseMessageController
    {
        public override HttpStatusCode ResponseStatusCode
        {
            get { return HttpStatusCode.Forbidden; }
        }
    }
}

