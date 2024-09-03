using Client.Mappers;
using Client.Models;
using Client.Services;
using Client.ViewModels.Base;
using System.Windows.Input;

namespace Client.ViewModels
{
    public class PersonDetailViewModel : ViewModelBase, IQueryAttributable
    {
        private int _id;
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private string _gender = string.Empty;
        private string _country = string.Empty;
        private int _age;
        private DateTime _date = DateTime.UtcNow;

        private readonly INavigationService _navigationService;
        private readonly IPersonService _personService;


        public int Id
        {
            get => _id;
            set
            {
                if (!value.Equals(_id))
                {
                    _id = value;
                    OnPropertyChanged();
                }
            }
        }
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (!value.Equals(_firstName))
                {
                    _firstName = value;
                    OnPropertyChanged();
                }
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                if (!value.Equals(_lastName))
                {
                    _lastName = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Gender
        {
            get => _gender;
            set
            {
                if (!value.Equals(_gender))
                {
                    _gender = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Country
        {
            get => _country;
            set
            {
                if (!value.Equals(_country))
                {
                    _country = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Age
        {
            get => _age;
            set
            {
                if (!value.Equals(_age))
                {
                    _age = value;
                    OnPropertyChanged();
                }
            }
        }
        public DateTime Date
        {
            get => _date;
            set
            {
                if (!value.Equals(_date))
                {
                    _date = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand NavigateToEditPersonCommand { get; }

        private async Task NavigateToEditPerson()
        {
            var detailModel = PersonMapper.MapPersonDetailViewModelToPersonModel(this);
            await _navigationService.GoToEditPerson(detailModel);
        }


        public PersonDetailViewModel(
            IPersonService personService, 
            INavigationService navigationService)
        {
            NavigateToEditPersonCommand = new Command(async () => await NavigateToEditPerson());


            _personService = personService;
            _navigationService = navigationService;
        }

        private async Task GetPerson(int id)
        {
            var person = await _personService.GetPersonById(id);
            if (person != null)
            {
                MapPersonModelToPersonDetailViewModel(person);
            }
        }

        public override async Task LoadAsync()
        {
            await Loading(async () => await GetPerson(Id));
        }

        private void MapPersonModelToPersonDetailViewModel(PersonModel personModel)
        {
            Id = personModel.Id;
            FirstName = personModel.FirstName;
            LastName = personModel.LastName;
            Gender = personModel.Gender;
            Country = personModel.Country;
            Age = personModel.Age;
            Date = personModel.Date;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var personId = query["PersonId"].ToString();
            if(int.TryParse(personId, out var selectedId))
            { 
                Id = selectedId;
            }
        }
    }
}
