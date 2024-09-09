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
    public class SIC_UNIDBIENCOMUN
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar(18/01/2019)
        //Utilizado por	: WebApi.SIC_UNIDBIENCOMUN.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_UNIDBIENCOMUN, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_UNIDBIENCOMUN entSIC_UNIDBIENCOMUN)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDBIENCOMUN().Grabar(entSIC_UNIDBIENCOMUN);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Quispe Ipanaque (18/07/2019)
        //Utilizado por	: WebApi.SIC_UNIDBIENCOMUN.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_UNIDBIENCOMUN
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_UNIDBIENCOMUN entSIC_UNIDBIENCOMUN)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDBIENCOMUN().Actualizar(entSIC_UNIDBIENCOMUN);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Quispe Ipanaque (18/07/2019)
        //Utilizado por	: WebApi.SIC_UNIDBIENCOMUN.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_UNIDBIENCOMUN
        /// </summary>
        public BE.SIC_UNIDBIENCOMUN Recuperar(BE.SIC_UNIDBIENCOMUN entSIC_UNIDBIENCOMUN)
        {
            BE.SIC_UNIDBIENCOMUN lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_UNIDBIENCOMUN().Recuperar(entSIC_UNIDBIENCOMUN);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        public BE.SIC_UNIDBIENCOMUN Filtrar(BE.SIC_UNIDBIENCOMUN entSIC_UNIDBIENCOMUN)
        {
            BE.SIC_UNIDBIENCOMUN lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_UNIDBIENCOMUN().Filtrar(entSIC_UNIDBIENCOMUN);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Quispe Ipanaque (18/07/2019)
        //Utilizado por	: WebApi.SIC_UNIDBIENCOMUN.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_UNIDBIENCOMUN
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_UNIDBIENCOMUN entSIC_UNIDBIENCOMUN)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDBIENCOMUN().Eliminar(entSIC_UNIDBIENCOMUN);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Quispe Ipanaque (06/07/2019)
        //Utilizado por	: WebApi.SIC_UNIDBIENCOMUN.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los registro de la tabla SIC_UNIDBIENCOMUN
        /// </summary>
        public ICollection<BE.SIC_UNIDBIENCOMUN> Listar(BE.SIC_UNIDBIENCOMUN entSIC_UNIDBIENCOMUN)
        {
            List<BE.SIC_UNIDBIENCOMUN> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_UNIDBIENCOMUN> entQuery = new DA.SIC_UNIDBIENCOMUN().Listar(entSIC_UNIDBIENCOMUN);
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
