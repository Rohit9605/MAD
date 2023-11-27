using MyFirstMobileApp.Models;
using MyFirstMobileApp.Models.Entities;
using MyFirstMobileApp.ViewViewModels.Base;
using MyFirstMobileApp.ViewViewModels.CollectionsUpdatable.AddEdit;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace MyFirstMobileApp.ViewViewModels.CollectionsContents.CollectionsUpdatable
{
    public class CollectionsButtonsViewModel : BaseViewModel
    {
        public ObservableCollection<Teletubbies> SWteletubbysCollection { get; set; }

        public CollectionsButtonsViewModel() 
        {
            //Set the title for this view
            Title = TitleCollectionsButtons.ButtonsTitle;

            //Create a new ObservableCollection to store teletubbys
            SWteletubbysCollection = new ObservableCollection<Teletubbies>();

            //Load teletubbys from the data source
            Loadteletubbys();
        }

        private void Loadteletubbys()
        {
            IsBusy = true;

            try
            {
                //Clear the existing collection
                SWteletubbysCollection.Clear();

                //Get a list of Star Wars teletubbys and add them to the collection
                var starWarsteletubbys = Teletubbies.GetTeletubbies();
                foreach(var teletubby in starWarsteletubbys)
                {
                    SWteletubbysCollection.Add(teletubby);
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

        //Command to add a new teletubby
        public ICommand AddCommand => new Command(async () =>
        {
            //Navigate to the AddCollectionView
            await Application.Current.MainPage.Navigation.PushAsync(new AddCollectionView());

            //****************
            // A messaging event is a way for different parts of your app to communicate.
            // It's like a message sent from one part to another to share data or trigger actions.
            // MessagingCenter helps subscribe to and send these events.
            // In this code, when you add a teletubby in AddCollectionView, it sends on "AddTeletubbies" event.
            // CollectionsButtonsViewModel listens for this event and updates the teletubby list.
            //****************
            //Subscribe to the "AddTeletubbies" messaging event to receive updated data from AddCollectionView
            MessagingCenter.Subscribe<Teletubbies>(this, "AddTeletubbies", async data =>
            {
                //Add the new teletubby data to the collection
                SWteletubbysCollection.Add(data);

                //Unsubscribe from the messaging event
                MessagingCenter.Unsubscribe<Teletubbies>(this, "AddTeletubbies");
            });
        });

        //Command to update a teletubby
        public ICommand UpdateCommand => new Command<Teletubbies>(async teletubby =>
        {
            //Get the index of the selected teletubby in the collection
            var index = SWteletubbysCollection.IndexOf(teletubby);
            
            //Navigate to the AddCollectionView
            await Application.Current.MainPage.Navigation.PushAsync(new EditCollectionView(teletubby));

            //****************
            // A messaging event is a way for different parts of your app to communicate.
            // It's like a message sent from one part to another to share data or trigger actions.
            // MessagingCenter helps subscribe to and send these events.
            // In this code, when you update a teletubby in EditCollectionView, it sends on "Updateteletubbys" event.
            // CollectionsButtonsViewModel listens for this event and updates the teletubby list.
            //****************
            //Subscribe to the "Updateteletubbys" messaging event to receive updated data from EditCollectionView
            MessagingCenter.Subscribe<Teletubbies>(this, "UpdateTeletubbies", updatedTeletubby =>
            {
                //Update the teletubby in the collection with the edited data
                SWteletubbysCollection[index] = updatedTeletubby;
            });
        });

        //Command to delete a teletubby
        public ICommand DeleteCommand => new Command<Teletubbies>(teletubby =>
        {
            //Remove the selected teletubby from the collection
            SWteletubbysCollection.Remove(teletubby);
        });
    }
}
