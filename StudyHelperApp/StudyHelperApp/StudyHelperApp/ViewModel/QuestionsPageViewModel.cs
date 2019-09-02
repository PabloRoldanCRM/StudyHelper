using StudyHelperApp.Model;
using StudyHelperApp.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StudyHelperApp.ViewModel
{
    public class QuestionsPageViewModel  : BaseViewModel
    {
        ObservableCollection<Question> _questions;
        ObservableCollection<Question> _questionsAux;
        Question currentQuestion;
        public Question CurrentQuestion { get =>currentQuestion ;
            set
            {
                currentQuestion = value;
                OnPropertyChanged();
            }
        }
        //ListaRespuestasInput
        public Command NextQuestion { get; set; }
        public string NoItems { get; set; }

        int _numQuestions;
        public QuestionsPageViewModel(ObservableCollection<Question> questions,
            int numQuestions)
        {
            _numQuestions = numQuestions;
            _questions = questions;
            TomarSeleccionLista();
            NextQuestion = new Command(PopQuestions);
        }
        private void TomarSeleccionLista() {
            if (_questions.Count > 0) {
                Random rdn = new Random();
                _questionsAux = new ObservableCollection<Question>(_questions.OrderBy(a => rdn.Next(a.Id)).Take(_numQuestions));
                CurrentQuestion = _questionsAux.FirstOrDefault();
            }
            else
                NoItems = "No existe información";
        }
         void PopQuestions() {
            if (_questionsAux.Count > 0) {
                var itemToRemove = _questionsAux.Where(s => s.Id == CurrentQuestion.Id).FirstOrDefault();
                if (itemToRemove != null) {
                   _questionsAux.Remove(itemToRemove);
                }
            }
        }

    }
}
