using System;
using System.Web.Http;

namespace HttpLifecycleDemo.Controllers
{
    public class EmptyApiController : ApiController
    {
        [Route("api/empty/GetDate")]
        public string GetDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        [Route("api/empty/GetEx")]
        public string GetEx()
        {
            throw new ArgumentException("shit happens!");
        }
    }
}