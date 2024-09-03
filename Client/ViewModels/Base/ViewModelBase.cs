using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Client.ViewModels.Base
{
    public class ViewModelBase : IViewModelBase, INotifyPropertyChanged
    {
        private bool _isLoading;

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                if (!value.Equals(_isLoading))
                {
                    _isLoading = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand InitializeAsyncCommand { get; }

        public ViewModelBase()
        {
            InitializeAsyncCommand = new Command(
                async () =>
                {
                    IsLoading = true;
                    await Loading(LoadAsync);
                    IsLoading = false;
                });
        }

        protected async Task Loading(Func<Task> unitOfWork)
        {
            await unitOfWork();
        }

        public virtual Task LoadAsync()
        {
            return Task.CompletedTask;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
