using Client.ViewModels;

namespace Client.Views;

public partial class PersonDetailPage : ContentPage
{
	public PersonDetailPage(PersonDetailViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}