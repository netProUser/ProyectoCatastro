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
    public class SIC_LOTEOBSERVACION
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (11/06/2018)
        //Utilizado por	: WebApi.SIC_LOTEOBSERVACION.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_LOTEOBSERVACION, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_LOTEOBSERVACION entSIC_LOTEOBSERVACION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_LOTEOBSERVACION().Grabar(entSIC_LOTEOBSERVACION);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (11/06/2018)
        //Utilizado por	: WebApi.SIC_LOTEOBSERVACION.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_LOTEOBSERVACION
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_LOTEOBSERVACION entSIC_LOTEOBSERVACION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_LOTEOBSERVACION().Actualizar(entSIC_LOTEOBSERVACION);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (11/06/2018)
        //Utilizado por	: WebApi.SIC_LOTEOBSERVACION.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_LOTEOBSERVACION
        /// </summary>
        public BE.SIC_LOTEOBSERVACION Recuperar(BE.SIC_LOTEOBSERVACION entSIC_LOTEOBSERVACION)
        {
            BE.SIC_LOTEOBSERVACION lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_LOTEOBSERVACION().Recuperar(entSIC_LOTEOBSERVACION);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (11/06/2018)
        //Utilizado por	: WebApi.SIC_LOTEOBSERVACION.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_LOTEOBSERVACION
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_LOTEOBSERVACION entSIC_LOTEOBSERVACION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_LOTEOBSERVACION().Eliminar(entSIC_LOTEOBSERVACION);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (23/04/2018)
        //Utilizado por	: WebApi.SIC_LOTEOBSERVACION.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_LOTEOBSERVACION
        /// </summary>
        public ICollection<BE.SIC_LOTEOBSERVACION> Buscar(BE.SIC_LOTEOBSERVACION entSIC_LOTEOBSERVACION)
        {
            List<BE.SIC_LOTEOBSERVACION> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_LOTEOBSERVACION> entQuery = new DA.SIC_LOTEOBSERVACION().Buscar(entSIC_LOTEOBSERVACION);
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
        //Creado por	: Pedro Peña Salazar (25/06/2018)
        //Utilizado por	: WebApi.SIC_LOTEOBSERVACION.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_LOTEOBSERVACION
        /// </summary>
        public ICollection<BE.SIC_LOTEOBSERVACION> Listar(BE.SIC_LOTEOBSERVACION entSIC_LOTEOBSERVACION)
        {
            List<BE.SIC_LOTEOBSERVACION> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_LOTEOBSERVACION> entQuery = new DA.SIC_LOTEOBSERVACION().Listar(entSIC_LOTEOBSERVACION);
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
