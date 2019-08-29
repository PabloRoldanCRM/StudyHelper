using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudyHelperApp.Service
{
    public interface IDataStore
    {
        Task<string> GetData(string route);
    }
}
