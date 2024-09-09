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
    public class SIC_ZONIFICACION
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (04/07/2018)
        //Utilizado por	: WebApi.SIC_ZONIFICACION.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_ZONIFICACION
        /// </summary>
        public ICollection<BE.SIC_ZONIFICACION> Buscar(BE.SIC_ZONIFICACION entSIC_LOTELINDEROVIADET)
        {
            List<BE.SIC_ZONIFICACION> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_ZONIFICACION> entQuery = new DA.SIC_ZONIFICACION().Buscar(entSIC_LOTELINDEROVIADET);
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
        //Creado por	: Pedro Peña Salazar (04/07/2018)
        //Utilizado por	: WebApi.SIC_ZONIFICACION.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_ZONIFICACION, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_ZONIFICACION entSIC_ZONIFICACION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_ZONIFICACION().Grabar(entSIC_ZONIFICACION);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (04/07/2018)
        //Utilizado por	: WebApi.SIC_ZONIFICACION.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_ZONIFICACION
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_ZONIFICACION entSIC_ZONIFICACION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_ZONIFICACION().Actualizar(entSIC_ZONIFICACION);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (04/07/2018)
        //Utilizado por	: WebApi.SIC_ZONIFICACION.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_ZONIFICACION
        /// </summary>
        public BE.SIC_ZONIFICACION Recuperar(BE.SIC_ZONIFICACION entSIC_ZONIFICACION)
        {
            BE.SIC_ZONIFICACION lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_ZONIFICACION().Recuperar(entSIC_ZONIFICACION);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (04/07/2018)
        //Utilizado por	: WebApi.SIC_ZONIFICACION.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_ZONIFICACION
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_ZONIFICACION entSIC_ZONIFICACION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_ZONIFICACION().Eliminar(entSIC_ZONIFICACION);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_ZONIFICACION BuscarGrillaZonificacion(BE.SIC_ZONIFICACION entSIC_USOESPE)
        {
            BE.SIC_ZONIFICACION lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_ZONIFICACION().BuscarGrillaZonificacion(entSIC_USOESPE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        public ICollection<BE.SIC_ZONIFICACION> BuscarDetalleGrilla(BE.SIC_ZONIFICACION entSIC_USOESPE)
        {
            List<BE.SIC_ZONIFICACION> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_ZONIFICACION> entQuery = new DA.SIC_ZONIFICACION().BuscarDetalleGrilla(entSIC_USOESPE);
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
