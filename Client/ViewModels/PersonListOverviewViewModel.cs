using CommunityToolkit.Maui.Core.Extensions;
using Client.Mappers;
using Client.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Client.Services;
using System.Runtime.CompilerServices;



namespace Client.ViewModels
{
    public class PersonListOverviewViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<PersonListItemViewModel> _people = new();

        private PersonListItemViewModel? _selectedPerson;

        private readonly IPersonService _personService;
        private readonly INavigationService _navigationService;

        public ICommand NavigateToSelectedDetailCommand { get; }
        public ICommand NavigateToAddPersonCommand { get; }

        private async Task NavigateToSelectedDetail()
        {
            if (SelectedPerson is not null)
            {
                await _navigationService.GoToPersonDetail(SelectedPerson.Id);
                SelectedPerson = null;
            }
        }

        private async Task NavigateToAddPerson()
        {
            await _navigationService.GoToAddPerson();
        }

        public ObservableCollection<PersonListItemViewModel> People
        {
            get => _people;
            set
            {
                if (!value.Equals(_people))
                {
                    _people = value;
                    OnPropertyChanged();
                }
            }
        }

        public PersonListItemViewModel? SelectedPerson
        {
            get => _selectedPerson;
            set
            {
                if (!Equals(value, _selectedPerson))
                {
                    _selectedPerson = value;
                    OnPropertyChanged();
                }
            }
        }

        public PersonListOverviewViewModel(
            IPersonService personService,
            INavigationService navigationService)
        {
            NavigateToSelectedDetailCommand = new Command(async () => await NavigateToSelectedDetail());
            NavigateToAddPersonCommand = new Command(async () => await NavigateToAddPerson());

            _personService = personService;
            _navigationService = navigationService;
        }

        public async Task UploadFileASync()
        {
            try
            {
                var result = await FilePicker.Default.PickAsync();
                if (result != null)
                {
                    var stream = await result.OpenReadAsync();

                    List<PersonModel> people = await _personService.UploadFile(stream, result.FileName);

                    List<PersonListItemViewModel> listItems = new();
                    int index = 1;
                    foreach (var person in people.Take(100))
                    {
                        listItems.Add(PersonMapper.MapPersonModelToPersonListItemViewModel(person, index++));
                    }

                    People.Clear();
                    People = listItems.ToObservableCollection();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
