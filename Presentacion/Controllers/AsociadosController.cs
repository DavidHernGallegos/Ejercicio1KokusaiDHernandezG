using Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.MSIdentity.Shared;
using Negocio;
using Newtonsoft.Json;
using System.Text;

namespace Presentacion.Controllers
{
    public class AsociadosController : Controller
    {
        private readonly IConfiguration _configuration;

        public AsociadosController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            Dictionary<string, object> result = Negocio.Asociado.GetAll();
            bool respuesta = (bool)result["Respuesta"];
            string mensaje = (string)result["Mensaje"];
            if (respuesta)
            {
                Negocio.Asociado asociado = (Negocio.Asociado)result["Asociado"];

                return View(asociado);
            }
            else
            {
                return View();
            }


        }


        [HttpGet]
        public IActionResult Form(int? IdAsociado) {

            Dictionary<string, object> diccionarioDep = Negocio.Departamento.GetAll();
            Negocio.Asociado asociado = new Negocio.Asociado();

            if (IdAsociado == null)
            {
                
                Negocio.Departamento departamento = (Negocio.Departamento)diccionarioDep["Departamento"];
                

               
                asociado.Departamentoo = departamento;



                return View(asociado);
            }
            else
            {

                Dictionary<string, object> diccionarioAsociado = Negocio.Asociado.GetById(IdAsociado.Value);
                asociado = (Negocio.Asociado)diccionarioAsociado["Asociado"];
                Dictionary<string, object> diccionarioDepId = Negocio.Departamento.GetById(asociado.Departamentoo.IdDepartamento.Value);

                Negocio.Departamento departamento = (Negocio.Departamento)diccionarioDep["Departamento"];
                Negocio.Departamento departamentoId = (Negocio.Departamento)diccionarioDepId["Departamentoo"];

                asociado = (Negocio.Asociado)diccionarioAsociado["Asociado"];
                asociado.Departamentoo = departamento;
                asociado.Departamentoo.IdDepartamento = departamentoId.IdDepartamento;

                return View(asociado);
            }
        
        }

        [HttpPost]
        public IActionResult Form(Negocio.Asociado asociado) {


            if (asociado.IdAsociado > 0)
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_configuration.GetValue<string>("ApiBaseUrl"));

                  
                    var responseTask = client.PostAsJsonAsync("Asociado/Update", asociado);

                    responseTask.Wait();

                    var respuesta = responseTask.Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
                        ViewBag.Mensaje = "El asociado se ha actualizado";
                        return PartialView("Modal");

                    }
                    else
                    {
                      
                        ViewBag.Mensaje = "El asociado no se pudo actualizar";
                        return PartialView("Modal");
                    }

                  
                }
            }
            else
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_configuration.GetValue<string>("ApiBaseUrl"));


                    var responseTask = client.PostAsJsonAsync("Asociado/Add", asociado);

                    responseTask.Wait();

                    var respuesta = responseTask.Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
                        ViewBag.Mensaje = "El asociado se ha Guardado";
                        return PartialView("Modal");

                    }
                    else
                    {

                        ViewBag.Mensaje = "El asociado no se pudo Guardar";
                        return PartialView("Modal");
                    }


                }

            }

        }


        public IActionResult Delete(int IdAsociado)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_configuration.GetValue<string>("ApiBaseUrl"));

                //var data = new Negocio.Asociado { IdAsociado = IdAsociado };

                //var jsonContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                var responseTask = client.DeleteAsync("Asociado/Delete?IdAsociado=" + IdAsociado);

                responseTask.Wait();

                var respuesta = responseTask.Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    ViewBag.Mensaje = "El asociado se ha eliminado";
                    return PartialView("Modal");

                }
                else
                {
                    //string exepcion = (string)result["Exception"];
                    ViewBag.Mensaje = "El asociado no se pudo eliminar";/*+ exepcion;*/
                    return PartialView("Modal");
                }
            }
        }
    }
}
