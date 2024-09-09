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
    public class SIC_PROGINSPEC
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (28/05/2018)
        //Utilizado por	: WebApi.SIC_PROGINSPEC.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_PROGINSPEC, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_PROGINSPEC entSIC_PROGINSPEC)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_PROGINSPEC().Grabar(entSIC_PROGINSPEC);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (28/05/2018)
        //Utilizado por	: WebApi.SIC_PROGINSPEC.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_PROGINSPEC
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_PROGINSPEC entSIC_PROGINSPEC)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_PROGINSPEC().Actualizar(entSIC_PROGINSPEC);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (28/05/2018)
        //Utilizado por	: WebApi.SIC_PROGINSPEC.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_PROGINSPEC
        /// </summary>
        public BE.SIC_PROGINSPEC Recuperar(BE.SIC_PROGINSPEC entSIC_PROGINSPEC)
        {
            BE.SIC_PROGINSPEC lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_PROGINSPEC().Recuperar(entSIC_PROGINSPEC);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        public BE.SIC_PROGINSPEC ListarInspectores(BE.SIC_PROGINSPEC entSIC_PROGINSPEC)
        {
            BE.SIC_PROGINSPEC lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_PROGINSPEC().ListarInspectores(entSIC_PROGINSPEC);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (28/05/2018)
        //Utilizado por	: WebApi.SIC_PROGINSPEC.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_PROGINSPEC
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_PROGINSPEC entSIC_PROGINSPEC)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_PROGINSPEC().Eliminar(entSIC_PROGINSPEC);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (31/05/2018)
        //Utilizado por	: WebApi.SIC_PROGINSPEC.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_PROGINSPEC
        /// </summary>
        public ICollection<BE.SIC_PROGINSPEC> Listar(BE.SIC_PROGINSPEC entSIC_PROGINSPEC)
        {
            List<BE.SIC_PROGINSPEC> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PROGINSPEC> entQuery = new DA.SIC_PROGINSPEC().Listar(entSIC_PROGINSPEC);
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
        public BE.SIC_PROGINSPEC ListarUltima(BE.SIC_PROGINSPEC entSIC_PROGINSPEC)
        {
            BE.SIC_PROGINSPEC lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_PROGINSPEC().ListarUltima(entSIC_PROGINSPEC);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }

        public ICollection<BE.SIC_PROGINSPEC> ListarNumero(BE.SIC_PROGINSPEC entSIC_PROGINSPEC)
        {
            List<BE.SIC_PROGINSPEC> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PROGINSPEC> entQuery = new DA.SIC_PROGINSPEC().ListarNumero(entSIC_PROGINSPEC);
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

        public IEnumerable<BE.SIC_PROGINSPEC> ListarStatusInspecciones(Int16 entTipoBusqueda, string entNroSolicitud, DateTime? FechaInicio, DateTime? FechaFin)
        {
            List<BE.SIC_PROGINSPEC> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PROGINSPEC> entQuery = new DA.SIC_PROGINSPEC().ListarStatusInspecciones(entTipoBusqueda, entNroSolicitud, FechaInicio, FechaFin);
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
        public IEnumerable<BE.SIC_PROGINSPEC> ConsultaStatusInspecciones(BE.SIC_PROGINSPEC entConsultaInspeccion)
        {
            List<BE.SIC_PROGINSPEC> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PROGINSPEC> entQuery = new DA.SIC_PROGINSPEC().ConsultaStatusInspecciones(entConsultaInspeccion);
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
