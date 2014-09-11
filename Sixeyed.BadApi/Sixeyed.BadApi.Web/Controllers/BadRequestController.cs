using System.Net;
using System.Web.Http;

namespace Sixeyed.BadApi.Web.Controllers
{
    public class BadRequestController : ResponseMessageController
    {
        public override HttpStatusCode ResponseStatusCode
        {
            get { return HttpStatusCode.BadRequest; }
        }    
    }
}