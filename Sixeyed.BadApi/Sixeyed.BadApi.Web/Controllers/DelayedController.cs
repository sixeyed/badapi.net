using Sixeyed.BadApi.Web.Models;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Sixeyed.BadApi.Web.Controllers
{
    /// <summary>
    /// Delayed - responses which take a while
    /// </summary>
    public class DelayedController : ApiController
    {
        private static Random _Random = new Random();
               
        /// <summary>
        /// Waits for a (short) random period before returning
        /// </summary>
        /// <param name="between">[Optional] Minimum wait period in *milliseconds*</param>
        /// <param name="and">[Optional] Maximum wait period in *milliseconds*</param>
        [Route("longrunning")]
        public async Task<IHttpActionResult> GetLongRunningAsync(int between = 100, int and = 5000)
        {
            var delayMilliseconds = _Random.Next(between, and);
            await Task.Delay(delayMilliseconds);

            return Ok(new Delayed{ DelayMilliseconds = delayMilliseconds });
        }

        /// <summary>
        /// Waits for a (long) random period before returning
        /// </summary>
        /// <param name="between">[Optional] Minimum wait period in *seconds*</param>
        /// <param name="and">[Optional] Maximum wait period in *seconds*</param>
        [Route("verylongrunning")]
        public async Task<IHttpActionResult> GetAsync(int between = 5, int and = 60)
        {
            var delayMilliseconds = _Random.Next(between * 1000, and * 1000);
            await Task.Delay(delayMilliseconds);

            return Ok(new Delayed { DelayMilliseconds = delayMilliseconds });
        }
    }
}
