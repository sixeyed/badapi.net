using Sixeyed.BadApi.Web.Spec;
using System.Net;
using System.Web.Http;

namespace Sixeyed.BadApi.Web.Controllers
{
    public class NotFoundController : ResponseMessageController
    {
        public override HttpStatusCode ResponseStatusCode
        {
            get { return HttpStatusCode.NotFound; }
        }
    }
}
