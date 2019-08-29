using StudyHelperApp.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StudyHelperApp.Service
{
   public class DataStore : IDataStore
    {
        public string BaseAddress { get; set; } = "https://almacenamiento111.blob.core.windows.net/";

        public async Task<string> GetData(string route)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseAddress);
                return await client.GetStringAsync(route);
            }
        }
    }
}
