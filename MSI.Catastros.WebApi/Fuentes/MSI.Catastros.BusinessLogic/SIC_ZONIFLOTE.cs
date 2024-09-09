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
    public class SIC_ZONIFLOTE
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (04/07/2018)
        //Utilizado por	: WebApi.SIC_ZONIFLOTE.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_ZONIFLOTE
        /// </summary>
        public ICollection<BE.SIC_ZONIFLOTE> Buscar(BE.SIC_ZONIFLOTE entSIC_LOTELINDEROVIADET)
        {
            List<BE.SIC_ZONIFLOTE> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_ZONIFLOTE> entQuery = new DA.SIC_ZONIFLOTE().Buscar(entSIC_LOTELINDEROVIADET);
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
        //Creado por	: Pedro Peña Salazar (04/07/2018)
        //Utilizado por	: WebApi.SIC_ZONIFLOTE.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_ZONIFLOTE, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_ZONIFLOTE entSIC_ZONIFLOTE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_ZONIFLOTE().Grabar(entSIC_ZONIFLOTE);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (04/07/2018)
        //Utilizado por	: WebApi.SIC_ZONIFLOTE.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_ZONIFLOTE
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_ZONIFLOTE entSIC_ZONIFLOTE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_ZONIFLOTE().Actualizar(entSIC_ZONIFLOTE);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (04/07/2018)
        //Utilizado por	: WebApi.SIC_ZONIFLOTE.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_ZONIFLOTE
        /// </summary>
        public BE.SIC_ZONIFLOTE Recuperar(BE.SIC_ZONIFLOTE entSIC_ZONIFLOTE)
        {
            BE.SIC_ZONIFLOTE lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_ZONIFLOTE().Recuperar(entSIC_ZONIFLOTE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (04/07/2018)
        //Utilizado por	: WebApi.SIC_ZONIFLOTE.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_ZONIFLOTE
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_ZONIFLOTE entSIC_ZONIFLOTE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_ZONIFLOTE().Eliminar(entSIC_ZONIFLOTE);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
    }
}
