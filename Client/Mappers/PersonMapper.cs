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
                personModel.Id!.Value,
                personModel.FirstName,
                personModel.LastName,
                personModel.Gender,
                personModel.Country,
                personModel.Age,
                personModel.Date,
                (ValidationStatusEnum)personModel.Status
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
        
        public static PersonModel MapPersonAddEditViewModeToPersonModel(PersonAddEditViewModel personAddEditViewModel)
        {
            return new PersonModel
            {
                Id = personAddEditViewModel.Id,
                FirstName = personAddEditViewModel.FirstName,
                LastName = personAddEditViewModel.LastName,
                Gender = personAddEditViewModel.Gender,
                Country = personAddEditViewModel.Country,
                Age = personAddEditViewModel.Age,
                Date = personAddEditViewModel.Date
            };
        }
    }
}
