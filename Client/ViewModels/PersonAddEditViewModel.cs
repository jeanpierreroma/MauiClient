using Client.Models;
using Client.Services;
using Client.ViewModels.Base;

namespace Client.ViewModels
{
    public class PersonAddEditViewModel : ViewModelBase, IQueryAttributable
    {
        private readonly IPersonService _personService;

        public PersonModel? personModel;

        private string _pageTitle = string.Empty;

        private int _id = -1; // default value
        private string? _firstName = string.Empty;
        private string? _lastName = string.Empty;
        private string? _gender = string.Empty;
        private string? _country = string.Empty;
        private int? _age;
        private DateTime? _date;

        public string PageTitle
        {
            get => _pageTitle;
            set
            {
                if(value.Equals(_pageTitle))
                {
                    _pageTitle = value;
                    OnPropertyChanged();
                }
            }
        }

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
        public string? FirstName
        {
            get => _firstName;
            set
            {
                if (!Equals(_firstName, value))
                {
                    _firstName = value;
                    OnPropertyChanged();
                }
            }
        }
        public string? LastName
        {
            get => _lastName;
            set
            {
                if (!Equals(_firstName, value))
                {
                    _lastName = value;
                    OnPropertyChanged();
                }
            }
        }
        public string? Gender
        {
            get => _gender;
            set
            {
                if (!Equals(_firstName, value))
                {
                    _gender = value;
                    OnPropertyChanged();
                }
            }
        }
        public string? Country
        {
            get => _country;
            set
            {
                if (!Equals(_firstName, value))
                {
                    _country = value;
                    OnPropertyChanged();
                }
            }
        }
        public int? Age
        {
            get => _age;
            set
            {
                if (!Equals(_firstName, value))
                {
                    _age = value;
                    OnPropertyChanged();
                }
            }
        }
        public DateTime? Date
        {
            get => _date;
            set
            {
                if (!Equals(_firstName, value))
                {
                    _date = value;
                    OnPropertyChanged();
                }
            }
        }

        public PersonAddEditViewModel(IPersonService personService)
        {
            _personService = personService;
        }

        public override async Task LoadAsync()
        {
            await Loading(
                async () =>
                {
                    if (personModel is null && Id != -1)
                    {
                        personModel = await _personService.GetPersonById(Id);
                    }
                    MapPerson(personModel);
                });
        }

        private void MapPerson(PersonModel? personModel)
        {
            if (personModel is not null)
            {
                Id = personModel.Id;
                FirstName = personModel.FirstName;
                LastName = personModel.LastName;
                Gender = personModel.Gender;
                Country = personModel.Country;
                Age = personModel.Age;
                Date = personModel.Date;
            }

            PageTitle = Id != -1 ? "Edit page" : "Add event";
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.Count > 0)
            {
                personModel = query["Person"] as PersonModel;
            }
        }
    }
}
