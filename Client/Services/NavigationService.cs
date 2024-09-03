using Client.Models;

namespace Client.Services
{
    public class NavigationService : INavigationService
    {
        public Task GoToAddPerson()
        {
            return Shell.Current.GoToAsync("person/add");
        }

        public async Task GoToEditPerson(PersonModel personModel)
        {
            var navigationParameter = new ShellNavigationQueryParameters
            {
                { "Person", personModel }
            };

            await Shell.Current.GoToAsync("person/edit", navigationParameter);
        }

        public Task GoToOverview()
        {
            return Shell.Current.GoToAsync("//overview");
        }

        public Task GoToPersonDetail(int id)
        {
            var parameters = new Dictionary<string, object> { {  "PersonId", id } };
            return Shell.Current.GoToAsync("person", parameters);
        }
    }
}
