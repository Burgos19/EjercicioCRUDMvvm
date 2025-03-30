using EjercicioCRUDMvvm.Services;
using System.IO;

namespace EjercicioCRUDMvvm
{
    public partial class App : Application
    {
        private static ProveedorDatabase _database;
        public static ProveedorDatabase Database
        {
            get
            {
                if (_database == null)
                {
                    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "proveedores.db3");
                    _database = new ProveedorDatabase(dbPath);
                }
                return _database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.ProveedorPage());

        }
    }
}
