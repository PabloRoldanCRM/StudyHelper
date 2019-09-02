
using StudyHelperApp.Model;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace StudyHelperApp.Service
{
    public interface IDataStore
    {
        Task<ObservableCollection<Question>> GetData();
    }
}
