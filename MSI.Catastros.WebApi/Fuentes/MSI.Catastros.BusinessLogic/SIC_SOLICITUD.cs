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
    public class SIC_SOLICITUD
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (17/05/2018)
        //Utilizado por	: WebApi.SIC_SOLICITUD.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_SOLICITUD, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_SOLICITUD entSIC_SOLICITUD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_SOLICITUD().Grabar(entSIC_SOLICITUD);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/05/2018)
        //Utilizado por	: WebApi.SIC_SOLICITUD.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_SOLICITUD
        /// </summary>
        public BE.SIC_SOLICITUD Recuperar(BE.SIC_SOLICITUD entSIC_SOLICITUD)
        {
            BE.SIC_SOLICITUD lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_SOLICITUD().Recuperar(entSIC_SOLICITUD);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (17/05/2018)
        //Utilizado por	: WebApi.SIC_SOLICITUD.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_SOLICITUD
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_SOLICITUD entSIC_SOLICITUD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_SOLICITUD().Actualizar(entSIC_SOLICITUD);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }

        public BE.SIC_RETORNO ActualizarInspecciones(BE.SIC_SOLICITUD entSIC_SOLICITUD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_SOLICITUD().ActualizarInspecciones(entSIC_SOLICITUD);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (17/05/2018)
        //Utilizado por	: WebApi.SIC_SOLICITUD.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_SOLICITUD
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_SOLICITUD entSIC_SOLICITUD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_SOLICITUD().Eliminar(entSIC_SOLICITUD);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (17/05/2018)
        //Utilizado por	: WebApi.SIC_SOLICITUD.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_SOLICITUD
        /// </summary>
        public ICollection<BE.SIC_SOLICITUD> Buscar(BE.SIC_SOLICITUD entSIC_SOLICITUD)
        {
            List<BE.SIC_SOLICITUD> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_SOLICITUD> entQuery = new DA.SIC_SOLICITUD().Buscar(entSIC_SOLICITUD);
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
        //Creado por	: Jaime Díaz Espinoza (21/05/2018)
        //Utilizado por	: WebApi.SIC_SOLICITUD.BuscarInt
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_SOLICITUD
        /// </summary>
        public BE.SIC_SOLICITUD BuscarInt(BE.SIC_SOLICITUD entSIC_SOLICITUD)
        {
            BE.SIC_SOLICITUD lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_SOLICITUD().BuscarInt(entSIC_SOLICITUD);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (30/05/2018)
        //Utilizado por	: WebApi.SIC_SOLICITUD.Seguimiento
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_SOLICITUD
        /// </summary>
        public ICollection<BE.SIC_SOLICITUD> Seguimiento(BE.SIC_SOLICITUD entSIC_SOLICITUD)
        {
            List<BE.SIC_SOLICITUD> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_SOLICITUD> entQuery = new DA.SIC_SOLICITUD().Seguimiento(entSIC_SOLICITUD);
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
        public ICollection<BE.SIC_SOLICITUD> CargarGrillaCatastral(BE.SIC_SOLICITUD entSIC_SOLICITUD)
        {
            List<BE.SIC_SOLICITUD> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_SOLICITUD> entQuery = new DA.SIC_SOLICITUD().CargarGrillaCatastral(entSIC_SOLICITUD);
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
        
        public ICollection<BE.SIC_SOLICITUD> CargarGrillaCatastralInternaPendiente(BE.SIC_SOLICITUD entSIC_SOLICITUD)
        {
            List<BE.SIC_SOLICITUD> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_SOLICITUD> entQuery = new DA.SIC_SOLICITUD().CargarGrillaCatastralInternaPendiente(entSIC_SOLICITUD);
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
        public ICollection<BE.SIC_SOLICITUD> CargarGrillaCatastralExternaPendiente(BE.SIC_SOLICITUD entSIC_SOLICITUD)
        {
            List<BE.SIC_SOLICITUD> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_SOLICITUD> entQuery = new DA.SIC_SOLICITUD().CargarGrillaCatastralExternaPendiente(entSIC_SOLICITUD);
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
        public BE.SIC_SOLICITUD RecuperarDatosSolicitud(BE.SIC_SOLICITUD entSIC_UNIDAD)
        {
            BE.SIC_SOLICITUD lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_SOLICITUD().RecuperarDatosSolicitud(entSIC_UNIDAD);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }

        public BE.SIC_RETORNO RechazaraDocumentos(BE.SIC_SOLICITUD entSIC_SOLICITUD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_SOLICITUD().RechazaraDocumentos(entSIC_SOLICITUD);
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
