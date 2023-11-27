using MyFirstMobileApp.Models.Entities;
using MyFirstMobileApp.ViewViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMobileApp.ViewViewModels.CollectionsContents.TeletubbiesCollection
{
    public class TeletubbiesViewModel : BaseViewModel
    {
        //ViewModel: Private fields
        private List<Teletubbies> _teletubbies;

        //ViewModel: Observable collection bound to the View
        //We use ObservableCollection to automatically update the View when the collection changes
        public ObservableCollection<Teletubbies> _teletubbyName { get; }

        public TeletubbiesViewModel()
        {
            //ViewModel: Setting the page title for the View
            Title = TitleTeletubbies.TTTitle;

            //ViewModel: Initialize the ObservableCollection
            _teletubbyName = new ObservableCollection<Teletubbies>();

            _teletubbies = Teletubbies.GetTeletubbies();
            this.LoadTeletubbies();
        }

        private void LoadTeletubbies()
        {
            try
            {
                //Clear the collection in the ViewModel
                _teletubbyName.Clear();

                foreach (var p in _teletubbies)
                {
                    //Add the NameOfMovie property of the individual movie in the ViewModel collection
                    _teletubbyName.Add(new Teletubbies { NameOfTeletubby = p.NameOfTeletubby});
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
