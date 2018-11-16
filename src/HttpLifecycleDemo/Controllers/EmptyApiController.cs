using System;
using System.Collections.Generic;
using System.Web.Http;

namespace HttpLifecycleDemo.Controllers
{
    public class EmptyApiController : ApiController
    {
        [Route("api/empty")]
        public IEnumerable<string> Get()
        {
            for (int i = 0; i < 3; i++)
            {
                yield return "empty" + i;
            }
        }

        [Route("api/emptyEx")]
        public string GetEx()
        {
            throw new ArgumentException("shit happens!");
        }
    }
}