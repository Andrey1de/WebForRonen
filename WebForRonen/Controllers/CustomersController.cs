using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebForRonen.Models;
using System.Web.Http.Cors;

namespace WebForRonen.Controllers
{
    //        • מספר לקוח
    //• שם מלא של הלקוח
    //• שם ישוב
    //• סה"כ זמן שיחות
    public class CustomerCTO
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }

        public string City { get; set; }

        public int SumCalls { get; set; }
    }
    // • מספר טלפון
    //• משך השיחה
    public class PhoneCallsCTO
    {
        public int CustomerId { get; set; }
        public string PhoneNumber { get; set; }

        public int SumCalls { get; set; }

    }

    [EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
    [RoutePrefix("")]

    public class CustomersController : ApiController
    {
        // GET: api/UserCalls
    
        [HttpGet]
        public CustomerCTO[] GetListCallsSum()
        {
            Customer[] arr = DAL.DAL.Customers.Values.ToArray();

            CustomerCTO[] q = arr
                .Select(p => new CustomerCTO()
                {
                    CustomerId = p.Id,
                    FullName = p.FirstName + ' ' + p.LastName,
                    City = getCity(p.CityId),
                    SumCalls = getSumCalls(p)
                }
            ).OrderBy(p=>p.SumCalls).ToArray();

            return q;
        }

        [HttpGet]
        public PhoneCallsCTO[] PhoneCallsSum(int id)
        {
            Customer customer = null;
      
            PhoneCallsCTO[] arr =  new PhoneCallsCTO[0];
            DAL.DAL.Customers.TryGetValue(id, out customer);
            if(customer != null)
            {
                var q = customer.PhoneNumbers
                    .Select(phone => new PhoneCallsCTO()
                    {
                        CustomerId = id,
                        PhoneNumber = phone,
                        SumCalls = getPhonesSum(phone)
                    }
                ).OrderBy(p => p.SumCalls).ToArray();
                arr = q.ToArray();
            }


            return arr;
        }


        private int getSumCalls(Customer cust)
        {
            int sum = 0;
            foreach (var phone in cust.PhoneNumbers)
            {
                sum += getPhonesSum(phone);

            }
            return sum;
        }

        private int getPhonesSum(string phone)
        {
            return DAL.DAL.Calls.Where(p => p.PhoneNumber == phone).Sum(p => p.CallTime);
        }

        private string getCity(int cityId)
        {
            City val;
            return DAL.DAL.Cities.TryGetValue(cityId, out val) ? val.Name : "";
        }

        //// POST: api/UserCalls
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/UserCalls/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/UserCalls/5
        //public void Delete(int id)
        //{
        //}
    }
}
