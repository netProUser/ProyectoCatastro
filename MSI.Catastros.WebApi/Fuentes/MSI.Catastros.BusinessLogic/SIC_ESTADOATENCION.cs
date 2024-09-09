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
    public class SIC_ESTADOATENCION
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (25/04/2018)
        //Utilizado por	: WebApi.SIC_ESTADOATENCION.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_ESTADOATENCION
        /// </summary>
        public ICollection<BE.SIC_ESTADOATENCION> Buscar(BE.SIC_ESTADOATENCION entSIC_ESTADOATENCION)
        {
            List<BE.SIC_ESTADOATENCION> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_ESTADOATENCION> entQuery = new DA.SIC_ESTADOATENCION().Buscar(entSIC_ESTADOATENCION);
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
        //Creado por	: Jaime Díaz Espinoza (25/04/2018)
        //Utilizado por	: WebApi.SIC_ESTADOATENCION.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_ESTADOATENCION
        /// </summary>
        public BE.SIC_ESTADOATENCION Recuperar(BE.SIC_ESTADOATENCION entSIC_ESTADOATENCION)
        {
            BE.SIC_ESTADOATENCION lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_ESTADOATENCION().Recuperar(entSIC_ESTADOATENCION);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (25/04/2018)
        //Utilizado por	: WebApi.SIC_ESTADOATENCION.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_ESTADOATENCION, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_ESTADOATENCION entSIC_ESTADOATENCION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_ESTADOATENCION().Grabar(entSIC_ESTADOATENCION);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (25/04/2018)
        //Utilizado por	: WebApi.SIC_ESTADOATENCION.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_ESTADOATENCION
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_ESTADOATENCION entSIC_ESTADOATENCION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_ESTADOATENCION().Actualizar(entSIC_ESTADOATENCION);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (25/04/2018)
        //Utilizado por	: WebApi.SIC_ESTADOATENCION.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_ESTADOATENCION
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_ESTADOATENCION entSIC_ESTADOATENCION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_ESTADOATENCION().Eliminar(entSIC_ESTADOATENCION);
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
