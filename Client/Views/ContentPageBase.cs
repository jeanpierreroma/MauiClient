using Client.ViewModels.Base;

namespace Client.Views
{
    public class ContentPageBase : ContentPage
    {
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
}
