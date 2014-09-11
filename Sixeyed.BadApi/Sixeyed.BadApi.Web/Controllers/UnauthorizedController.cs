using System.Net;

namespace Sixeyed.BadApi.Web.Controllers
{
    public class UnauthorizedController : ResponseMessageController
    {
        public override HttpStatusCode ResponseStatusCode
        {
            get { return HttpStatusCode.Unauthorized; }
        }
    }
}

