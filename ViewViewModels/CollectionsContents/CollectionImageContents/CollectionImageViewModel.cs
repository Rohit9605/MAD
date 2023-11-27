using MyFirstMobileApp.Models;
using MyFirstMobileApp.Models.Entities;
using MyFirstMobileApp.ViewViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMobileApp.ViewViewModels.CollectionsContents.CollectionImageContents
{
    public class CollectionImageViewModel : BaseViewModel
    {
        public ObservableCollection<ActorCharacterInfo> TeletubbiesCollection { get; }
        private List<ActorCharacterInfo> _teletubbies;

        public CollectionImageViewModel()
        {
            Title = TitleCollectionImages.CharactersImagesTitle;

            //Instantiate Observable SWCollection
            TeletubbiesCollection = new ObservableCollection<ActorCharacterInfo>();
            _teletubbies = ActorCharacterInfo.GetSampleCharacterData();
            this.loadTeletubbies();
        }
        
        private void loadTeletubbies()
        {
            try
            {
                TeletubbiesCollection.Clear();
                foreach (var s in _teletubbies)
                {
                    TeletubbiesCollection.Add(s);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
