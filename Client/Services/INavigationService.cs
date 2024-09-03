using Client.Models;
using Client.ViewModels;

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
