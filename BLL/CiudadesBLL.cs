using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WilsonGomez_P1_AP1.DAL;
using WilsonGomez_P1_AP1.Entidades;


namespace WilsonGomez_P1_AP1.BLL
{
    public class CiudadesBLL
    {
       
        /// <summary>
        /// Permite insertar o modificar una entidad(Ciudades) en la base de datos.
        /// </summary>
        /// <param name = "ciudades"> Es la entidad(Ciudades) que se desea Guardar.</param>
        public static bool Guardar(Ciudades ciudades)
        {
            if(!Existe(ciudades.CiudadID))
            {
                return Insertar(ciudades);
            }
            else
            {
                return Modificar(ciudades);
            }
        }

        /// <summary>
        /// Permite buscar una entidad(Ciudades) en la base de datos.
        /// </summary>
        /// <param name = "ciudadId"> Es el ID de la entidad(Ciudades) que se desea encontrar.</param>
        public static Ciudades Buscar(int ciudadId)
        {
            Ciudades ciudades;
            Contexto contexto = new Contexto();

            try
            {
                ciudades = contexto.ciudades.Find(ciudadId);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ciudades;
        }

        /// <summary>
        /// Permite eliminar una entidad(Ciudades) en la base de datos.
        /// </summary>
        /// <param name = "ciudadId"> Es el ID de la entidad(Ciudades) que se desea eliminar de la base de datos.</param>
        public static bool Eliminar(int ciudadId)
        {
            bool eliminado = false;
            Contexto contexto = new Contexto();

            try
            {
                var ciudades = contexto.ciudades.Find(ciudadId);

                if (ciudades != null)
                {
                    contexto.ciudades.Remove(ciudades);
                    eliminado = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return eliminado;
        }

        /// <summary>
        /// Permite insertar una entidad(Ciudades) en la base de datos.
        /// </summary>
        /// <param name = "ciudades"> Es la entidad(Ciudades) que se desea insertar.</param>
        private static bool Insertar(Ciudades ciudades)
        {
            bool insertado = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Add(ciudades);
                insertado = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return insertado;
        }

        /// <summary>
        /// Permite modificar una entidad(Ciudades) en la base de datos.
        /// </summary>
        /// <param name = "ciudades"> Es la entidad(Ciudades) que se desea modificar.</param>
        private static bool Modificar(Ciudades ciudades)
        {
            bool modificado = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(ciudades).State = EntityState.Modified;
                modificado = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return modificado;
        }

        /// <summary>
        /// Permite verificar la existencia de una entidad(Ciudades) en la base de datos.
        /// </summary>
        /// <param name = "ciudadId"> Es el ID de la entidad(Ciudades) de la cual se desea verificar la existencia.</param>
        public static bool Existe(int ciudadId)
        {
            bool encontrado = false;
            Contexto contexto = new Contexto();

            try
            {
                encontrado = contexto.ciudades.Any(e => e.CiudadID == ciudadId);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

         public static bool Existe(string NombreCiudad)
        {
            bool encontrado = false;
            Contexto contexto = new Contexto();

            try
            {
                encontrado = contexto.ciudades.Any(e => e.Nombres == NombreCiudad);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }
    
        /// <summary>
        /// Permite extraer una lista con las entidades(ciudades) que posee la base de datos.
        /// </summary>
        /// <param name = "criterio"> Es el criterio por el cual va a ser ordenada o extraida la lista.</param>
        public static List<Ciudades> GetList(Expression<Func<Ciudades, bool>> criterio)
        {
            List<Ciudades> lista = new List<Ciudades>();
            Contexto contexto = new Contexto();
            
            try
            {
                lista = contexto.ciudades.Where(criterio).AsNoTracking().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }
    }
}