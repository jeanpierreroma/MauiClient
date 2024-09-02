using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Client.ViewModels
{
    public class PersonListItemViewModel
    {
        private int _number;
        private int _id;
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private string _gender = string.Empty;
        private string _country = string.Empty;
        private int _age;
        private DateTime _date = DateTime.UtcNow;

        public int Number
        {
            get => _number;
            set
            {
                if (!value.Equals(_number))
                {
                    _number = value;
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
        public ValidationStatusEnum ValidationStatus { get; set; }

        public PersonListItemViewModel(
            int number,
            int id,
            string firstName,
            string lastName,
            string gender,
            string country,
            int age,
            DateTime date,
            ValidationStatusEnum isValid)
        {
            Number = number;
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Country = country;
            Age = age;
            Date = date;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
