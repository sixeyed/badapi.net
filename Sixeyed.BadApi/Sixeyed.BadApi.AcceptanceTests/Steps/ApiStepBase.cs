using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Sixeyed.BadApi.AcceptanceTests.Steps
{
    public abstract class ApiStepBase
    {
        protected string RequestUrl
        {
            get { return ScenarioContext.Current.Get<string>("RequestUrl"); }
            set { ScenarioContext.Current.Set<string>(value, "RequestUrl"); }
        }

        protected HttpResponseMessage ResponseMessage
        {
            get { return ScenarioContext.Current.Get<HttpResponseMessage>("ResponseMessage"); }
            set { ScenarioContext.Current.Set<HttpResponseMessage>(value, "ResponseMessage"); }
        }

        protected string ResponseBody
        {
            get { return ScenarioContext.Current.Get<string>("ResponseBody"); }
            set { ScenarioContext.Current.Set<string>(value, "ResponseBody"); }
        }

        protected dynamic Response
        {
            get { return ScenarioContext.Current.Get<dynamic>("Response"); }
            set { ScenarioContext.Current.Set<dynamic>(value, "Response"); }
        }

        protected void GetResponse()
        {
            SendRequest(x => x.GetAsync(RequestUrl)).Wait();
        }

        protected async Task SendRequest(Func<HttpClient, Task<HttpResponseMessage>> request, Action<HttpClient> setup =null)
        {
            ResponseMessage = null;
            ResponseBody = null;
            Response = null;
            using (var client = new HttpClient())
            {
                if (setup != null)
                {
                    setup(client);
                }
                ResponseMessage = await request(client);
                ResponseBody = await ResponseMessage.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(ResponseBody))
                {
                    Response = JsonConvert.DeserializeObject<dynamic>(ResponseBody);
                }
            }
        }
    }
}
