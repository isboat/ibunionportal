using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backend.Web.Controllers
{
    public class DataController : ApiController
    {
        [HttpGet]
        public IEnumerable<string> GetSummary()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
