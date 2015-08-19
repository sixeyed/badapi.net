using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sixeyed.BadApi.Web.Controllers
{
    public class OkController : ResponseMessageController
    {
        public override HttpStatusCode ResponseStatusCode
        {
            get { return HttpStatusCode.OK; }
        }
    }
}

