using StudyHelperApp.Model;
using StudyHelperApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudyHelperApp.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class QuestionsPage : ContentPage
	{
        public QuestionsPage (ObservableCollection<Question> questions, int numQuestions)
		{
			InitializeComponent ();
            this.BindingContext = new QuestionsPageViewModel(questions, numQuestions);
		}
	}
}