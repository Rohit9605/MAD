namespace MyFirstMobileApp.ViewViewModels.CollectionsContents.TeletubbiesCollection;

public partial class TeletubbiesView : ContentPage
{
    public TeletubbiesView()
    {
        InitializeComponent();
        BindingContext = new TeletubbiesViewModel();
    }
}