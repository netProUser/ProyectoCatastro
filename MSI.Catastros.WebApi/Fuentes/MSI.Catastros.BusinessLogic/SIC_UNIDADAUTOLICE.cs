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
    public class SIC_UNIDADAUTOLICE
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/06/2018)
        //Utilizado por	: WebApi.SIC_UNIDADAUTOLICE.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_UNIDADAUTOLICE, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_UNIDADAUTOLICE entSIC_UNIDADAUTOLICE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDADAUTOLICE().Grabar(entSIC_UNIDADAUTOLICE);
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
        //Utilizado por	: WebApi.SIC_UNIDADAUTOLICE.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_UNIDADAUTOLICE
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_UNIDADAUTOLICE entSIC_UNIDADAUTOLICE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDADAUTOLICE().Actualizar(entSIC_UNIDADAUTOLICE);
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
        //Utilizado por	: WebApi.SIC_UNIDADAUTOLICE.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_UNIDADAUTOLICE
        /// </summary>
        public BE.SIC_UNIDADAUTOLICE Recuperar(BE.SIC_UNIDADAUTOLICE entSIC_UNIDADAUTOLICE)
        {
            BE.SIC_UNIDADAUTOLICE lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_UNIDADAUTOLICE().Recuperar(entSIC_UNIDADAUTOLICE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/06/2018)
        //Utilizado por	: WebApi.SIC_UNIDADAUTOLICE.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_UNIDADAUTOLICE
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_UNIDADAUTOLICE entSIC_UNIDADAUTOLICE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDADAUTOLICE().Eliminar(entSIC_UNIDADAUTOLICE);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Quispe Ipaaque (25/07/2018)
        //Utilizado por	: WebApi.SIC_UNIDADAUTOLICE.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los registro de la tabla SIC_UNIDADAUTOLICE
        /// </summary>
        public ICollection<BE.SIC_UNIDADAUTOLICE> Listar(BE.SIC_UNIDADAUTOLICE entSIC_UNIDADAUTOLICE)
        {
            List<BE.SIC_UNIDADAUTOLICE> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_UNIDADAUTOLICE> entQuery = new DA.SIC_UNIDADAUTOLICE().Listar(entSIC_UNIDADAUTOLICE);
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
        
                    public ICollection<BE.SIC_UNIDADAUTOLICE> CargarUnidadLicenciasFuncHistorica(BE.SIC_UNIDADAUTOLICE entSIC_UNIDADAUTOLICE)
        {
            List<BE.SIC_UNIDADAUTOLICE> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_UNIDADAUTOLICE> entQuery = new DA.SIC_UNIDADAUTOLICE().CargarUnidadLicenciasFuncHistorica(entSIC_UNIDADAUTOLICE);
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
