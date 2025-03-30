using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EjercicioCRUDMvvm.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EjercicioCRUDMvvm.ViewModels
{
    public partial class ProveedorViewModel : ObservableObject
    {
        [ObservableProperty]
        private int id;

        [ObservableProperty]
        private string nombre;

        [ObservableProperty]
        private string telefono;

        [ObservableProperty]
        private string direccion;

        [ObservableProperty]
        private string empresa;

        [ObservableProperty]
        private Proveedor selectedProveedor;

        public ObservableCollection<Proveedor> Proveedores { get; } = new();

        public ProveedorViewModel()
        {
            LoadProveedoresCommand = new AsyncRelayCommand(LoadProveedores);
            SaveCommand = new AsyncRelayCommand(SaveProveedor);
            DeleteCommand = new AsyncRelayCommand(DeleteProveedor);
        }

        public ICommand LoadProveedoresCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; }

        private async Task LoadProveedores()
        {
            Proveedores.Clear();
            var proveedores = await App.Database.GetProveedoresAsync();
            foreach (var p in proveedores)
                Proveedores.Add(p);
        }

        private async Task SaveProveedor()
        {
            if (string.IsNullOrWhiteSpace(Nombre) ||
                string.IsNullOrWhiteSpace(Telefono) ||
                string.IsNullOrWhiteSpace(Direccion) ||
                string.IsNullOrWhiteSpace(Empresa))
            {
                await Shell.Current.DisplayAlert("Validación", "Todos los campos son obligatorios.", "OK");
                return;
            }

            var proveedor = new Proveedor
            {
                Id = Id,
                Nombre = Nombre,
                Telefono = Telefono,
                Direccion = Direccion,
                Empresa = Empresa
            };

            await App.Database.SaveProveedorAsync(proveedor);
            await LoadProveedores();
            ClearFields();
        }

        private async Task DeleteProveedor()
        {
            if (SelectedProveedor == null)
            {
                await Shell.Current.DisplayAlert("Advertencia", "Seleccione un proveedor para eliminar.", "OK");
                return;
            }

            await App.Database.DeleteProveedorAsync(SelectedProveedor);
            await LoadProveedores();
            ClearFields();
        }

        private void ClearFields()
        {
            Id = 0;
            Nombre = string.Empty;
            Telefono = string.Empty;
            Direccion = string.Empty;
            Empresa = string.Empty;
            SelectedProveedor = null;
        }
    }
}
