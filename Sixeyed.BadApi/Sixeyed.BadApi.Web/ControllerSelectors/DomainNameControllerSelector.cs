using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Sixeyed.BadApi.Web.ControllerSelectors
{
    public class DomainNameControllerSelector : DefaultHttpControllerSelector
    {
        private static Random _Random = new Random();

        private HttpConfiguration _config;

        public DomainNameControllerSelector(HttpConfiguration config)
            : base(config)
        {
            _config = config;
        }

        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            string controllerName = string.Empty;            
            var host = request.RequestUri.Host;

            //check for failure host names:
            if (host.StartsWith("transient."))
            {
                if (_Random.Next(1, 10) < 4)
                {
                    controllerName = "Ok";
                }
                else
                {
                    controllerName = "ServiceUnavailable";
                }                        
            }

            else if (host.StartsWith("permanent."))
            {
                controllerName = "BadRequest";
            }

            //if the request starts with a status code (e.g. 400.badapi.net), lookup the status name:
            else if (host.IndexOf('.') == 3)
            {
                var statusCode = 0;
                if (int.TryParse(host.Substring(0, 3), out statusCode))
                {
                    controllerName = Enum.GetName(typeof(HttpStatusCode), statusCode);
                }
            }

            //no match, use the controller part of the uri:
            if (string.IsNullOrEmpty(controllerName))
            {
                var routeData = request.GetRouteData();
                if (routeData.Values.ContainsKey("controller"))
                {
                    controllerName = routeData.Values["controller"].ToString();
                }
            }

            //look for matching controller:
            var controllers = GetControllerMapping();
            HttpControllerDescriptor controllerDescriptor;
            if (controllers.TryGetValue(controllerName, out controllerDescriptor))
            {
                return controllerDescriptor;
            }

            //default:
            controllers.TryGetValue("BadServer", out controllerDescriptor);
            return controllerDescriptor;
        }
    }
}