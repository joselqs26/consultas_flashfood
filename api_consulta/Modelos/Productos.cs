using System.ComponentModel.DataAnnotations.Schema;

namespace api_consulta.Modelos
{
    [Table("Productos" + "Categorias")]

    public class Productos
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        //public int IdCategorias { get; set; }
        //public Categorias Categorias { get; internal set; }
        public string NombreCategoria { get; set; }
    }
}
