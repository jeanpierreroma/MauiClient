using Client.ViewModels;
using Client.ViewModels.Base;

namespace Client.Views;

public partial class PersonDetailPage : ContentPage
{
	public PersonDetailPage(PersonDetailViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is not IViewModelBase ivmb)
        {
            return;
        }

        ivmb.InitializeAsyncCommand.Execute(null);
    }
}