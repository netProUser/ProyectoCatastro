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
    public class SIC_VIADETALLE
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (17/04/2018)
        //Utilizado por	: WebApi.SIC_VIADETALLE.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_VIADETALLE
        /// </summary>
        public ICollection<BE.SIC_VIADETALLE> Buscar(BE.SIC_VIADETALLE entSIC_VIADETALLE)
        {
            List<BE.SIC_VIADETALLE> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_VIADETALLE> entQuery = new DA.SIC_VIADETALLE().Buscar(entSIC_VIADETALLE);
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
        //Creado por	: Jaime Díaz Espinoza (26/04/2018)
        //Utilizado por	: WebApi.SIC_VIADETALLE.BuscarInt
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_VIA
        /// </summary>
        public BE.SIC_VIADETALLE BuscarInt(BE.SIC_VIADETALLE entSIC_VIADETALLE)
        {
            BE.SIC_VIADETALLE lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_VIADETALLE().BuscarInt(entSIC_VIADETALLE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (07/05/2018)
        //Utilizado por	: WebApi.SIC_VIADETALLE.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_VIADETALLE
        /// </summary>
        public ICollection<BE.SIC_VIADETALLE> Listar(BE.SIC_VIADETALLE entSIC_VIADETALLE)
        {
            List<BE.SIC_VIADETALLE> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_VIADETALLE> entQuery = new DA.SIC_VIADETALLE().Listar(entSIC_VIADETALLE);
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
        //Creado por	: Pedro Peña Salazar (09/07/2018)
        //Utilizado por	: WebApi.SIC_VIADETALLE.Retiro
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_VIADETALLE
        /// </summary>
        public BE.SIC_VIADETALLE Retiro(BE.SIC_VIADETALLE entSIC_VIADETALLE)
        {
            BE.SIC_VIADETALLE lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_VIADETALLE().Retiro(entSIC_VIADETALLE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (18/04/2018)
        //Utilizado por	: WebApi.SIC_VIADETALLE.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_VIADETALLE
        /// </summary>
        public BE.SIC_VIADETALLE Recuperar(BE.SIC_VIADETALLE entSIC_VIADETALLE)
        {
            BE.SIC_VIADETALLE lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_VIADETALLE().Recuperar(entSIC_VIADETALLE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (18/04/2018)
        //Utilizado por	: WebApi.SIC_VIADETALLE.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_VIADETALLE, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_VIADETALLE entSIC_VIADETALLE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_VIADETALLE().Grabar(entSIC_VIADETALLE);
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
        //Utilizado por	: WebApi.SIC_VIADETALLE.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_VIADETALLE
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_VIADETALLE entSIC_VIADETALLE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_VIADETALLE().Actualizar(entSIC_VIADETALLE);
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
        //Utilizado por	: WebApi.SIC_VIADETALLE.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_VIADETALLE
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_VIADETALLE entSIC_VIADETALLE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_VIADETALLE().Eliminar(entSIC_VIADETALLE);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (08/06/2018)
        //Utilizado por	: WebApi.SIC_VIADETALLE.NumeroCuadra
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_VIADETALLE
        /// </summary>
        public int NumeroCuadra(BE.SIC_VIADETALLE entSIC_VIADETALLE)
        {
            int intResultado = 0;
            try
            {
                intResultado = new DA.SIC_VIADETALLE().NumeroCuadra(entSIC_VIADETALLE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return intResultado;
        }
    }
}
