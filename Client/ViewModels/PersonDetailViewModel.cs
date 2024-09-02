using Client.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Controls;
using System.Text.Json;
using Client.Services;

namespace Client.ViewModels
{
    public class PersonDetailViewModel : INotifyPropertyChanged, IQueryAttributable
    {
        private int _id;
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private string _gender = string.Empty;
        private string _country = string.Empty;
        private int _age;
        private DateTime _date = DateTime.UtcNow;

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

        public string PersonInformation
        {
            get { return $"{Id}\t{FirstName} {LastName}"; }
        }

        private readonly IPersonService _personService;

        public PersonDetailViewModel(IPersonService personService)
        {
            _personService = personService;
        }

        private async Task GetPerson(int id)
        {
            var person = await _personService.GetPersonById(id);
            if (person != null)
            {
                MapPersonModelToPersonDetailViewModel(person);
            }
        }

        //private async Task UpdatePerson(PersonModel person)
        //{
        //    var personModel = await _personService.UpdatePerson(person);
        //    MapPersonModelToPersonDetailViewModel(personModel);
        //}
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

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var personId = query["PersonId"].ToString();
            if(int.TryParse(personId, out var selectedId))
            { 
                Id = selectedId;
                await GetPerson(Id);
            }
        }
    }
}
