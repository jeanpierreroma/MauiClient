using Client.ViewModels;

namespace Client.Services
{
    public interface INavigationService
    {
        Task GoToPersonDetail(int id);
    }
}
