using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sixeyed.BadApi.Web.Models.Enums
{
    public enum BadServer
    {
        Slow = 1,
        NeverRespond = 2,
        InternalServerError = 3,
        ServiceUnavailable = 4
    }
}