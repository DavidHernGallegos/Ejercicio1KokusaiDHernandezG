using Datos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio;

namespace Servicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsociadoController : ControllerBase
    {

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            Dictionary<string, object> resultado = Negocio.Asociado.GetAll();
            bool respuesta = (bool)resultado["Respuesta"];
            string mensaje = (string)resultado["Mensaje"];
            if (respuesta)
            {
                Negocio.Asociado asociado = (Negocio.Asociado)resultado["Asociado"];

                return Ok(asociado);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add([FromBody]Negocio.Asociado asociado)
        {

            Dictionary<string, object> resultado = Negocio.Asociado.Add(asociado);
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
        public IActionResult Update([FromBody] Negocio.Asociado asociado)
        {
            Negocio.Asociado asociadoObj = new Negocio.Asociado
            {
                IdAsociado = asociado.IdAsociado,
                Nombre = asociado.Nombre,
                Salario = asociado.Salario,
                Departamentoo = new Negocio.Departamento
                {

                    IdDepartamento = asociado.Departamentoo.IdDepartamento
                }

            };

            





            Dictionary<string, object> resultado = Negocio.Asociado.Update(asociadoObj);
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
        public IActionResult Delete(int IdAsociado) {

            Dictionary<string, object> resultado = Negocio.Asociado.Delete(IdAsociado);
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
