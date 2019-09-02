using Newtonsoft.Json;
using StudyHelperApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StudyHelperApp.Service
{
   public class DataStore : IDataStore
    {
        string _baseAddress = string.Empty;
        string _route = string.Empty;
        public DataStore(string baseAddress, string route)
        {
            _baseAddress = baseAddress;
             _route = route;
        }
        public async Task<ObservableCollection<Question>> GetData()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseAddress);
                var content = await client.GetStringAsync(_route);
                return JsonConvert.DeserializeObject<ObservableCollection<Question>>(content);
            }
        }
    }
}
