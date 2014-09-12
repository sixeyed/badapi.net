using System.Net;
using System.Web.Http;

namespace Sixeyed.BadApi.Web.Spec
{
    public interface IResponseMessageController
    {
        IHttpActionResult Any();

        HttpStatusCode ResponseStatusCode { get;  }
    }
}
