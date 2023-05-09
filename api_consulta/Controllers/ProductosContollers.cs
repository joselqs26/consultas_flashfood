using api_consulta.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace api_consulta.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductosContollers : ControllerBase
    {
        [HttpGet(Name = "GetProductos")]
        public async Task<ActionResult<IEnumerable<Productos>>> Get()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "serverdb-flashfood.database.windows.net";
            builder.UserID = "adminServer";
            builder.Password = "FlashFood123*";
            builder.InitialCatalog = "sqlDatabase-FlashFood";

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT p.*, c.NombreCategoria AS NombreCategoria FROM [dbo].[Productos] p JOIN [dbo].[Categorias] c ON p.IdCategorias = c.IdCategorias";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    List<Productos> result = new List<Productos>();

                    while (await reader.ReadAsync())
                    {
                        Productos item = new Productos
                        {
                            // Lee los valores de las columnas y asigna los valores a las propiedades de TuModelo
                            IdProducto = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Descripcion = reader.GetString(2),
                            Precio = (float)reader.GetSqlDouble(3),

                            NombreCategoria = reader.GetString(5)


                            // ...
                        };
                        result.Add(item);
                    }

                    return result;
                }
            }
        }
    }
}