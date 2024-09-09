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
    public class SIC_LOTEMOBOBSER
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (12/06/2018)
        //Utilizado por	: WebApi.SIC_LOTEMOBOBSER.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_LOTEMOBOBSER, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_LOTEMOBOBSER entSIC_LOTEMOBOBSER)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_LOTEMOBOBSER().Grabar(entSIC_LOTEMOBOBSER);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (12/06/2018)
        //Utilizado por	: WebApi.SIC_LOTEMOBOBSER.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_LOTEMOBOBSER
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_LOTEMOBOBSER entSIC_LOTEMOBOBSER)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_LOTEMOBOBSER().Actualizar(entSIC_LOTEMOBOBSER);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (12/06/2018)
        //Utilizado por	: WebApi.SIC_LOTEMOBOBSER.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_LOTEMOBOBSER
        /// </summary>
        public BE.SIC_LOTEMOBOBSER Recuperar(BE.SIC_LOTEMOBOBSER entSIC_LOTEMOBOBSER)
        {
            BE.SIC_LOTEMOBOBSER lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_LOTEMOBOBSER().Recuperar(entSIC_LOTEMOBOBSER);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (12/06/2018)
        //Utilizado por	: WebApi.SIC_LOTEMOBOBSER.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_LOTEMOBOBSER
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_LOTEMOBOBSER entSIC_LOTEMOBOBSER)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_LOTEMOBOBSER().Eliminar(entSIC_LOTEMOBOBSER);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (20/06/2018)
        //Utilizado por	: WebApi.SIC_LOTEMOBOBSER.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_LOTEMOBILURBA
        /// </summary>
        public ICollection<BE.SIC_LOTEMOBOBSER> Listar(BE.SIC_LOTEMOBOBSER entSIC_LOTEMOBOBSER)
        {
            List<BE.SIC_LOTEMOBOBSER> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_LOTEMOBOBSER> entQuery = new DA.SIC_LOTEMOBOBSER().Listar(entSIC_LOTEMOBOBSER);
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
