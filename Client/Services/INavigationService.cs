using Client.Models;

namespace Client.Services
{
    public interface INavigationService
    {
        Task GoToPersonDetail(int id);
        Task GoToEditPerson(PersonModel personModel);
        Task GoToAddPerson();
        Task GoToOverview();
    }
}
