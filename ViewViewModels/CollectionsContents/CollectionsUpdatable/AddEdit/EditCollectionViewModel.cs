using MyFirstMobileApp.Models;
using MyFirstMobileApp.Models.Entities;
using MyFirstMobileApp.ViewViewModels.Base;
using System.Windows.Input;

#pragma warning disable CA1416 // Validate platform compatibility
namespace MyFirstMobileApp.ViewViewModels.CollectionsUpdatable.AddEdit
{
    public class EditCollectionViewModel : BaseViewModel
    {
        public ICommand UpdateBtnClicked { get; set; }
        private string _teletubbyName = string.Empty;

        public EditCollectionViewModel()
        {
            Title = TitleCollectionsButtons.EditTitle;
            UpdateBtnClicked = new Command(PerformSave);
        }

        public string TeletubbyName
        {
            get { return _teletubbyName; }

            set
            {
                if (_teletubbyName != value)
                    // Use the SetProperty method to update the private field _movies
                    // and trigger property change notifications when the Movies property value changes.
                    SetProperty(ref _teletubbyName, value);
            }
        }

        private void PerformSave()
        {
            if (string.IsNullOrEmpty(_teletubbyName.Trim()))
            {
                // Use Page.DisplayAlert to display the alert
                Application.Current.MainPage.DisplayAlert(TitleCollectionsButtons.EditTitle, "Title cannot be empty", "Ok"); //changed from Msgs.NotEmpty
                return;
            }

            Teletubbies movies = new Teletubbies();
            movies.NameOfTeletubby = _teletubbyName;

            MessagingCenter.Send<Teletubbies>(movies, "UpdateMovies");
            Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
#pragma warning restore CA1416 // Validate platform compatibility
