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
    public class SIC_UNIDAD
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (28/05/2018)
        //Utilizado por	: WebApi.SIC_UNIDAD.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_UNIDAD
        /// </summary>
        public ICollection<BE.SIC_UNIDAD> Buscar(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            List<BE.SIC_UNIDAD> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_UNIDAD> entQuery = new DA.SIC_UNIDAD().Buscar(entSIC_UNIDAD);
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
        public ICollection<BE.SIC_UNIDAD> BuscarBC(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            List<BE.SIC_UNIDAD> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_UNIDAD> entQuery = new DA.SIC_UNIDAD().BuscarBC(entSIC_UNIDAD);
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
        public ICollection<BE.SIC_UNIDAD> BuscarEstado(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            List<BE.SIC_UNIDAD> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_UNIDAD> entQuery = new DA.SIC_UNIDAD().BuscarEstado(entSIC_UNIDAD);
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
        public ICollection<BE.SIC_UNIDAD> BuscarEstadoSimple(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            List<BE.SIC_UNIDAD> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_UNIDAD> entQuery = new DA.SIC_UNIDAD().BuscarEstadoSimple(entSIC_UNIDAD);
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
        public ICollection<BE.SIC_UNIDAD> BuscarEstadoLote(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            List<BE.SIC_UNIDAD> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_UNIDAD> entQuery = new DA.SIC_UNIDAD().BuscarEstadoLote(entSIC_UNIDAD);
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
        
        public BE.SIC_UNIDAD BuscarEstadoInt(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_UNIDAD lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_UNIDAD().BuscarEstadosInt(entSIC_UNIDAD);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Quispe Ipanaque (12/10/2018)
        //Utilizado por	: WebApi.SIC_UNIDAD.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_UNIDAD
        /// </summary>
        public ICollection<BE.SIC_UNIDAD> BuscarPorUbicacion(BE.SIC_LOTEDIRECMUNI entSIC_UNIDAD)
        {
            List<BE.SIC_UNIDAD> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_UNIDAD> entQuery = new DA.SIC_UNIDAD().BuscarPorUbicacion(entSIC_UNIDAD);
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
        //Creado por	: Jaime Díaz Espinoza (22/06/2018)
        //Utilizado por	: WebApi.SIC_UNIDAD.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_UNIDAD, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDAD().Grabar(entSIC_UNIDAD);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Diego Quispe (16/10/2018)
        //Utilizado por	: WebApi.SIC_UNIDAD.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_UNIDAD, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO GrabarTempSolUnidad(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDAD().GrabarTempSolUnidad(entSIC_UNIDAD);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }


        public BE.SIC_RETORNO ValidarTempSolUnidad(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDAD().ValidarTempSolUnidad(entSIC_UNIDAD);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }

        public BE.SIC_RETORNO GrabarTempSolUnidadAcum(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDAD().GrabarTempSolUnidadAcum(entSIC_UNIDAD);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Diego Quispe Iapanque (05/10/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDAD.PasarEstaticoTemporal
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite migrar los datos del esquema estatico al temporal
        /// </summary>
        public BE.SIC_RETORNO MigrarEstaticoTemporal(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDAD().MigrarEstaticoTemporal(entSIC_UNIDAD);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Diego Quispe Iapanque (05/10/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDAD.PasarEstaticoTemporal
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite migrar los datos del esquema estatico al temporal
        /// </summary>
        public BE.SIC_RETORNO MigrarTemporalEstatico(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDAD().MigrarTemporalEstatico(entSIC_UNIDAD);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }

        public BE.SIC_RETORNO EliminarTemporal(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDAD().EliminarTemporal(entSIC_UNIDAD);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO HabilitarUnidad(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDAD().HabilitarUnidad(entSIC_UNIDAD);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO ActualizarLoteUnidad(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDAD().ActualizarLoteUnidad(entSIC_UNIDAD);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO ActualizarUnidad(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDAD().ActualizarUnidad(entSIC_UNIDAD);
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
        //Utilizado por	: WebApi.SIC_UNIDAD.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_UNIDAD
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDAD().Actualizar(entSIC_UNIDAD);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO ActualizarAreas(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDAD().ActualizarAreas(entSIC_UNIDAD);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO ActualizarUnical(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDAD().ActualizarUnical(entSIC_UNIDAD);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO Recapitular(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDAD().Recapitular(entSIC_UNIDAD);
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
        //Utilizado por	: WebApi.SIC_UNIDAD.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_UNIDAD
        /// </summary>
        public BE.SIC_UNIDAD Recuperar(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_UNIDAD lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_UNIDAD().Recuperar(entSIC_UNIDAD);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        public BE.SIC_UNIDAD RecuperarxCC(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_UNIDAD lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_UNIDAD().RecuperarxCC(entSIC_UNIDAD);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }


        public BE.SIC_UNIDAD RecuperarSolicitud(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_UNIDAD lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_UNIDAD().RecuperarSolicitud(entSIC_UNIDAD);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/06/2018)
        //Utilizado por	: WebApi.SIC_UNIDAD.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_UNIDAD
        /// </summary>
        public BE.SIC_UNIDAD RecuperarTemporal(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_UNIDAD lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_UNIDAD().RecuperarTemporal(entSIC_UNIDAD);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }

        
        public BE.SIC_UNIDAD RecuperarPorcentajeCalculado(BE.SIC_UNIDBIENCOMUN entSIC_UNIDAD)
        {
            BE.SIC_UNIDAD lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_UNIDAD().RecuperarPorcentajeCalculado(entSIC_UNIDAD);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        public BE.SIC_UNIDAD RecuperarTemporalAreaTerrenoComun(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_UNIDAD lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_UNIDAD().RecuperarTemporalAreaTerrenoComun(entSIC_UNIDAD);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/06/2018)
        //Utilizado por	: WebApi.SIC_UNIDAD.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_UNIDAD
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDAD().Eliminar(entSIC_UNIDAD);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }

        public BE.SIC_RETORNO ValidarTemporal(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDAD().ValidarTemporal(entSIC_UNIDAD);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }

        public BE.SIC_RETORNO ValidarYaTemporal(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDAD().ValidarYaTemporal(entSIC_UNIDAD);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }

        public BE.SIC_RETORNO ActualizarFlgTemporal(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDAD().ActualizarFlgTemporal(entSIC_UNIDAD);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }

        public BE.SIC_RETORNO ActualizarFlgTemporalNull(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDAD().ActualizarFlgTemporalNull(entSIC_UNIDAD);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }

        public BE.SIC_UNIDAD ValidacionEliminar(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_UNIDAD lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_UNIDAD().ValidacionEliminar(entSIC_UNIDAD);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }

        public ICollection<BE.SIC_UNIDADINSPECCION> ListarUnidadInspeccion(BE.SIC_UNIDADINSPECCION entSIC_UNIDAD)
        {
            List<BE.SIC_UNIDADINSPECCION> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_UNIDADINSPECCION> entQuery = new DA.SIC_UNIDAD().ListarUnidadInspeccion(entSIC_UNIDAD);
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

        public ICollection<BE.SIC_UNIDADINSPECCION> ListarUnidadCartasInformes(BE.SIC_UNIDADINSPECCION entSIC_UNIDAD)
        {
            List<BE.SIC_UNIDADINSPECCION> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_UNIDADINSPECCION> entQuery = new DA.SIC_UNIDAD().ListarUnidadCartasInformes(entSIC_UNIDAD);
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


        public BE.SIC_UNIDAD RecuperarFoto(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_UNIDAD lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_UNIDAD().RecuperarFoto(entSIC_UNIDAD);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }

        public BE.SIC_UNIDAD RecuperarFotoEdificacion(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_UNIDAD lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_UNIDAD().RecuperarFotoEdificacion(entSIC_UNIDAD);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }

        public BE.SIC_UNIDAD RecuperarHistoricoUnidadCatastralEST(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_UNIDAD lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_UNIDAD().RecuperarHistoricoUnidadCatastralEST(entSIC_UNIDAD);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
    }
}
