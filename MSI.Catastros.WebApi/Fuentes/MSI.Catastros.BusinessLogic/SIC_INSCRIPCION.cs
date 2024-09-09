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
    public class SIC_INSCRIPCION
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (21/06/2018)
        //Utilizado por	: WebApi.SIC_INSCRIPCION.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_INSCRIPCION
        /// </summary>
        public BE.SIC_INSCRIPCION Recuperar(BE.SIC_INSCRIPCION entSIC_INSCRIPCION)
        {
            BE.SIC_INSCRIPCION lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_INSCRIPCION().Recuperar(entSIC_INSCRIPCION);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (21/06/2018)
        //Utilizado por	: WebApi.SIC_INSCRIPCION.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_INSCRIPCION
        /// </summary>
        public ICollection<BE.SIC_INSCRIPCION> Listar(BE.SIC_INSCRIPCION entSIC_INSCRIPCION)
        {
            List<BE.SIC_INSCRIPCION> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_INSCRIPCION> entQuery = new DA.SIC_INSCRIPCION().Listar(entSIC_INSCRIPCION);
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
        public ICollection<BE.SIC_INSCRIPCION> Buscar(BE.SIC_INSCRIPCION entSIC_INSCRIPCION)
        {
            List<BE.SIC_INSCRIPCION> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_INSCRIPCION> entQuery = new DA.SIC_INSCRIPCION().Buscar(entSIC_INSCRIPCION);
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
        public BE.SIC_INSCRIPCION BuscarInt(BE.SIC_INSCRIPCION entSIC_INSCRIPCION)
        {
            BE.SIC_INSCRIPCION lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_INSCRIPCION().BuscarInt(entSIC_INSCRIPCION);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        public BE.SIC_RETORNO Grabar(BE.SIC_INSCRIPCION entSIC_INSCRIPCION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_INSCRIPCION().Grabar(entSIC_INSCRIPCION);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO Actualizar(BE.SIC_INSCRIPCION entSIC_INSCRIPCION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_INSCRIPCION().Actualizar(entSIC_INSCRIPCION);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO Eliminar(BE.SIC_INSCRIPCION entSIC_INSCRIPCION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_INSCRIPCION().Eliminar(entSIC_INSCRIPCION);
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
