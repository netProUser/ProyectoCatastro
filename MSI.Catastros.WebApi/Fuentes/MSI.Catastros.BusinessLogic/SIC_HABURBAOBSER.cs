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
    public class SIC_HABURBAOBSER
    {
        
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro PeñaSalazar (26/09/2018)
        //Utilizado por	: WebApi.SIC_HABURBAOBSER.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_HABURBAOBSER
        /// </summary>
        public ICollection<BE.SIC_HABURBAOBSER> Listar(BE.SIC_HABURBAOBSER entSIC_HABURBAOBSER)
        {
            List<BE.SIC_HABURBAOBSER> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_HABURBAOBSER> entQuery = new DA.SIC_HABURBAOBSER().Listar(entSIC_HABURBAOBSER);
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
        //Creado por	: Pedro PeñaSalazar (26/09/2018)
        //Utilizado por	: WebApi.SIC_HABURBAOBSER.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_HABURBAOBSER
        /// </summary>
        public BE.SIC_HABURBAOBSER Recuperar(BE.SIC_HABURBAOBSER entSIC_HABURBAOBSER)
        {
            BE.SIC_HABURBAOBSER lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_HABURBAOBSER().Recuperar(entSIC_HABURBAOBSER);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro PeñaSalazar (26/09/2018)
        //Utilizado por	: WebApi.SIC_HABURBAOBSER.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_HABURBAOBSER, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_HABURBAOBSER entSIC_HABURBAOBSER)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_HABURBAOBSER().Grabar(entSIC_HABURBAOBSER);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro PeñaSalazar (26/09/2018)
        //Utilizado por	: WebApi.SIC_HABURBAOBSER.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_HABURBAOBSER
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_HABURBAOBSER entSIC_HABURBAOBSER)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_HABURBAOBSER().Actualizar(entSIC_HABURBAOBSER);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro PeñaSalazar (26/09/2018)
        //Utilizado por	: WebApi.SIC_HABURBAOBSER.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_HABURBAOBSER
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_HABURBAOBSER entSIC_HABURBAOBSER)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_HABURBAOBSER().Eliminar(entSIC_HABURBAOBSER);
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
