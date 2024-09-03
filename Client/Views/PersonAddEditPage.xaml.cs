using Client.ViewModels;

namespace Client.Views;

public partial class PersonAddEditPage : ContentPageBase
{
	public PersonAddEditPage(PersonAddEditViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}