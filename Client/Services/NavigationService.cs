namespace Client.Services
{
    public class NavigationService : INavigationService
    {
        public Task GoToPersonDetail(int id)
        {
            var parameters = new Dictionary<string, object> { {  "PersonId", id } };
            return Shell.Current.GoToAsync("person", parameters);
        }
    }
}
