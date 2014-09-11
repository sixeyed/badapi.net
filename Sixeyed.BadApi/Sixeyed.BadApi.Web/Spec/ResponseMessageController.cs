using Sixeyed.BadApi.Web.Spec;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sixeyed.BadApi.Web.Controllers
{
    public abstract class ResponseMessageController : ApiController, IResponseMessageController
    {
        public abstract HttpStatusCode ResponseStatusCode { get; }

        public IHttpActionResult Get()
        {
            return ResponseMessage(new HttpResponseMessage(ResponseStatusCode));
        }
    }
}

