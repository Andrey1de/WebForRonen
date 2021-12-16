using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace WebForRonen.Models
{
    public class Call
    {
        public string   PhoneNumber { get; set; }
        public string   Date        { get; set; }
        public int      CallTime    { get; set; } //secs

    }
}