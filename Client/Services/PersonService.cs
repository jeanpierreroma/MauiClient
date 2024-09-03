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

        public Task<string> SavePeople(List<PersonModel> people)
        {
            return _personRepository.SavePeople(people);
        }

        public Task<PersonModel> UpdatePerson(PersonModel person)
        {
            return _personRepository.UpdatePerson(person);
        }

        public async Task<List<PersonModel>> UploadFile(Stream streamFile, string fileName)
        {
            _people = await _personRepository.UploadFile(streamFile, fileName);
            return _people;
        }

        public async Task<PersonModel> GetPersonById(int id)
        {
            return await Task.FromResult(_people.First(p => p.Id == id));
        }
    }
}
