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
    public class SIC_LOTEAUTOEDIF
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (17/07/2018)
        //Utilizado por	: WebApi.SIC_LOTEAUTOEDIF.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_LOTEAUTOEDIF, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_LOTEAUTOEDIF entSIC_LOTEAUTOEDIF)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_LOTEAUTOEDIF().Grabar(entSIC_LOTEAUTOEDIF);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (17/07/2018)
        //Utilizado por	: WebApi.SIC_LOTEAUTOEDIF.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_LOTEAUTOEDIF
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_LOTEAUTOEDIF entSIC_LOTEAUTOEDIF)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_LOTEAUTOEDIF().Actualizar(entSIC_LOTEAUTOEDIF);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (17/07/2018)
        //Utilizado por	: WebApi.SIC_LOTEAUTOEDIF.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_LOTEAUTOEDIF
        /// </summary>
        public BE.SIC_LOTEAUTOEDIF Recuperar(BE.SIC_LOTEAUTOEDIF entSIC_LOTEAUTOEDIF)
        {
            BE.SIC_LOTEAUTOEDIF lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_LOTEAUTOEDIF().Recuperar(entSIC_LOTEAUTOEDIF);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (17/07/2018)
        //Utilizado por	: WebApi.SIC_LOTEAUTOEDIF.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_LOTEAUTOEDIF
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_LOTEAUTOEDIF entSIC_LOTEAUTOEDIF)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_LOTEAUTOEDIF().Eliminar(entSIC_LOTEAUTOEDIF);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO EliminarLote(BE.SIC_LOTEAUTOEDIF entSIC_LOTEAUTOEDIF)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_LOTEAUTOEDIF().EliminarLote(entSIC_LOTEAUTOEDIF);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (17/07/2018)
        //Utilizado por	: WebApi.SIC_LOTEAUTOEDIF.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_LOTEAUTOEDIF
        /// </summary>
        public ICollection<BE.SIC_LOTEAUTOEDIF> Buscar(BE.SIC_LOTEAUTOEDIF entSIC_LOTEAUTOEDIF)
        {
            List<BE.SIC_LOTEAUTOEDIF> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_LOTEAUTOEDIF> entQuery = new DA.SIC_LOTEAUTOEDIF().Buscar(entSIC_LOTEAUTOEDIF);
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
