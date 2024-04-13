using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Aumentos
    {

        public static Dictionary<string,object> AgregarAumento(int idDepartamento, int porcentaje)
        {
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Resultado", false }, { "Mensaje", "" }  };

            try
            {
                using (Datos.Ejercicio1KukusaiContext context = new Datos.Ejercicio1KukusaiContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"CalcularAumentoSalario {idDepartamento}, {porcentaje}");
                    if(query > 0)
                    {
                        diccionario["Resultado"] = true;
                        diccionario["Mensaje"] = "Se actualizo el aumento";
                    }
                    else
                    {
                        diccionario["Mensaje"] = "Ne  se actualizo el aumento";
                    }
                }


            }catch (Exception e)
            {
                diccionario["Mensaje"] = "Ne  se actualizo el aumento";
            }

            return diccionario;
        }

       

    }
}
