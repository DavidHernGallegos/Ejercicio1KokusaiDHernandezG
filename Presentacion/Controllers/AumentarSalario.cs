using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;

namespace Presentacion.Controllers
{
    public class AumentarSalario: Controller
    {

        public IActionResult VistaAumento()
        {

            Dictionary<string,object> diccionario =  Negocio.Departamento.GetAll();
            bool respuesta = (bool)diccionario["Respuesta"];
            string mensaje = (string)diccionario["Mensaje"];
            Negocio.Departamento departamento = (Negocio.Departamento)diccionario["Departamento"];
            if (respuesta)
            {
                return View(departamento);
            }
            else
            {
                return PartialView ("Modal");
            }
        }

        [HttpPost]
        public IActionResult AumentarSalarioMetodo(List<string> departamentos, int porcentaje)
        {

            Dictionary<string, object> diccionario = new Dictionary<string, object>();
            foreach (string dep in departamentos)
            {
                int depObj = int.Parse(dep);

                 diccionario= Negocio.Aumentos.AgregarAumento(depObj, porcentaje);
               
            }

            bool respuesta = (bool)diccionario["Resultado"];
            string mensaje = (string)diccionario["Mensaje"];
            if (respuesta)
            {
                ViewBag.Mensaje = $"Se hizo un aumento del {porcentaje}";
                return PartialView("Modal");
            }
            else
            {
                return View();
            }

           

           

        }
       
    }
}
