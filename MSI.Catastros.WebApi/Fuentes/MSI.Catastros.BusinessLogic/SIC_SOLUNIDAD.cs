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
    public class SIC_SOLUNIDAD
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (28/05/2018)
        //Utilizado por	: WebApi.SIC_SOLUNIDAD.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_SOLUNIDAD, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_SOLUNIDAD().Grabar(entSIC_SOLUNIDAD);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO GrabarNuevo(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_SOLUNIDAD().GrabarNuevo(entSIC_SOLUNIDAD);
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
        //Utilizado por	: WebApi.SIC_SOLUNIDAD.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_SOLUNIDAD
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_SOLUNIDAD().Actualizar(entSIC_SOLUNIDAD);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO ActualizarFlag(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_SOLUNIDAD().ActualizarFlag(entSIC_SOLUNIDAD);
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
        //Utilizado por	: WebApi.SIC_SOLUNIDAD.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_SOLUNIDAD
        /// </summary>
        public BE.SIC_SOLUNIDAD Recuperar(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            BE.SIC_SOLUNIDAD lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_SOLUNIDAD().Recuperar(entSIC_SOLUNIDAD);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;

        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (28/05/2018)
        //Utilizado por	: WebApi.SIC_SOLUNIDAD.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_SOLUNIDAD
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_SOLUNIDAD().Eliminar(entSIC_SOLUNIDAD);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO EliminarNuevo(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_SOLUNIDAD().EliminarNuevo(entSIC_SOLUNIDAD);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }

        public BE.SIC_RETORNO EliminarNuevoUnidad(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_SOLUNIDAD().EliminarNuevoUnidad(entSIC_SOLUNIDAD);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (30/05/2018)
        //Utilizado por	: WebApi.SIC_SOLUNIDAD.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_SOLUNIDAD
        /// </summary>
        public ICollection<BE.SIC_SOLUNIDAD> Buscar(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            List<BE.SIC_SOLUNIDAD> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_SOLUNIDAD> entQuery = new DA.SIC_SOLUNIDAD().Buscar(entSIC_SOLUNIDAD);
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
        public ICollection<BE.SIC_SOLUNIDAD> BuscarMasivo(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            List<BE.SIC_SOLUNIDAD> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_SOLUNIDAD> entQuery = new DA.SIC_SOLUNIDAD().BuscarMasivo(entSIC_SOLUNIDAD);
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
        public ICollection<BE.SIC_SOLUNIDAD> Buscar2(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            List<BE.SIC_SOLUNIDAD> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_SOLUNIDAD> entQuery = new DA.SIC_SOLUNIDAD().Buscar2(entSIC_SOLUNIDAD);
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

        public ICollection<BE.SIC_SOLUNIDAD> ParaMigrar(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            List<BE.SIC_SOLUNIDAD> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_SOLUNIDAD> entQuery = new DA.SIC_SOLUNIDAD().ParaMigrar(entSIC_SOLUNIDAD);
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


        public ICollection<BE.SIC_SOLUNIDAD> ParaMigrarLote(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            List<BE.SIC_SOLUNIDAD> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_SOLUNIDAD> entQuery = new DA.SIC_SOLUNIDAD().ParaMigrarLote(entSIC_SOLUNIDAD);
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

        public ICollection<BE.SIC_SOLUNIDAD> BuscarBComun(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            List<BE.SIC_SOLUNIDAD> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_SOLUNIDAD> entQuery = new DA.SIC_SOLUNIDAD().BuscarBComun(entSIC_SOLUNIDAD);
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

        public ICollection<BE.SIC_SOLUNIDAD> RecuperarxCC(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            List<BE.SIC_SOLUNIDAD> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_SOLUNIDAD> entQuery = new DA.SIC_SOLUNIDAD().RecuperarxCC(entSIC_SOLUNIDAD);
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

        public ICollection<BE.SIC_SOLUNIDAD> RecuperarxCCU(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            List<BE.SIC_SOLUNIDAD> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_SOLUNIDAD> entQuery = new DA.SIC_SOLUNIDAD().RecuperarxCCU(entSIC_SOLUNIDAD);
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

        public BE.SIC_SOLUNIDAD Listar(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            BE.SIC_SOLUNIDAD lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_SOLUNIDAD().Listar(entSIC_SOLUNIDAD);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        public ICollection<BE.SIC_SOLUNIDAD> BuscarTitulares(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            List<BE.SIC_SOLUNIDAD> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_SOLUNIDAD> entQuery = new DA.SIC_SOLUNIDAD().BuscarTitulares(entSIC_SOLUNIDAD);
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
        public ICollection<BE.SIC_SOLUNIDAD> BuscarSolicitud(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            List<BE.SIC_SOLUNIDAD> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_SOLUNIDAD> entQuery = new DA.SIC_SOLUNIDAD().BuscarSolicitud(entSIC_SOLUNIDAD);
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
        public ICollection<BE.SIC_SOLUNIDAD> BuscarSolMasivo(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            List<BE.SIC_SOLUNIDAD> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_SOLUNIDAD> entQuery = new DA.SIC_SOLUNIDAD().BuscarSolMasivo(entSIC_SOLUNIDAD);
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
        public ICollection<BE.SIC_SOLUNIDAD> BuscarDirec(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            List<BE.SIC_SOLUNIDAD> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_SOLUNIDAD> entQuery = new DA.SIC_SOLUNIDAD().BuscarDirec(entSIC_SOLUNIDAD);
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
        public ICollection<BE.SIC_SOLUNIDAD> BuscarDirecTemp(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            List<BE.SIC_SOLUNIDAD> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_SOLUNIDAD> entQuery = new DA.SIC_SOLUNIDAD().BuscarDirecTemp(entSIC_SOLUNIDAD);
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
        public ICollection<BE.SIC_SOLUNIDAD> BuscarDirecCerti(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            List<BE.SIC_SOLUNIDAD> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_SOLUNIDAD> entQuery = new DA.SIC_SOLUNIDAD().BuscarDirecCerti(entSIC_SOLUNIDAD);
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
        public ICollection<BE.SIC_SOLUNIDAD> BuscarCerti(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            List<BE.SIC_SOLUNIDAD> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_SOLUNIDAD> entQuery = new DA.SIC_SOLUNIDAD().BuscarCerti(entSIC_SOLUNIDAD);
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
        public ICollection<BE.SIC_SOLUNIDAD> BuscarCertiFilter(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            List<BE.SIC_SOLUNIDAD> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_SOLUNIDAD> entQuery = new DA.SIC_SOLUNIDAD().BuscarCertiFilter(entSIC_SOLUNIDAD);
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
        //Creado por	: Jaime Díaz Espinoza (12/06/2018)
        //Utilizado por	: WebApi.SIC_SOLUNIDAD.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_SOLUNIDAD
        /// </summary>
        public ICollection<BE.SIC_SOLUNIDAD> BuscarUnique(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            List<BE.SIC_SOLUNIDAD> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_SOLUNIDAD> entQuery = new DA.SIC_SOLUNIDAD().BuscarUnique(entSIC_SOLUNIDAD);
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

        public ICollection<BE.SIC_SOLUNIDAD> RecuperarHistoricoxCCU(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            List<BE.SIC_SOLUNIDAD> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_SOLUNIDAD> entQuery = new DA.SIC_SOLUNIDAD().RecuperarHistoricoxCCU(entSIC_SOLUNIDAD);
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
