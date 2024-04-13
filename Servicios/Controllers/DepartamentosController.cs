using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Servicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {



        [HttpPost]
        [Route("Add")]
        public IActionResult Add([FromBody] Negocio.Departamento departamento)
        {



            Dictionary<string, object> resultado = Negocio.Departamento.Add(departamento);
            bool respuesta = (bool)resultado["Respuesta"];
            string mensaje = (string)resultado["Mensaje"];
            if (respuesta)
            {


                return Ok(mensaje);
            }
            else
            {
                return BadRequest(mensaje);
            }

        }


        [HttpPost]
        [Route("Update")]
        public IActionResult Update([FromBody] Negocio.Departamento departamento)
        {
            


            Dictionary<string, object> resultado = Negocio.Departamento.Update(departamento);
            bool respuesta = (bool)resultado["Respuesta"];
            string mensaje = (string)resultado["Mensaje"];
            if (respuesta)
            {


                return Ok(mensaje);
            }
            else
            {
                return BadRequest(mensaje);
            }

        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int IdDepartamento)
        {

            Dictionary<string, object> resultado = Negocio.Departamento.Delete(IdDepartamento);
            bool respuesta = (bool)resultado["Respuesta"];
            string mensaje = (string)resultado["Mensaje"];
            if (respuesta)
            {


                return Ok(mensaje);
            }
            else
            {
                return BadRequest(mensaje);
            }

        }
    }
}
