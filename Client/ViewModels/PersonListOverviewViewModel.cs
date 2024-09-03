using CommunityToolkit.Maui.Core.Extensions;
using Client.Mappers;
using Client.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Client.Services;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.Messaging;
using Client.Messages;
using Client.Store;



namespace Client.ViewModels
{
    public class PersonListOverviewViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<PersonListItemViewModel> _people;

        private PersonListItemViewModel? _selectedPerson;

        private readonly IPersonService _personService;
        private readonly INavigationService _navigationService;
        private readonly PersonStore _personStore;

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
            INavigationService navigationService, 
            PersonStore personStore)
        {
            NavigateToSelectedDetailCommand = new Command(async () => await NavigateToSelectedDetail());
            NavigateToAddPersonCommand = new Command(async () => await NavigateToAddPerson());

            _personService = personService;
            _navigationService = navigationService;
            _personStore = personStore;

            _people = new();
            _personStore.PersonAddedOrChanged += OnPersonAddedOrChanged;
        }

        private void OnPersonAddedOrChanged()
        {
            People.Clear();
            GetPeople();
        }

        private void GetPeople()
        {
            List<PersonModel> people = _personService.GetPeople();
            UpdatePeopleList(people);
        }

        public async Task UploadFileAsync()
        {
            try
            {
                var result = await FilePicker.Default.PickAsync();
                if (result != null)
                {
                    var stream = await result.OpenReadAsync();

                    List<PersonModel> people = await _personService.UploadFile(stream, result.FileName);
                    UpdatePeopleList(people);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void UpdatePeopleList(List<PersonModel> people)
        {
            List<PersonListItemViewModel> listItems = people
                .Select((person, index) => PersonMapper.MapPersonModelToPersonListItemViewModel(person, index + 1))
                .ToList();

            People.Clear();
            People = listItems.ToObservableCollection();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
