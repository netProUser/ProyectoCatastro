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
    public class SIC_DOCUUNIDAD
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/06/2018)
        //Utilizado por	: WebApi.SIC_DOCUUNIDAD.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_DOCUUNIDAD, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_DOCUUNIDAD entSIC_DOCUUNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_DOCUUNIDAD().Grabar(entSIC_DOCUUNIDAD);
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
        //Utilizado por	: WebApi.SIC_DOCUUNIDAD.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_DOCUUNIDAD
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_DOCUUNIDAD entSIC_DOCUUNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_DOCUUNIDAD().Actualizar(entSIC_DOCUUNIDAD);
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
        //Utilizado por	: WebApi.SIC_DOCUUNIDAD.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_DOCUUNIDAD
        /// </summary>
        public BE.SIC_DOCUUNIDAD Recuperar(BE.SIC_DOCUUNIDAD entSIC_DOCUUNIDAD)
        {
            BE.SIC_DOCUUNIDAD lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_DOCUUNIDAD().Recuperar(entSIC_DOCUUNIDAD);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        public BE.SIC_DOCUUNIDAD RecuperarUnidad(BE.SIC_DOCUUNIDAD entSIC_DOCUUNIDAD)
        {
            BE.SIC_DOCUUNIDAD lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_DOCUUNIDAD().RecuperarUnidad(entSIC_DOCUUNIDAD);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/06/2018)
        //Utilizado por	: WebApi.SIC_DOCUUNIDAD.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_DOCUUNIDAD
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_DOCUUNIDAD entSIC_DOCUUNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_DOCUUNIDAD().Eliminar(entSIC_DOCUUNIDAD);
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
        //Utilizado por	: WebApi.SIC_DOCUUNIDAD.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los registro de la tabla SIC_DOCUUNIDAD
        /// </summary>
        public ICollection<BE.SIC_DOCUUNIDAD> Listar(BE.SIC_DOCUUNIDAD entSIC_DOCUUNIDAD)
        {
            List<BE.SIC_DOCUUNIDAD> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_DOCUUNIDAD> entQuery = new DA.SIC_DOCUUNIDAD().Listar(entSIC_DOCUUNIDAD);
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
