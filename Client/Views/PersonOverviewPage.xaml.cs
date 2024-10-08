using Client.ViewModels;

namespace Client.Views;

public partial class PersonOverviewPage : ContentPage
{
    private readonly PersonListOverviewViewModel _vm;

    public PersonOverviewPage(PersonListOverviewViewModel vm)
	{
		InitializeComponent();

        BindingContext = vm;
        _vm = vm;
    }

    private async void OnUploadFileClicked(object sender, EventArgs e)
    {
        try
        {
            await _vm.UploadFileAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "Ok");
        }
    }

    private async void OnSaveFileClicked(object sender, EventArgs e)
    {
        try
        {
            var response = await _vm.SaveDataAsync();
            await DisplayAlert("Response from Server", response, "Ok");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "Ok");
        }
    }
}