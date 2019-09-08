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
        int _numQuestions = 1;
        public int NumQuestions { get => _numQuestions; set { _numQuestions = value; OnPropertyChanged(); } }
        public Command LoadItemsCommand { get; set; }
        public IDataStore DataStore => new DataStore(Constant.BaseAdress,Constant.Route);
        public ObservableCollection<Question> Questions { get; set; }
        public ObservableCollection<Question> QuestionsSelect { get; set; }

        async Task ExecuteLoadItemsCommand(INavigation navigation)
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                Questions = new ObservableCollection<Question>();
                QuestionsSelect = new ObservableCollection<Question>();
                Questions = await DataStore.GetData();
                TomarSeleccionLista();
                RawAnswerToAnswerList();
                await GoNextPage(navigation);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
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
            await navigation.PushModalAsync(new QuestionsPage(QuestionsSelect));
        }
        void RawAnswerToAnswerList() {
            foreach (var question in QuestionsSelect)
            {
                var rawResponse = question.RawAnswers;
                //List<SelectableData<string>> selectableDatas = new List<SelectableData<string>>();
                //rawResponse.Split('|').ToList().ForEach(i =>
                //{
                   // var index = 0;
                    //selectableDatas.Add(new SelectableData<string>() { Data = i, Index = index, IsSelected = false });
                 //   index++;
               // });
                question.Answers = rawResponse.Split('|').ToList();
            }
        }
        private void TomarSeleccionLista()
        {
            if (Questions.Count > 0)
            {
                Random rdn = new Random();
                QuestionsSelect = new ObservableCollection<Question>(Questions.OrderBy(a => rdn.Next(a.Id)).Take(_numQuestions));
            }
        }


    }
}
