using StudyHelperApp.Constants;
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
    public class QuestionsPageViewModel : BaseViewModel
    {
        ObservableCollection<Question> _questions;
        ObservableCollection<object> selectedItems;
        private string _resultQuestions;
        private int correctQuestions = 0;
        public string ResultQuestions
        {
            get => _resultQuestions;
            set
            {
                _resultQuestions = value;
                OnPropertyChanged();
            }
        }
        private string _imagePath;
        public string ImagePath
        {
            get => _imagePath; set
            {
                _imagePath = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<object> SelectedItems
        {
            get { return this.selectedItems; }
            set
            {
                this.selectedItems = value;
                this.OnPropertyChanged();
            }
        }
        Question currentQuestion;
        public Question CurrentQuestion
        {
            get => currentQuestion;
            set
            {
                currentQuestion = value;
                OnPropertyChanged();
            }
        }
        public Command NextQuestion { get; set; }
        bool _showAnswer;

        public bool ShowAnswer
        {
            get => _showAnswer; set
            {
                _showAnswer = value;
                OnPropertyChanged();
            }
        }
        public string NoItems { get; set; }
        public QuestionsPageViewModel(ObservableCollection<Question> questions)
        {
            _questions = questions;
            GetQuestion();
            NextQuestion = new Command(PopQuestions);
            SelectedItems = new ObservableCollection<object>();

        }
        void PopQuestions()
        {
            // var res = CurrentQuestion.Answers.Where(i => i.IsSelected).ToList();
            //ShowAnswer = true;
            //return;
            if (_questions.Count > 0)
            {
                var itemToRemove = _questions.Where(s => s.Id == CurrentQuestion.Id).FirstOrDefault();
                if (itemToRemove != null)
                {
                    _questions.Remove(itemToRemove);
                }
                GetQuestion();
            }
        }
        void GetQuestion()
        {
            if (_questions.Count > 0)
                CurrentQuestion = _questions[0];
            else
                NoItems = "😢 Sorry there is no Questions Avalible.";
        }
        void ValidateResponse()
        {
            //selectedItems;
            string response = "";
            if (selectedItems.Count > 0)
            {
                for (int i = 0; i < selectedItems.Count; i++)
                {
                    response += selectedItems[i].ToString().Trim()[0];
                }
            }
            if (response == currentQuestion.Answer) {
                correctQuestions++;
                ImagePath = "correct.png";
            }
            else
                ImagePath = "error.png";
        }
        void ShowResult()
        {

            ResultQuestions = $"Score: {correctQuestions}/{_questions.Count}";
        }
    }
}
