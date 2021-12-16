using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Hosting;
using System.Web.Http;
using WebForRonen.Models;

namespace WebForRonen.Controllers
{
    namespace WebForRonen.Controllers
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
        [RoutePrefix("")]

        public class CallsController : ApiController
        {

            public CallsController()
            {

            }



            // GET: api/Calls
            [HttpGet]
            public Call[] List()
            {
                var list = DAL.DAL.GetCalls();
                return list.ToArray();
            }

            // GET: api/Calls/5
            public string Get(int id)
            {
                return "value";
            }

            //// POST: api/Calls
            //public void Post([FromBody]string value)
            //{
            //}

            //// PUT: api/Calls/5
            //public void Put(int id, [FromBody]string value)
            //{
            //}

            //// DELETE: api/Calls/5
            //public void Delete(int id)
            //{
            //}
        }
    }
}
