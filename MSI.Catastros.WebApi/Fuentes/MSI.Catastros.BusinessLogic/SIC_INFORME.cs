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
    public class SIC_INFORME
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (08/07/2018)
        //Utilizado por	: WebApi.SIC_INFORME.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_INFORME
        /// </summary>
        public ICollection<BE.SIC_INFORME> Buscar(BE.SIC_INFORME entSIC_INFORME)
        {
            List<BE.SIC_INFORME> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_INFORME> entQuery = new DA.SIC_INFORME().Buscar(entSIC_INFORME);
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
        public ICollection<BE.SIC_INFORME> BuscarInformes(BE.SIC_INFORME entSIC_INFORME)
        {
            List<BE.SIC_INFORME> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_INFORME> entQuery = new DA.SIC_INFORME().BuscarInformes(entSIC_INFORME);
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
        //Creado por	: Pedro Peña Salazar (07/08/2018)
        //Utilizado por	: WebApi.SIC_INFORME.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_INFORME, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_INFORME entSIC_SOLISEGUI)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_INFORME().Grabar(entSIC_SOLISEGUI);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña  Salazar (11/08/2018)
        //Utilizado por	: WebApi.SIC_INFORME.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_INFORME
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_INFORME entSIC_INFORME)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_INFORME().Eliminar(entSIC_INFORME);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (07/08/2018)
        //Utilizado por	: WebApi.SIC_INFORME.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_SOLISEGUI
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_INFORME entSIC_SOLISEGUI)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_INFORME().Actualizar(entSIC_SOLISEGUI);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (07/08/2018)
        //Utilizado por	: WebApi.SIC_INFORME.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_INFORME
        /// </summary>
        public BE.SIC_INFORME Recuperar(BE.SIC_INFORME entSIC_SOLISEGUI)
        {
            BE.SIC_INFORME lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_INFORME().Recuperar(entSIC_SOLISEGUI);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }

        public BE.SIC_INFORME RecuperarNumeroRegistro(BE.SIC_INFORME entSIC_SOLISEGUI)
        {
            BE.SIC_INFORME lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_INFORME().RecuperarNumeroRegistro(entSIC_SOLISEGUI);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }

    }
}
