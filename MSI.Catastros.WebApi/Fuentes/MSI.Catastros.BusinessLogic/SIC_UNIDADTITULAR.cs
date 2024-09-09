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
    public class SIC_UNIDADTITULAR
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/06/2018)
        //Utilizado por	: WebApi.SIC_UNIDADTITULAR.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_UNIDADTITULAR, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_UNIDADTITULAR entSIC_UNIDADTITULAR)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDADTITULAR().Grabar(entSIC_UNIDADTITULAR);
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
        //Utilizado por	: WebApi.SIC_UNIDADTITULAR.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_UNIDADTITULAR
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_UNIDADTITULAR entSIC_UNIDADTITULAR)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDADTITULAR().Actualizar(entSIC_UNIDADTITULAR);
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
        //Utilizado por	: WebApi.SIC_UNIDADTITULAR.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_UNIDADTITULAR
        /// </summary>
        public BE.SIC_UNIDADTITULAR Recuperar(BE.SIC_UNIDADTITULAR entSIC_UNIDADTITULAR)
        {
            BE.SIC_UNIDADTITULAR lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_UNIDADTITULAR().Recuperar(entSIC_UNIDADTITULAR);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/06/2018)
        //Utilizado por	: WebApi.SIC_UNIDADTITULAR.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_UNIDADTITULAR
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_UNIDADTITULAR entSIC_UNIDADTITULAR)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDADTITULAR().Eliminar(entSIC_UNIDADTITULAR);
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
        //Utilizado por	: WebApi.SIC_UNIDADTITULAR.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los registro de la tabla SIC_UNIDADTITULAR
        /// </summary>
        public ICollection<BE.SIC_UNIDADTITULAR> Listar(BE.SIC_UNIDADTITULAR entSIC_UNIDADTITULAR)
        {
            List<BE.SIC_UNIDADTITULAR> lisQuery = null;

            try
            {
                IEnumerable<BE.SIC_UNIDADTITULAR> entQuery = new DA.SIC_UNIDADTITULAR().Listar(entSIC_UNIDADTITULAR);
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
        
        public ICollection<BE.SIC_UNIDADTITULAR> CargarUnidadTitularHistoricas(BE.SIC_UNIDADTITULAR entSIC_UNIDADTITULAR)
        {
            List<BE.SIC_UNIDADTITULAR> lisQuery = null;

            try
            {
                IEnumerable<BE.SIC_UNIDADTITULAR> entQuery = new DA.SIC_UNIDADTITULAR().CargarUnidadTitularHistoricas(entSIC_UNIDADTITULAR);
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
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Quispe Ipanaque (06/07/2018)
        //Utilizado por	: WebApi.SIC_UNIDADTITULAR.ListarRentas
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los registro de la tabla SIC_UNIDADTITULAR
        /// </summary>
        public ICollection<BE.SIC_UNIDADTITULAR> ListarRentas(BE.SIC_UNIDADTITULAR entSIC_UNIDADTITULAR)
        {
            List<BE.SIC_UNIDADTITULAR> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_UNIDADTITULAR> entQuery = new DA.SIC_UNIDADTITULAR().ListarRentas(entSIC_UNIDADTITULAR);
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
