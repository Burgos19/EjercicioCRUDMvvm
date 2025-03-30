using System.Data.SqlTypes;

namespace EjercicioCRUDMvvm.Models
{
    public class Proveedor
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int Id { get; set; }

        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Empresa { get; set; }
    }
}
