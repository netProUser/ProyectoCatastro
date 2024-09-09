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
    public class SIC_UNIDADAUTOEDIF
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Quispe Ipanaque (26/07/2018)
        //Utilizado por	: WebApi.SIC_UNIDADAUTOEDIF.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_UNIDADAUTOEDIF, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_UNIDADAUTOEDIF entSIC_UNIDADAUTOEDIF)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDADAUTOEDIF().Grabar(entSIC_UNIDADAUTOEDIF);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Quispe Ipanaque (26/07/2018)
        //Utilizado por	: WebApi.SIC_UNIDADAUTOEDIF.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_UNIDADAUTOEDIF
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_UNIDADAUTOEDIF entSIC_UNIDADAUTOEDIF)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDADAUTOEDIF().Actualizar(entSIC_UNIDADAUTOEDIF);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Quispe Ipanaque (26/07/2018)
        //Utilizado por	: WebApi.SIC_UNIDADAUTOEDIF.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_UNIDADAUTOEDIF
        /// </summary>
        public BE.SIC_UNIDADAUTOEDIF Recuperar(BE.SIC_UNIDADAUTOEDIF entSIC_UNIDADAUTOEDIF)
        {
            BE.SIC_UNIDADAUTOEDIF lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_UNIDADAUTOEDIF().Recuperar(entSIC_UNIDADAUTOEDIF);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Quispe Ipanaque (26/07/2018)
        //Utilizado por	: WebApi.SIC_UNIDADAUTOEDIF.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_UNIDADAUTOEDIF
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_UNIDADAUTOEDIF entSIC_UNIDADAUTOEDIF)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDADAUTOEDIF().Eliminar(entSIC_UNIDADAUTOEDIF);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Quispe Ipaaque (25/07/2018)
        //Utilizado por	: WebApi.SIC_UNIDADAUTOEDIF.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los registro de la tabla SIC_UNIDADAUTOEDIF
        /// </summary>
        public ICollection<BE.SIC_UNIDADAUTOEDIF> Listar(BE.SIC_UNIDADAUTOEDIF entSIC_UNIDADAUTOEDIF)
        {
            List<BE.SIC_UNIDADAUTOEDIF> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_UNIDADAUTOEDIF> entQuery = new DA.SIC_UNIDADAUTOEDIF().Listar(entSIC_UNIDADAUTOEDIF);
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
        
         public ICollection<BE.SIC_UNIDADAUTOEDIF> CargarUnidadObrasPrivadasHistoricas(BE.SIC_UNIDADAUTOEDIF entSIC_UNIDADAUTOEDIF)
        {
            List<BE.SIC_UNIDADAUTOEDIF> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_UNIDADAUTOEDIF> entQuery = new DA.SIC_UNIDADAUTOEDIF().CargarUnidadObrasPrivadasHistoricas(entSIC_UNIDADAUTOEDIF);
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
    }
}
