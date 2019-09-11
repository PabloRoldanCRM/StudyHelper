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
        private string _colorGrid ="#ffffff";
        public string ColorGrid
        {
            get => _colorGrid; set
            {
                _colorGrid = value;
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
            NextQuestion = new Command(async ()=>await  PopQuestions());
            SelectedItems = new ObservableCollection<object>();

        }
        async Task PopQuestions()
        {
            // var res = CurrentQuestion.Answers.Where(i => i.IsSelected).ToList();       
            ValidateResponse();
            //Task.Delay(4500).Wait();
            await ShowUpImg();
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
                ImagePath = "correct1.png";
                ColorGrid = "#a8d17f";
            }
            else
            {
                ImagePath = "error1.png";
                ColorGrid = "#fc9999";
            }
        }
        void ShowResult()
        {
            ResultQuestions = $"Score: {correctQuestions}/{_questions.Count}";
        }

        async Task ShowUpImg() {
            ShowAnswer = true;
            await Task.Delay(4000);
            ShowAnswer = false;
        }
    }
}
