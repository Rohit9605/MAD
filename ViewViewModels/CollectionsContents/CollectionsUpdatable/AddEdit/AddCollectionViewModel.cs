using MyFirstMobileApp.Models;
using MyFirstMobileApp.Models.Entities;
using MyFirstMobileApp.ViewViewModels.Base;
using System.Windows.Input;

#pragma warning disable CA1416 // Validate platform compatibility
namespace MyFirstMobileApp.ViewViewModels.CollectionsUpdatable.AddEdit
{
    public class AddCollectionViewModel : BaseViewModel
    {
        public ICommand SaveBtnClicked { get; set; }
        private string _teletubbyName = string.Empty;

        public AddCollectionViewModel()
        {
            Title = TitleCollectionsButtons.AddTitle;
            SaveBtnClicked = new Command(PerformSave);
        }

        public string MovieName
        {
            get { return _teletubbyName; }

            set
            {
                if (_teletubbyName != value)
                    SetProperty(ref _teletubbyName, value);
            }
        }

        private void PerformSave()
        {
            if (string.IsNullOrEmpty(_teletubbyName.Trim()))
            {
                // Use Page.DisplayAlert to display the alert
                Application.Current.MainPage.DisplayAlert(TitleCollectionsButtons.AddTitle, "Title cannot be empty", "Ok"); //Changed from Msgs.NotEmpty
                return;
            }

            Teletubbies teletubbies = new Teletubbies();
            teletubbies.NameOfTeletubby = _teletubbyName;

            MessagingCenter.Send<Teletubbies>(teletubbies, "AddTeletubbies");

            if (Application.Current.MainPage is NavigationPage navigationPage)
            {
                navigationPage.Navigation.PopAsync();
            }
        }
    }
}
#pragma warning restore CA1416 // Validate platform compatibility
