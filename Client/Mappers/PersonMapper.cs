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
    }
}
