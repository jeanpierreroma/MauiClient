﻿using Client.Models;

namespace Client.Services
{
    public interface IPersonService
    {
        Task<List<PersonModel>> UploadFile(Stream streamFile, string fileName);
        Task<PersonModel> UpdatePerson(PersonModel person);
        Task<string> SavePeople();

        Task<PersonModel> GetPersonById(int id);
        List<PersonModel> GetPeople();
    }
}
