using Newtonsoft.Json;
using StudyHelperApp.Constants;
using StudyHelperApp.Model;
using StudyHelperApp.Service;
using StudyHelperApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StudyHelperApp.ViewModel
{
    public class MainPageViewModel : BaseViewModel
    {
        int _numQuestions;
        public int NumQuestions { get => _numQuestions; set { _numQuestions = value;  OnPropertyChanged(); } } 
        public Command LoadItemsCommand { get; set; }
        public IDataStore DataStore => new DataStore(Constantes.BaseAdress,Constantes.Route);
        public ObservableCollection<Question> Questions { get; set; }

        async Task ExecuteLoadItemsCommand(INavigation navigation)
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                Questions = new ObservableCollection<Question>();
                Questions = await DataStore.GetData();
                RawAnswerToAnswerList();
                await GoNextPage(navigation);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Application.Current.MainPage.DisplayAlert("Error comunicación", "Servicio no disponible", "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }
        public MainPageViewModel(INavigation navigation)
        {
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(navigation));
        }
        async Task GoNextPage(INavigation navigation)
        {
            await navigation.PushModalAsync(new QuestionsPage(Questions,NumQuestions));
        }
        void RawAnswerToAnswerList() {
            foreach (var item in Questions)
            {
                var rawResponse = item.RawAnswers;
                item.Answers = rawResponse.Split('|').ToList();
            }
        }


    }
}
