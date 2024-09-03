using Client.Models;
using Client.Repositories;

namespace Client.Services
{
    public class PersonService : IPersonService
    {
        private List<PersonModel> _people = new();
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public Task<string> SavePeople()
        {
            return _personRepository.SavePeople(_people);
        }

        public async Task<PersonModel> UpdatePerson(PersonModel person)
        {
            PersonModel? updatedPerson = await _personRepository.UpdatePerson(person);

            PersonModel? existingPerson = _people.FirstOrDefault(p => p.Id == updatedPerson.Id);

            if (existingPerson != null)
            {
                existingPerson.FirstName = updatedPerson.FirstName;
                existingPerson.LastName = updatedPerson.LastName;
                existingPerson.Age = updatedPerson.Age;
                existingPerson.Gender = updatedPerson.Gender;
                existingPerson.Date = updatedPerson.Date;
                existingPerson.Status = updatedPerson.Status;
            }
            else
            {
                _people.Add(updatedPerson);
            }

            return updatedPerson;
        }

        public async Task<List<PersonModel>> UploadFile(Stream streamFile, string fileName)
        {
            _people = (await _personRepository.UploadFile(streamFile, fileName)).Take(100).ToList();
            return _people;
        }

        public async Task<PersonModel> GetPersonById(int id)
        {
            return await Task.FromResult(_people.First(p => p.Id == id));
        }

        public List<PersonModel> GetPeople()
        {
            return _people;
        }
    }
}
