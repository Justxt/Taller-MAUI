namespace Notas
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Pages.NotePage), typeof(Pages.NotePage));
        }
    }
}
