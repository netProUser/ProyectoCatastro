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
    public class SIC_UNIDADEXPEDOCU
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/06/2018)
        //Utilizado por	: WebApi.SIC_UNIDADEXPEDOCU.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_UNIDADEXPEDOCU, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_UNIDADEXPEDOCU entSIC_UNIDADEXPEDOCU)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDADEXPEDOCU().Grabar(entSIC_UNIDADEXPEDOCU);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/06/2018)
        //Utilizado por	: WebApi.SIC_UNIDADEXPEDOCU.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_UNIDADEXPEDOCU
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_UNIDADEXPEDOCU entSIC_UNIDADEXPEDOCU)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDADEXPEDOCU().Actualizar(entSIC_UNIDADEXPEDOCU);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/06/2018)
        //Utilizado por	: WebApi.SIC_UNIDADEXPEDOCU.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_UNIDADEXPEDOCU
        /// </summary>
        public BE.SIC_UNIDADEXPEDOCU Recuperar(BE.SIC_UNIDADEXPEDOCU entSIC_UNIDADEXPEDOCU)
        {
            BE.SIC_UNIDADEXPEDOCU lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_UNIDADEXPEDOCU().Recuperar(entSIC_UNIDADEXPEDOCU);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/06/2018)
        //Utilizado por	: WebApi.SIC_UNIDADEXPEDOCU.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_UNIDADEXPEDOCU
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_UNIDADEXPEDOCU entSIC_UNIDADEXPEDOCU)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDADEXPEDOCU().Eliminar(entSIC_UNIDADEXPEDOCU);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Quispe Ipaaque (22/07/2018)
        //Utilizado por	: WebApi.SIC_UNIDADEXPEDOCU.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los registro de la tabla SIC_UNIDADEXPEDOCU
        /// </summary>
        public ICollection<BE.SIC_UNIDADEXPEDOCU> Listar(BE.SIC_UNIDADEXPEDOCU entSIC_UNIDADEXPEDOCU)
        {
            List<BE.SIC_UNIDADEXPEDOCU> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_UNIDADEXPEDOCU> entQuery = new DA.SIC_UNIDADEXPEDOCU().Listar(entSIC_UNIDADEXPEDOCU);
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
        
                    public ICollection<BE.SIC_UNIDADEXPEDOCU> CargarUnidadExpedienteDocHistorica(BE.SIC_UNIDADEXPEDOCU entSIC_UNIDADEXPEDOCU)
        {
            List<BE.SIC_UNIDADEXPEDOCU> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_UNIDADEXPEDOCU> entQuery = new DA.SIC_UNIDADEXPEDOCU().CargarUnidadExpedienteDocHistorica(entSIC_UNIDADEXPEDOCU);
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
