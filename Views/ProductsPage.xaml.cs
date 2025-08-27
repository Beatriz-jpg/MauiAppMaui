using MeuAppMaui.ViewModels;

namespace MeuAppMaui.Views
{
    public partial class ProductsPage : ContentPage
    {
        public ProductsPage()
        {
            InitializeComponent();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (BindingContext is ProductsViewModel vm)
            {
                vm.Query = e.NewTextValue ?? string.Empty;
            }
        }
    }
}
