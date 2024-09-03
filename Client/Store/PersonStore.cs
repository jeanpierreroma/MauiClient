using Client.Models;

namespace Client.Store
{
    public class PersonStore
    {
        public event Action? PersonAddedOrChanged;
        public void CreateOrChangePreson()
        {
            PersonAddedOrChanged?.Invoke();
        }
    }
}
