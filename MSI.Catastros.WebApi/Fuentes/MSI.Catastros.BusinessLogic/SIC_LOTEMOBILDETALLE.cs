
using System;
using System.Collections.Generic;
using System.Linq;


using BE = MSI.Catastros.BusinessEntities;
using DA = MSI.Catastros.DataAccess;
using HP = MSI.Catastros.Helpers;
using EX = MSI.Catastros.Exceptions;
namespace MSI.Catastros.BusinessLogic
{
    public class SIC_LOTEMOBILDETALLE
    {

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Eistein Dolores Tarazona (05/07/2018)
        //Utilizado por	: WebApi.SIC_LOTEMOBILDETALLE.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_LOTEMOBILDETALLE, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_LOTEMOBILDETALLE entSIC_LOTEMOBILDETALLE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_LOTEMOBILDETALLE().Grabar(entSIC_LOTEMOBILDETALLE);
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
        //Utilizado por	: WebApi.SIC_LOTEMOBILDETALLE.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_LOTEMOBILDETALLE
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_LOTEMOBILDETALLE entSIC_LOTEMOBILDETALLE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_LOTEMOBILDETALLE().Actualizar(entSIC_LOTEMOBILDETALLE);
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
        //Utilizado por	: WebApi.SIC_LOTEMOBILDETALLE.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_LOTEMOBILDETALLE
        /// </summary>
        public BE.SIC_LOTEMOBILDETALLE Recuperar(BE.SIC_LOTEMOBILDETALLE entSIC_LOTEMOBILDETALLE)
        {
            BE.SIC_LOTEMOBILDETALLE lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_LOTEMOBILDETALLE().Recuperar(entSIC_LOTEMOBILDETALLE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Eistein Dolores Tarazona (05/07/2018)
        //Utilizado por	: WebApi.SIC_LOTEMOBILDETALLE.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_LOTEMOBILDETALLE
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_LOTEMOBILDETALLE entSIC_LOTEMOBILDETALLE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_LOTEMOBILDETALLE().Eliminar(entSIC_LOTEMOBILDETALLE);
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
        //Utilizado por	: WebApi.SIC_LOTEMOBILDETALLE.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_LOTEMOBILDETALLE
        /// </summary>
        public ICollection<BE.SIC_LOTEMOBILDETALLE> Listar(BE.SIC_LOTEMOBILDETALLE entSIC_LOTEMOBILDETALLE)
        {
            List<BE.SIC_LOTEMOBILDETALLE> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_LOTEMOBILDETALLE> entQuery = new DA.SIC_LOTEMOBILDETALLE().Listar(entSIC_LOTEMOBILDETALLE);
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
