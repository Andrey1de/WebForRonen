using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Http.Cors;
using WebForRonen.Models;


namespace WebForRonen.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
    [RoutePrefix("")]
    public class CitiesController : ApiController
    {
      
        public CitiesController()
        {
   
        }



            // GET: api/Cities
        [HttpGet]
        public City[] List()
        {
            var list = DAL.DAL.Cities.Values;
            return list.ToArray();
        }

        //// GET: api/Cities/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Cities
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Cities/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Cities/5
        //public void Delete(int id)
        //{
        //}
    }
}
