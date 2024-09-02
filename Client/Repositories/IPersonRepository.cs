using Client.Models;

namespace Client.Repositories
{
    public interface IPersonRepository
    {
        Task<List<PersonModel>> UploadFile(Stream streamFile, string fileName);
        Task<PersonModel> UpdatePerson(PersonModel person);
        Task<string> SavePeople(List<PersonModel> people);
    }
}
