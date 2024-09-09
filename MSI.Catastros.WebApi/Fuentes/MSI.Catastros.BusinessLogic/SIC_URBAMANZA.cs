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
    public class SIC_URBAMANZA
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (08/05/2018)
        //Utilizado por	: WebApi.SIC_URBAMANZA.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_URBAMANZA
        /// </summary>
        public ICollection<BE.SIC_URBAMANZA> Buscar(BE.SIC_URBAMANZA entSIC_URBAMANZA)
        {
            List<BE.SIC_URBAMANZA> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_URBAMANZA> entQuery = new DA.SIC_URBAMANZA().Buscar(entSIC_URBAMANZA);
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
        //Creado por	: Pedro Peña Salazar (08/05/2018)
        //Utilizado por	: WebApi.SIC_URBAMANZA.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_URBAMANZA
        /// </summary>
        public BE.SIC_URBAMANZA Recuperar(BE.SIC_URBAMANZA entSIC_URBAMANZA)
        {
            BE.SIC_URBAMANZA lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_URBAMANZA().Recuperar(entSIC_URBAMANZA);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (08/05/2018)
        //Utilizado por	: WebApi.SIC_URBAMANZA.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_URBAMANZA, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_URBAMANZA entSIC_URBAMANZA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_URBAMANZA().Grabar(entSIC_URBAMANZA);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (08/05/2018)
        //Utilizado por	: WebApi.SIC_URBAMANZA.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_URBAMANZA
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_URBAMANZA entSIC_URBAMANZA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_URBAMANZA().Actualizar(entSIC_URBAMANZA);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (08/05/2018)
        //Utilizado por	: WebApi.SIC_URBAMANZA.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_URBAMANZA
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_URBAMANZA entSIC_URBAMANZA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_URBAMANZA().Eliminar(entSIC_URBAMANZA);
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
