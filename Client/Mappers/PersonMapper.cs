using Client.Models;
using Client.ViewModels;

namespace Client.Mappers
{
    public static class PersonMapper
    {
        public static PersonListItemViewModel MapPersonModelToPersonListItemViewModel(PersonModel personModel, int index)
        {
            return new PersonListItemViewModel(
                index,
                personModel.Id,
                personModel.FirstName,
                personModel.LastName,
                personModel.Gender,
                personModel.Country,
                personModel.Age,
                personModel.Date,
                (ValidationStatusEnum)personModel.Validation
            );
        }

        public static PersonModel MapPersonDetailViewModelToPersonModel(PersonDetailViewModel personDetailViewModel)
        {
            return new PersonModel
            {
                Id = personDetailViewModel.Id,
                FirstName = personDetailViewModel.FirstName,
                LastName = personDetailViewModel.LastName,
                Gender = personDetailViewModel.Gender,
                Country = personDetailViewModel.Country,
                Age = personDetailViewModel.Age,
                Date = personDetailViewModel.Date
            };
        }
    }
}
