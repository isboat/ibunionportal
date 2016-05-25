using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backend.Web.Controllers
{
    public class SummaryApiController : ApiController
    {
        // GET: api/SummaryApi
        public IEnumerable<string> GetSummary()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SummaryApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SummaryApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SummaryApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SummaryApi/5
        public void Delete(int id)
        {
        }
    }
}
