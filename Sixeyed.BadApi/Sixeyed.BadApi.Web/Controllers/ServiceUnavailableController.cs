using Sixeyed.BadApi.Web.Spec;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sixeyed.BadApi.Web.Controllers
{
    public class ServiceUnavailableController : ResponseMessageController
    {
        public override HttpStatusCode ResponseStatusCode
        {
            get { return HttpStatusCode.ServiceUnavailable; }
        }
    }
}
