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
    public class SIC_UNIDADRRPP
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/06/2018)
        //Utilizado por	: WebApi.SIC_UNIDADRRPP.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_UNIDADRRPP, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_UNIDADRRPP entSIC_UNIDADRRPP)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDADRRPP().Grabar(entSIC_UNIDADRRPP);
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
        //Utilizado por	: WebApi.SIC_UNIDADRRPP.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_UNIDADRRPP
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_UNIDADRRPP entSIC_UNIDADRRPP)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDADRRPP().Actualizar(entSIC_UNIDADRRPP);
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
        //Utilizado por	: WebApi.SIC_UNIDADRRPP.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_UNIDADRRPP
        /// </summary>
        public BE.SIC_UNIDADRRPP Recuperar(BE.SIC_UNIDADRRPP entSIC_UNIDADRRPP)
        {
            BE.SIC_UNIDADRRPP lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_UNIDADRRPP().Recuperar(entSIC_UNIDADRRPP);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/06/2018)
        //Utilizado por	: WebApi.SIC_UNIDADRRPP.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_UNIDADRRPP
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_UNIDADRRPP entSIC_UNIDADRRPP)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDADRRPP().Eliminar(entSIC_UNIDADRRPP);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Quispe Ipaaque (22/07/2018)
        //Utilizado por	: WebApi.SIC_UNIDADRRPP.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los registro de la tabla SIC_UNIDADRRPP
        /// </summary>
        public ICollection<BE.SIC_UNIDADRRPP> Listar(BE.SIC_UNIDADRRPP entSIC_UNIDADRRPP)
        {
            List<BE.SIC_UNIDADRRPP> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_UNIDADRRPP> entQuery = new DA.SIC_UNIDADRRPP().Listar(entSIC_UNIDADRRPP);
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
        

         public ICollection<BE.SIC_UNIDADRRPP> CargarUnidadRRPPHistorica(BE.SIC_UNIDADRRPP entSIC_UNIDADRRPP)
        {
            List<BE.SIC_UNIDADRRPP> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_UNIDADRRPP> entQuery = new DA.SIC_UNIDADRRPP().CargarUnidadRRPPHistorica(entSIC_UNIDADRRPP);
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
