using Client.ViewModels;

namespace Client.Views;

public partial class PersonDetailPage : ContentPageBase
{
	public PersonDetailPage(PersonDetailViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}