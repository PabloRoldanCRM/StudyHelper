using StudyHelperApp.Model;
using StudyHelperApp.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StudyHelperApp.ViewModel
{
    public class QuestionsPageViewModel  : BaseViewModel
    {
        ObservableCollection<Question> _questions;
        //ListaRespuestasInput
        public Command Command { get; set; }
        int _numQuestions;
        public QuestionsPageViewModel(ObservableCollection<Question> questions,
            int numQuestions)
        {
            _numQuestions = numQuestions;
            _questions = questions;
        }

    }
}
