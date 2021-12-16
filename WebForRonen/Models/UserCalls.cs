using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebForRonen.Models
{
    public class UserCalls
    {
        public int IdCustomer  { get; set; }
        public string  FullName { get; set; }

        public string City { get; set; }

        public int SumCallsTime { get; set; }

    }
}