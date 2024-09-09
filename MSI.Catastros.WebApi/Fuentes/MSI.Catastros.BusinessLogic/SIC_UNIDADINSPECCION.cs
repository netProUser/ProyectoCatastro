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
    public class SIC_UNIDADINSPECCION
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (12/06/2018)
        //Utilizado por	: WebApi.SIC_UNIDADINSPECCION.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_UNIDADINSPECCION, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_UNIDADINSPECCION entSIC_UNIDADINSPECCION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDADINSPECCION().Grabar(entSIC_UNIDADINSPECCION);
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
        //Utilizado por	: WebApi.SIC_UNIDADINSPECCION.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_UNIDADINSPECCION
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_UNIDADINSPECCION entSIC_UNIDADINSPECCION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDADINSPECCION().Actualizar(entSIC_UNIDADINSPECCION);
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
        //Utilizado por	: WebApi.SIC_UNIDADINSPECCION.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_UNIDADINSPECCION
        /// </summary>
        public BE.SIC_UNIDADINSPECCION Recuperar(BE.SIC_UNIDADINSPECCION entSIC_UNIDADINSPECCION)
        {
            BE.SIC_UNIDADINSPECCION lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_UNIDADINSPECCION().Recuperar(entSIC_UNIDADINSPECCION);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (12/06/2018)
        //Utilizado por	: WebApi.SIC_UNIDADINSPECCION.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_UNIDADINSPECCION
        /// </summary>
        public ICollection<BE.SIC_UNIDADINSPECCION> Listar(BE.SIC_UNIDADINSPECCION entSIC_UNIDADINSPECCION)
        {
            List<BE.SIC_UNIDADINSPECCION> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_UNIDADINSPECCION> entQuery = new DA.SIC_UNIDADINSPECCION().Listar(entSIC_UNIDADINSPECCION);
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
        //Creado por	: Jaime Díaz Espinoza (12/06/2018)
        //Utilizado por	: WebApi.SIC_UNIDADINSPECCION.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_UNIDADINSPECCION
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_UNIDADINSPECCION entSIC_UNIDADINSPECCION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDADINSPECCION().Eliminar(entSIC_UNIDADINSPECCION);
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
