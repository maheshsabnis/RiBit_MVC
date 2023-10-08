using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_App.Controllers
{
    /// <summary>
    /// ApiController:
    /// 1. REad Http Request Message
    /// 2. If it is of GET type, then map to Get() action Method
    /// 3. If it is of POST/PUT Type then Read the Http Request Body and Map to POST and PUT method and map the data from Request body to .NET CLR INput parameter to method 
    /// </summary>
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
