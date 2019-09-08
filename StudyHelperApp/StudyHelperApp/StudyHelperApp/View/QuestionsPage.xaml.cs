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
        public QuestionsPage (ObservableCollection<Question> questions)
		{
			InitializeComponent();
            this.BindingContext = new QuestionsPageViewModel(questions);
		}
        private async void ViewCell_Appearing(object sender, EventArgs e)
        {
            var cell = sender as ViewCell;
            var view = cell.View;
            view.Opacity = 0;
            view.TranslationX = -100;
            await Task.WhenAny<bool>(
                 view.TranslateTo(0, 0, 250, Easing.SinIn),
                 view.FadeTo(1, 500, Easing.BounceIn));
        }
    }
}