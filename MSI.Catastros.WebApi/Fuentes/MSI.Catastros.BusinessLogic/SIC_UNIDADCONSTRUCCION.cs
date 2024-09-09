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
    public class SIC_UNIDADCONSTRUCCION
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/06/2018)
        //Utilizado por	: WebApi.SIC_UNIDADCONSTRUCCION.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_UNIDADCONSTRUCCION, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_UNIDADCONSTRUCCION entSIC_UNIDADCONSTRUCCION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDADCONSTRUCCION().Grabar(entSIC_UNIDADCONSTRUCCION);
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
        //Utilizado por	: WebApi.SIC_UNIDADCONSTRUCCION.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_UNIDADCONSTRUCCION
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_UNIDADCONSTRUCCION entSIC_UNIDADCONSTRUCCION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDADCONSTRUCCION().Actualizar(entSIC_UNIDADCONSTRUCCION);
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
        //Utilizado por	: WebApi.SIC_UNIDADCONSTRUCCION.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_UNIDADCONSTRUCCION
        /// </summary>
        public BE.SIC_UNIDADCONSTRUCCION Recuperar(BE.SIC_UNIDADCONSTRUCCION entSIC_UNIDADCONSTRUCCION)
        {
            BE.SIC_UNIDADCONSTRUCCION lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_UNIDADCONSTRUCCION().Recuperar(entSIC_UNIDADCONSTRUCCION);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/06/2018)
        //Utilizado por	: WebApi.SIC_UNIDADCONSTRUCCION.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_UNIDADCONSTRUCCION
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_UNIDADCONSTRUCCION entSIC_UNIDADCONSTRUCCION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDADCONSTRUCCION().Eliminar(entSIC_UNIDADCONSTRUCCION);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }

        public ICollection<BE.SIC_UNIDADCONSTRUCCION> Listar(BE.SIC_UNIDADCONSTRUCCION entSIC_UNIDADCONSTRUCCION)
        {
            List<BE.SIC_UNIDADCONSTRUCCION> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_UNIDADCONSTRUCCION> entQuery = new DA.SIC_UNIDADCONSTRUCCION().Listar(entSIC_UNIDADCONSTRUCCION);
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
        public ICollection<BE.SIC_UNIDADCONSTRUCCION> RecuperarUnidadConstruccionHistoricas(BE.SIC_UNIDADCONSTRUCCION entSIC_UNIDADCONSTRUCCION)
        {
            List<BE.SIC_UNIDADCONSTRUCCION> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_UNIDADCONSTRUCCION> entQuery = new DA.SIC_UNIDADCONSTRUCCION().RecuperarUnidadConstruccionHistoricas(entSIC_UNIDADCONSTRUCCION);
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
