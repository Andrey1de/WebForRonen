using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using WebForRonen.Models;

namespace WebForRonen.DAL
{
    public class DAL
    {
        static readonly string appDataPath = HostingEnvironment.MapPath("~/App_Data");


        protected static List<T> ReadJson<T>(string fileName) where T : class
        {
            var list = new List<T>();
            try
            {
                string fileNameFull = Path.Combine(appDataPath, fileName);

                string json = File.ReadAllText(fileNameFull);
                var arr = JsonConvert.DeserializeObject<T[]>(json);
                list = new List<T>(arr);

            }
            catch (Exception)
            {


            }
            return list;
        }


        #region Cities
        public static ConcurrentDictionary<int, City> Cities => _Cities.Value;


        static readonly Lazy<ConcurrentDictionary<int, City>> _Cities =
            new Lazy<ConcurrentDictionary<int, City>>(
                RetrieveCities
         );


        static ConcurrentDictionary<int, City> RetrieveCities()
        {
            var arr = ReadJson<City>("cities.json");
            var dic = arr.ToDictionary(k => k.Id, p => p);
            var ret =  new ConcurrentDictionary<int, City>(dic);
            return ret;

        }
        #endregion

        #region Customers

        public static ConcurrentDictionary<int, Customer> Customers => _Customers.Value;


        static Lazy<ConcurrentDictionary<int, Customer>> _Customers =
          new Lazy<ConcurrentDictionary<int, Customer>>(
                     RetrieveCustomers
              );


        static ConcurrentDictionary<int, Customer> RetrieveCustomers()
        {
            var arr = ReadJson<Customer>("Customers.json");
            var dict = arr.ToDictionary(k => k.Id, p => p);

            var ret =  new ConcurrentDictionary<int, Customer>(dict);

            return ret;

        }


        #endregion

        #region Calls
        public static List<Call> Calls => _Calls.Value;

        static Lazy<List<Call>> _Calls =
                  new Lazy<List<Call>>(() => ReadJson<Call>("Calls.json"));

        #endregion

    }
}