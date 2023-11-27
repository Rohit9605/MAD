using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewViewModels.Base;
using MyFirstMobileApp.ViewViewModels.CollectionsContents.CollectionIconsContents;
using MyFirstMobileApp.ViewViewModels.CollectionsContents.CollectionImageContents;
using MyFirstMobileApp.ViewViewModels.CollectionsContents.CollectionsUpdatable;
using MyFirstMobileApp.ViewViewModels.CollectionsContents.SWMoviesCollection;
using MyFirstMobileApp.ViewViewModels.CollectionsContents.TeletubbiesCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyFirstMobileApp.ViewViewModels.CollectionsContents
{
    public class CollectionsMenuViewModel : BaseViewModel
    {
        
        public string TeletubbiesTitle { get; set; } = TitleCollectionsMenu.TTTitle;
        public string ImagesTitle { get; set; } = TitleCollectionsMenu.ImagesTitle;
        public string ButtonsTitle { get; set; } = TitleCollectionsMenu.ButtonsTitle;
        public string IconsTitle { get; set; } = TitleCollectionsMenu.IconsTitle;

        //Button Commands
        public ICommand OnTTClicked { get; set; }
        public ICommand OnCollectionImageClicked { get; set; }
        public ICommand OnButtonsClicked { get; set; }
        public ICommand OnIconsClicked { get; set; }


        public CollectionsMenuViewModel()
        {
            Title = TitleMain.CollectionsTitle;

            OnTTClicked = new Command(OnTeletubbiesClickedAsync);
            OnCollectionImageClicked = new Command(OnCollectionImageClickedAsync);
            OnButtonsClicked = new Command(OnButtonsClickedAsync);
            OnIconsClicked = new Command(OnIconsClickedAsync);

        }

        private async void OnTeletubbiesClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new TeletubbiesView());
        }

        private async void OnCollectionImageClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CollectionImageView());
        }

        private async void OnButtonsClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CollectionsButtonsView());
        }
        private async void OnIconsClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CollectionsIconsView());
        }

    }
}
