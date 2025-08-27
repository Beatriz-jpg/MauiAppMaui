namespace MeuAppMaui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            // cria uma janela com a página inicial
            return new Window(new NavigationPage(new Views.ProductsPage()));
        }
    }
}
