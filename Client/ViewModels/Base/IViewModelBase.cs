using System.Windows.Input;

namespace Client.ViewModels.Base
{
    public interface IViewModelBase
    {
        public ICommand InitializeAsyncCommand { get; }
    }
}
