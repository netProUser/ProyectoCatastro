using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Threading.Tasks;
using BE = MSI.Catastros.BusinessEntities;
using DA = MSI.Catastros.DataAccess;
using HP = MSI.Catastros.Helpers;
using EX = MSI.Catastros.Exceptions;

namespace MSI.Catastros.BusinessLogic
{
    public class SIC_UNIDINSTALACION
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/06/2018)
        //Utilizado por	: WebApi.SIC_UNIDINSTALACION.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_UNIDINSTALACION, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_UNIDINSTALACION entSIC_UNIDINSTALACION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDINSTALACION().Grabar(entSIC_UNIDINSTALACION);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/06/2018)
        //Utilizado por	: WebApi.SIC_UNIDINSTALACION.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_UNIDINSTALACION
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_UNIDINSTALACION entSIC_UNIDINSTALACION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDINSTALACION().Actualizar(entSIC_UNIDINSTALACION);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/06/2018)
        //Utilizado por	: WebApi.SIC_UNIDINSTALACION.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_UNIDINSTALACION
        /// </summary>
        public BE.SIC_UNIDINSTALACION Recuperar(BE.SIC_UNIDINSTALACION entSIC_UNIDINSTALACION)
        {
            BE.SIC_UNIDINSTALACION lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_UNIDINSTALACION().Recuperar(entSIC_UNIDINSTALACION);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/06/2018)
        //Utilizado por	: WebApi.SIC_UNIDINSTALACION.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_UNIDINSTALACION
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_UNIDINSTALACION entSIC_UNIDINSTALACION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDINSTALACION().Eliminar(entSIC_UNIDINSTALACION);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Quispe Ipanaque (06/07/2018)
        //Utilizado por	: WebApi.SIC_UNIDINSTALACION.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los registro de la tabla SIC_UNIDINSTALACION
        /// </summary>
        public ICollection<BE.SIC_UNIDINSTALACION> Listar(BE.SIC_UNIDINSTALACION entSIC_UNIDINSTALACION)
        {
            List<BE.SIC_UNIDINSTALACION> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_UNIDINSTALACION> entQuery = new DA.SIC_UNIDINSTALACION().Listar(entSIC_UNIDINSTALACION);
                if (entQuery != null)
                {
                    lisQuery = entQuery.ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        ///
        public ICollection<BE.SIC_UNIDINSTALACION> RecuperaInstalacionesHistoricasUnidades (BE.SIC_UNIDINSTALACION entSIC_UNIDINSTALACION)
        {
            List<BE.SIC_UNIDINSTALACION> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_UNIDINSTALACION> entQuery = new DA.SIC_UNIDINSTALACION().RecuperaInstalacionesHistoricasUnidades(entSIC_UNIDINSTALACION);
                if (entQuery != null)
                {
                    lisQuery = entQuery.ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }

        public string  ObtenerDescripcionUnidad(BE.SIC_UNIDINSTALACION entSIC_UNIDINSTALACION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            string DESCRIPCION;
            try
            {
                DESCRIPCION = new DA.SIC_UNIDINSTALACION().ObtenerDescripcionUnidad(entSIC_UNIDINSTALACION);
                //new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return DESCRIPCION;
        }
    }
}
