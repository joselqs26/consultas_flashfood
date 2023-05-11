using api_consulta.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace api_consulta.Controllers
{
    [ApiController]
    [Route("/")]
    public class Controlador : ControllerBase
    {
        [HttpGet(Name = "GetMensaje")]
            
        public async Task<ActionResult<string>> Get()
        {
            string mensaje = "hola a todos";
            return Ok(mensaje);            
        }
    }
}
