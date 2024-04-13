using Datos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Asociado
    {
        public int? IdAsociado { get; set; }

        public string? Nombre { get; set; }

        public decimal? Salario { get; set; }

        
        public Departamento? Departamentoo { get; set; }

        public List<object>? Asociados { get; set; }

        public static Dictionary<string,object> GetAll()
        {
            Asociado asociado = new Asociado(); 
            Dictionary<string,object> diccionario = new Dictionary<string, object> { {"Asociado", asociado},{"Respuesta", false },{"Mensaje", "" } };

            try
            {
                using(Datos.Ejercicio1KukusaiContext context = new Datos.Ejercicio1KukusaiContext())
                {
                    var query = (from asociadoT in context.Asociados
                                 join departamentoT in context.Departamentos on asociadoT.IdDepartamento equals departamentoT.IdDepartamento
                                 select new
                                 {
                                     IdAsociado = asociadoT.IdAsociado,
                                     NombreAsociado = asociadoT.Nombre,
                                     IdDepartamento = departamentoT.IdDepartamento,
                                     NombreDepartamento = departamentoT.Nombre,
                                     Salario = asociadoT.Salario
                                 }).ToList();

                    if(query.Count > 0 )
                    {
                        asociado.Asociados = new List<object>();
                        foreach (var item in query)
                        {
                            Asociado asociadoObj = new Asociado();
                            asociadoObj.IdAsociado = item.IdAsociado;
                            asociadoObj.Nombre = item.NombreAsociado;
                            asociadoObj.Departamentoo = new Departamento();
                            asociadoObj.Departamentoo.IdDepartamento = item.IdDepartamento;
                            asociadoObj.Departamentoo.Nombre = item.NombreDepartamento;
                            asociadoObj.Salario = item.Salario;

                            asociado.Asociados.Add(asociadoObj);
                        }

                        diccionario["Asociado"] = asociado;
                        diccionario["Respuesta"] = true;
                        diccionario["Mensaje"] = "Se cargaron todos los datos";
                    }
                    else
                    {
                        diccionario["Mensaje"] = "No se cargaron todos los datos";
                    }
                }


            }
            catch(Exception ex) 
            {
                diccionario["Mensaje"] = "No se cargaron todos los datos";
            }

            return diccionario;

        }



        public static Dictionary<string, object> Add(Negocio.Asociado asociado)
        {
       
            Dictionary<string, object> diccionario = new Dictionary<string, object> {{ "Respuesta", false }, { "Mensaje", "" } };

            try
            {
                using (Datos.Ejercicio1KukusaiContext context = new Datos.Ejercicio1KukusaiContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"AddAsociado '{asociado.Nombre}', {asociado.Salario}, {asociado.Departamentoo.IdDepartamento} ");
                    if (query != 0)
                    {
                       


                   
                        diccionario["Respuesta"] = true;
                        diccionario["Mensaje"] = "Se guardaron todos los datos";
                    }
                    else
                    {
                        diccionario["Mensaje"] = "No se guardaron todos los datos";
                    }
                }


            }
            catch (Exception ex)
            {
                diccionario["Mensaje"] = "No se guardaron todos los datos";
            }

            return diccionario;

        }



        public static Dictionary<string, object> GetById(int IdAsociado)
        {
            Asociado asociado = new Asociado();
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Asociado", asociado }, { "Respuesta", false }, { "Mensaje", "" } };

            try
            {
                using (Datos.Ejercicio1KukusaiContext context = new Datos.Ejercicio1KukusaiContext())
                {
                    var query = (from asociadoT in context.Asociados
                                 join departamentoT in context.Departamentos on asociadoT.IdDepartamento equals departamentoT.IdDepartamento
                                 where asociadoT.IdAsociado == IdAsociado
                                 select new
                                 {
                                     IdAsociado = asociadoT.IdAsociado,
                                     NombreAsociado = asociadoT.Nombre,
                                     IdDepartamento = departamentoT.IdDepartamento,
                                     NombreDepartamento = departamentoT.Nombre,
                                     Salario =  asociadoT.Salario,
                                 }).SingleOrDefault();

                    if (query != null)
                    {
                      
                       
                            
                            asociado.IdAsociado = query.IdAsociado;
                            asociado.Nombre = query.NombreAsociado;
                            asociado.Departamentoo = new Departamento();
                            asociado.Departamentoo.IdDepartamento = query.IdDepartamento;
                            asociado.Departamentoo.Nombre = query.NombreDepartamento;
                            asociado.Salario = query.Salario;

                        
                        

                        diccionario["Asociado"] = asociado;
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


        public static Dictionary<string, object> Update(Negocio.Asociado asociado)
        {

            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Respuesta", false }, { "Mensaje", "" } };

            try
            {
                using (Datos.Ejercicio1KukusaiContext context = new Datos.Ejercicio1KukusaiContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"UpdateAsociado {asociado.IdAsociado} ,'{asociado.Nombre}', {asociado.Salario}, {asociado.Departamentoo.IdDepartamento} ");
                    if (query != 0)
                    {




                        diccionario["Respuesta"] = true;
                        diccionario["Mensaje"] = "Se guardaron todos los datos";
                    }
                    else
                    {
                        diccionario["Mensaje"] = "No se guardaron todos los datos";
                    }
                }


            }
            catch (Exception ex)
            {
                diccionario["Mensaje"] = "No se guardaron todos los datos";
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

                    var query = context.Database.ExecuteSqlRaw($"[DeleteAsosciado] {id}");
            
                     if (query >0)
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




    }
}
