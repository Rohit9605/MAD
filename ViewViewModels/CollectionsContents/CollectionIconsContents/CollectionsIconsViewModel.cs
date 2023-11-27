using MyFirstMobileApp.Models;
using MyFirstMobileApp.Models.Entities;
using MyFirstMobileApp.ViewViewModels.Base;
using MyFirstMobileApp.ViewViewModels.CollectionsUpdatable.AddEdit;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace MyFirstMobileApp.ViewViewModels.CollectionsContents.CollectionsUpdatable
{
    public class CollectionsIconsViewModel : BaseViewModel
    {
        public ObservableCollection<Teletubbies> TeletubbiesCollection { get; set; }

        public CollectionsIconsViewModel()
        {
            //Set the title for this view
            Title = TitleCollectionsIcons.IconsTitle;

            //Create a new ObservableCollection to store movies
            TeletubbiesCollection = new ObservableCollection<Teletubbies>();

            //Load movies from the data source
            LoadTeletubbies();
        }

        private void LoadTeletubbies()
        {
            IsBusy = true;

            try
            {
                //Clear the existing collection
                TeletubbiesCollection.Clear();

                //Get a list of Star Wars movies and add them to the collection
                var teletubbies = Teletubbies.GetTeletubbies();
                foreach (var teletubby in teletubbies)
                {
                    TeletubbiesCollection.Add(teletubby);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }

        }

        //Command to add a new movie
        public ICommand AddCommand => new Command(async () =>
        {
            //Navigate to the AddCollectionView
            await Application.Current.MainPage.Navigation.PushAsync(new AddCollectionView());

            //****************
            // A messaging event is a way for different parts of your app to communicate.
            // It's like a message sent from one part to another to share data or trigger actions.
            // MessagingCenter helps subscribe to and send these events.
            // In this code, when you add a movie in AddCollectionView, it sends on "AddMovies" event.
            // CollectionsButtonsViewModel listens for this event and updates the movie list.
            //****************
            //Subscribe to the "AddMovies" messaging event to receive updated data from AddCollectionView
            MessagingCenter.Subscribe<Teletubbies>(this, "AddTeletubbies", async data =>
            {
                //Add the new movie data to the collection
                TeletubbiesCollection.Add(data);

                //Unsubscribe from the messaging event
                MessagingCenter.Unsubscribe<Teletubbies>(this, "AddTeletubbies");
            });
        });

        //Command to update a movie
        public ICommand UpdateCommand => new Command<Teletubbies>(async teletubby =>
        {
            //Get the index of the selected movie in the collection
            var index = TeletubbiesCollection.IndexOf(teletubby);

            //Navigate to the AddCollectionView
            await Application.Current.MainPage.Navigation.PushAsync(new EditCollectionView(teletubby));

            //****************
            // A messaging event is a way for different parts of your app to communicate.
            // It's like a message sent from one part to another to share data or trigger actions.
            // MessagingCenter helps subscribe to and send these events.
            // In this code, when you update a movie in EditCollectionView, it sends on "UpdateMovies" event.
            // CollectionsButtonsViewModel listens for this event and updates the movie list.
            //****************
            //Subscribe to the "UpdateMovies" messaging event to receive updated data from EditCollectionView
            MessagingCenter.Subscribe<Teletubbies>(this, "UpdateTeletubbies", updatedTeletubby =>
            {
                //Update the movie in the collection with the edited data
                TeletubbiesCollection[index] = updatedTeletubby;
            });
        });

        //Command to delete a movie
        public ICommand DeleteCommand => new Command<Teletubbies>(movie =>
        {
            //Remove the selected movie from the collection
            TeletubbiesCollection.Remove(movie);
        });
    }
}
