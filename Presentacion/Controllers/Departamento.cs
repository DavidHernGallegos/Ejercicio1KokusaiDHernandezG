using Microsoft.AspNetCore.Mvc;

namespace Presentacion.Controllers
{
    public class Departamento : Controller
    {
        public IActionResult Index()
        {

            return View();
        }


        [HttpGet]
        public IActionResult GetAll()
        {

            Dictionary<string, object> result = Negocio.Departamento.GetAll();
            bool respuesta = (bool)result["Respuesta"];
            string mensaje = (string)result["Mensaje"];
            if (respuesta)
            {
                Negocio.Departamento asociado = (Negocio.Departamento)result["Departamento"];

                return View(asociado);
            }
            else
            {
                return View();
            }


        }


        [HttpGet]
        public IActionResult Form(int? IdDepartamento)
        {

            Dictionary<string, object> diccionarioDep = Negocio.Departamento.GetAll();
            Negocio.Departamento departamento = new Negocio.Departamento();

            if (IdDepartamento == null)
            {

   

                return View(departamento);
            }
            else
            {

                Dictionary<string, object> diccionario = Negocio.Departamento.GetById(IdDepartamento.Value);
                departamento = (Negocio.Departamento)diccionario["Departamentoo"];
            

                return View(departamento);
            }

        }


        [HttpPost]
        public IActionResult Form(Negocio.Departamento departamento)
        {


            if (departamento.IdDepartamento > 0)
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5233/api/");


                    var responseTask = client.PostAsJsonAsync("Departamentos/Update", departamento);

                    responseTask.Wait();

                    var respuesta = responseTask.Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
                        ViewBag.Mensaje = "El departamento se ha actualizado";
                        return PartialView("Modal");

                    }
                    else
                    {
                        //string exepcion = (string)result["Exception"];
                        ViewBag.Mensaje = "El departamento no se pudo actualizar";/*+ exepcion;*/
                        return PartialView("Modal");
                    }
                }
              }
            else
            {


                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5233/api/");


                    var responseTask = client.PostAsJsonAsync("Departamentos/Add", departamento);

                    responseTask.Wait();

                    var respuesta = responseTask.Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
                        ViewBag.Mensaje = "El departamento se ha agregado";
                        return PartialView("Modal");

                    }
                    else
                    {

                        ViewBag.Mensaje = "El departamento no se pudo agregar";
                        return PartialView("Modal");
                    }


                }

            }

        }


        public IActionResult Delete(int IdDepartamento)
        {
            using (HttpClient client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://localhost:5233/api/");

             
                var responseTask = client.DeleteAsync("Departamentos/Delete?IdDepartamento=" + IdDepartamento);

                responseTask.Wait();

                var respuesta = responseTask.Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    ViewBag.Mensaje = "El departamento se ha eliminado";
                    return PartialView("Modal");

                }
                else
                {
                
                    ViewBag.Mensaje = "El departamento no se pudo eliminar";
                    return PartialView("Modal");
                }
            }
        }
    }
}
