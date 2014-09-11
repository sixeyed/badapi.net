using System.Net;

namespace Sixeyed.BadApi.Web.Controllers
{
    public class ConflictController : ResponseMessageController
    {
        public override HttpStatusCode ResponseStatusCode
        {
            get { return HttpStatusCode.Conflict; }
        }
    }
}

