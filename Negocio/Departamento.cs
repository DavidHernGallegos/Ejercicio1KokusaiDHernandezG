using Datos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Departamento
    {
        public int? IdDepartamento { get; set; }

        public string? Nombre { get; set; }

        public List<object>? Departamentos { get; set; }



        public static Dictionary<string, object> GetAll()
        {
            Departamento departamento = new Departamento();
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Departamentoo", departamento }, { "Respuesta", false }, { "Mensaje", "" } };

            try
            {
                using (Datos.Ejercicio1KukusaiContext context = new Datos.Ejercicio1KukusaiContext())
                {
                    var query = (from departamentot in context.Departamentos

                                 select new
                                 {
                                     IdDepartamento = departamentot.IdDepartamento,
                                     NombreDepartamento = departamentot.Nombre

                                 }).ToList();

                    if (query.Count > 0)
                    {
                        departamento.Departamentos = new List<object>();
                        foreach (var item in query)
                        {
                            Departamento DepartaemntoObj = new Departamento();
                            DepartaemntoObj.IdDepartamento = item.IdDepartamento;
                            DepartaemntoObj.Nombre = item.NombreDepartamento;


                            departamento.Departamentos.Add(DepartaemntoObj);
                        }

                        diccionario["Departamentoo"] = departamento;
                        diccionario["Respuesta"] = true;
                        diccionario["Mensaje"] = "Se cargaron todos los datos";
                    }
                    else
                    {
                        diccionario["Mensaje"] = "No se cargaron todos los datos";
                    }
                }


            }
            catch (Exception ex)
            {
                diccionario["Mensaje"] = "No se cargaron todos los datos";
            }

            return diccionario;

        }



        public static Dictionary<string, object> Delete(int id)
        {

            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Respuesta", false }, { "Mensaje", "" } };

            try
            {

                using (Datos.Ejercicio1KukusaiContext context = new Datos.Ejercicio1KukusaiContext())
                {

                    var query = context.Database.ExecuteSqlRaw($"Delete {id}");

                    if (query > 0)
                    {

                        diccionario["Respuesta"] = true;
                        diccionario["Mensaje"] = "Se elimino el registro";

                    }
                    else
                    {
                        diccionario["Mensaje"] = "No se elimino el registro";

                    }

                }
            }
            catch (Exception e)
            {

                diccionario["Mensaje"] = "Se elimino el registro" + e;
            }

            return diccionario;

}


        public static Dictionary<string, object> Add(Departamento departamento)
        {

            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Departamentoo", departamento }, { "Respuesta", false }, { "Mensaje", "" } };

            try
            {

                using (Datos.Ejercicio1KukusaiContext context = new Datos.Ejercicio1KukusaiContext())
                {

                    var query = context.Database.ExecuteSqlRaw($"Add '{departamento.Nombre}'");

                    if (query > 0)
                    {


                        diccionario["Respuesta"] = true;
                        diccionario["Mensaje"] = "Se agrego el registro";

                    }
                    else
                    {
                        diccionario["Mensaje"] = "No se agrego el registro";

                    }

                }
            }
            catch (Exception e)
            {

                diccionario["Mensaje"] = "Se agrego el registro" + e;
            }

            return diccionario;


}



        public static Dictionary<string, object> Update(Departamento departamento)
        {

            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Departamentoo", departamento }, { "Respuesta", false }, { "Mensaje", "" } };

            try
            {

                using (Datos.Ejercicio1KukusaiContext context = new Datos.Ejercicio1KukusaiContext())
                {

                    var query = context.Database.ExecuteSqlRaw($"Update {departamento.IdDepartamento}, '{departamento.Nombre}'");

                    if (query > 0)
                    {


                        diccionario["Respuesta"] = true;
                        diccionario["Mensaje"] = "Se actualizo el registro";

                    }
                    else
                    {
                        diccionario["Mensaje"] = "No se actualizo el registro";

                    }

                }
            }
            catch (Exception e)
            {

                diccionario["Mensaje"] = "Se actualizo el registro" + e;
            }

            return diccionario;


}




        public static Dictionary<string, object> GetById(int idDepartamento)
        {
            Negocio.Departamento departamento = new Departamento();

            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Departamentoo", departamento }, { "Respuesta", false }, { "Mensaje", "" } };

            try
            {

                using (Datos.Ejercicio1KukusaiContext context = new Datos.Ejercicio1KukusaiContext())
                {

                    var query = (from departamentoT in context.Departamentos
                                 where departamentoT.IdDepartamento == idDepartamento
                                 select new
                                 {
                                     IdDepartamento = departamentoT.IdDepartamento,
                                     Nombre = departamentoT.Nombre
                                 }).SingleOrDefault();

                    if (query != null)
                    {

                        departamento.IdDepartamento = query.IdDepartamento;
                        departamento.Nombre = query.Nombre;



                        diccionario["Departamentoo"] = departamento;
                        diccionario["Respuesta"] = true;
                        diccionario["Mensaje"] = "Se agrego el registro";

                    }
                    else
                    {
                        diccionario["Mensaje"] = "No se agrego el registro";

                    }

                }
            }
            catch (Exception e)
            {

                diccionario["Mensaje"] = "Se agrego el registro" + e;
            }

            return diccionario;

        }
    }
}
