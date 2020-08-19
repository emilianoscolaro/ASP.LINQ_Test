using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace ASP.LINQ_Test.Models
{
    public class AreaModel
    {
        DataClasses1DataContext context = new DataClasses1DataContext();

        public List<area> ListaAreas()
        {
            List<area> Lista = new List<area>();
            var consulta = context.PrListarArea();

            foreach (var area in consulta)
            {
                area a = new area();

                a.are_cod = area.are_cod;
                a.are_des = area.are_des;

                Lista.Add(a);

            }

            return Lista;

        }


        public area BuscarArea(int codigo)
        {
            area a = new area();

            try
            {
                var consulta = context.PrBuscarArea(codigo);
                foreach (var area in consulta)
                {
                    a.are_cod = area.are_cod;
                    a.are_des = area.are_des;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return a;
        }

        public string InsertarArea(area a)
        {
            string resultado = string.Empty;

            try
            {
                context.PrInsertarArea(a.are_des);
                resultado = "OK";
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }
            return resultado;
        }

        public string ActualizarArea(area a)
        {
            string resultado = string.Empty;

            try
            {
                context.PrActualizarArea(a.are_cod,a.are_des);
                resultado = "OK";
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }
            return resultado;
        }


        public string EliminarArea(int codigo)
        {
            string resultado = string.Empty;

            try
            {
                context.PrEliminar(codigo);
                resultado = "OK";
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }

    }
}