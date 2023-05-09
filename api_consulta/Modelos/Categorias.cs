using System.ComponentModel.DataAnnotations.Schema;

namespace api_consulta.Modelos
{
    [Table("Categorias")]
    public class Categorias
    {
        public string NombreCategoria { get; set; }
    }
}