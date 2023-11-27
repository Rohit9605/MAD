using MyFirstMobileApp.Models.Entities;

namespace MyFirstMobileApp.ViewViewModels.CollectionsUpdatable.AddEdit;

public partial class EditCollectionView : ContentPage
{
	public EditCollectionView(Teletubbies tt)
	{
		InitializeComponent();
		BindingContext = new EditCollectionViewModel();
		MovieTitle.Text = tt.NameOfTeletubby;
	}
}