using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BE = MSI.Catastros.BusinessEntities;
using DA = MSI.Catastros.DataAccess;
using HP = MSI.Catastros.Helpers;
using EX = MSI.Catastros.Exceptions;
namespace MSI.Catastros.BusinessLogic
{
    public class SIC_LOTEMUCONFIG
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Eistein Dolores Tarazona (05/07/2018)
        //Utilizado por	: WebApi.SIC_LOTEMUCONFIG.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_LOTEMUCONFIG, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_LOTEMUCONFIG entSIC_LOTEMUCONFIG)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_LOTEMUCONFIG().Grabar(entSIC_LOTEMUCONFIG);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Eistein Dolores Tarazona (05/07/2018)
        //Utilizado por	: WebApi.SIC_LOTEMUCONFIG.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_LOTEMUCONFIG
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_LOTEMUCONFIG entSIC_LOTEMUCONFIG)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_LOTEMUCONFIG().Actualizar(entSIC_LOTEMUCONFIG);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Eistein Dolores Tarazona (05/07/2018)
        //Utilizado por	: WebApi.SIC_LOTEMUCONFIG.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_LOTEMUCONFIG
        /// </summary>
        public BE.SIC_LOTEMUCONFIG Recuperar(BE.SIC_LOTEMUCONFIG entSIC_LOTEMUCONFIG)
        {
            BE.SIC_LOTEMUCONFIG lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_LOTEMUCONFIG().Recuperar(entSIC_LOTEMUCONFIG);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Eistein Dolores Tarazona (05/07/2018)
        //Utilizado por	: WebApi.SIC_LOTEMUCONFIG.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_LOTEMUCONFIG
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_LOTEMUCONFIG entSIC_LOTEMUCONFIG)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_LOTEMUCONFIG().Eliminar(entSIC_LOTEMUCONFIG);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Eistein Dolores Tarazona (05/07/2018)
        //Utilizado por	: WebApi.SIC_LOTEMUCONFIG.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_LOTEMUCONFIG
        /// </summary>
        public ICollection<BE.SIC_LOTEMUCONFIG> Listar(BE.SIC_LOTEMUCONFIG entSIC_LOTEMUCONFIG)
        {
            List<BE.SIC_LOTEMUCONFIG> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_LOTEMUCONFIG> entQuery = new DA.SIC_LOTEMUCONFIG().Listar(entSIC_LOTEMUCONFIG);
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
