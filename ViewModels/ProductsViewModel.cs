using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using MeuAppMaui.Models;

namespace MeuAppMaui.ViewModels
{
    public class ProductsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Product> AllProducts { get; } = new();
        public ObservableCollection<Product> FilteredProducts { get; } = new();

        private string _query = string.Empty;
        public string Query
        {
            get => _query;
            set
            {
                if (SetProperty(ref _query, value))
                    ApplyFilter(_query);
            }
        }

        public ProductsViewModel()
        {
            // Exemplo de produtos iniciais
            AllProducts.Add(new Product { Name = "Arroz Tipo 1", Category = "Alimentos", Price = 12.50m });
            AllProducts.Add(new Product { Name = "Feijão Carioca", Category = "Alimentos", Price = 8.90m });
            AllProducts.Add(new Product { Name = "Açúcar Cristal", Category = "Alimentos", Price = 5.20m });
            AllProducts.Add(new Product { Name = "Detergente Neutro", Category = "Limpeza", Price = 2.99m });

            ApplyFilter(""); // mostra todos no início
        }

        void ApplyFilter(string text)
        {
            var q = text?.Trim().ToLowerInvariant() ?? string.Empty;

            var matches = string.IsNullOrEmpty(q)
                ? AllProducts
                : new ObservableCollection<Product>(
                    AllProducts.Where(p =>
                        (p.Name?.ToLowerInvariant().Contains(q) ?? false) ||
                        (p.Category?.ToLowerInvariant().Contains(q) ?? false)
                    )
                  );

            FilteredProducts.Clear();
            foreach (var p in matches)
                FilteredProducts.Add(p);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string? name = null)
        {
            if (Equals(storage, value)) return false;
            storage = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            return true;
        }
    }
}
