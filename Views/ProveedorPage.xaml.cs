using EjercicioCRUDMvvm.ViewModels;

namespace EjercicioCRUDMvvm.Views
{
    public partial class ProveedorPage : ContentPage
    {
        public ProveedorPage()
        {
            InitializeComponent();
            var vm = (ProveedorViewModel)BindingContext;
            vm.LoadProveedoresCommand.Execute(null);
        }
    }
}
