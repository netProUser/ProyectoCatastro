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
    public class SIC_LOTE
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (07/06/2018)
        //Utilizado por	: WebApi.SIC_LOTE.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_LOTE, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_LOTE entSIC_LOTE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_LOTE().Grabar(entSIC_LOTE);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (07/06/2018)
        //Utilizado por	: WebApi.SIC_LOTE.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_LOTE
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_LOTE entSIC_LOTE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_LOTE().Actualizar(entSIC_LOTE);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }

      
        public ICollection<BE.SIC_LOTE> RecuperarSolicitud(BE.SIC_LOTE entSIC_LOTE)
        {
            List<BE.SIC_LOTE> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_LOTE> entQuery = new DA.SIC_LOTE().RecuperarSolicitud(entSIC_LOTE);
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
        //Creado por	: Jaime Díaz Espinoza (07/06/2018)
        //Utilizado por	: WebApi.SIC_LOTE.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_LOTE
        /// </summary>
        public BE.SIC_LOTE Recuperar(BE.SIC_LOTE entSIC_LOTE)
        {
            BE.SIC_LOTE lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_LOTE().Recuperar(entSIC_LOTE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (07/06/2018)
        //Utilizado por	: WebApi.SIC_LOTE.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_LOTE
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_LOTE entSIC_LOTE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_LOTE().Eliminar(entSIC_LOTE);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (18/04/2018)
        //Utilizado por	: WebApi.SIC_LOTE.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_LOTE
        /// </summary>
        public ICollection<BE.SIC_LOTE> Listar(BE.SIC_LOTE entSIC_LOTE)
        {
            List<BE.SIC_LOTE> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_LOTE> entQuery = new DA.SIC_LOTE().Listar(entSIC_LOTE);
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
        
        public ICollection<BE.SIC_LOTE> ListarEstaticoIgual(BE.SIC_LOTE entSIC_LOTE)
        {
            List<BE.SIC_LOTE> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_LOTE> entQuery = new DA.SIC_LOTE().ListarEstaticoIgual(entSIC_LOTE);
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
        public ICollection<BE.SIC_LOTE> ListarEstatico(BE.SIC_LOTE entSIC_LOTE)
        {
            List<BE.SIC_LOTE> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_LOTE> entQuery = new DA.SIC_LOTE().ListarEstatico(entSIC_LOTE);
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
        public ICollection<BE.SIC_LOTE> ListarColindanteLoteMobiliarioUrbanoSelect(BE.SIC_LOTE entSIC_LOTE)
        {
            List<BE.SIC_LOTE> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_LOTE> entQuery = new DA.SIC_LOTE().ListarColindanteLoteMobiliarioUrbanoSelect(entSIC_LOTE);
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
        //Creado por	: Pedro Peña Salazar (18/07/2018)
        //Utilizado por	: WebApi.SIC_LOTE.ListarDocum
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_LOTE
        /// </summary>
        public ICollection<BE.SIC_LOTE> ListarDocum(BE.SIC_LOTE entSIC_LOTE)
        {
            List<BE.SIC_LOTE> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_LOTE> entQuery = new DA.SIC_LOTE().ListarDocum(entSIC_LOTE);
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
        //Creado por	: Pedro Peña Salazar (18/07/2018)
        //Utilizado por	: WebApi.SIC_LOTE.ListarInspec
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_LOTE
        /// </summary>
        public ICollection<BE.SIC_LOTE> ListarInspec(BE.SIC_LOTE entSIC_LOTE)
        {
            List<BE.SIC_LOTE> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_LOTE> entQuery = new DA.SIC_LOTE().ListarInspec(entSIC_LOTE);
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
        //Creado por	: Pedro Peña Salazar (25/10/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTE.PasarEstaticoTemporal
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite migrar los datos del esquema estatico al temporal
        /// </summary>
        public BE.SIC_RETORNO MigrarEstaticoTemporal(BE.SIC_LOTE entSIC_LOTE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_LOTE().MigrarEstaticoTemporal(entSIC_LOTE);
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
