using Client.Views;

namespace Client
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("person", typeof(PersonDetailPage));
        }
    }
}
