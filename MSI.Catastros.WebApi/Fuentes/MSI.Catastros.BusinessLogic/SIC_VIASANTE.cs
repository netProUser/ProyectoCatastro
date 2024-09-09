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
    public class SIC_VIASANTE
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (07/05/2018)
        //Utilizado por	: WebApi.SIC_VIASANTE.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_VIASANTE
        /// </summary>
        public ICollection<BE.SIC_VIASANTE> Buscar(BE.SIC_VIASANTE entSIC_VIASANTE)
        {
            List<BE.SIC_VIASANTE> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_VIASANTE> entQuery = new DA.SIC_VIASANTE().Buscar(entSIC_VIASANTE);
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
        //Creado por	: Jaime Díaz Espinoza (07/05/2018)
        //Utilizado por	: WebApi.SIC_VIASANTE.BuscarInt
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_VIA
        /// </summary>
        public BE.SIC_VIASANTE BuscarInt(BE.SIC_VIASANTE entSIC_VIASANTE)
        {
            BE.SIC_VIASANTE lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_VIASANTE().BuscarInt(entSIC_VIASANTE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (07/05/2018)
        //Utilizado por	: WebApi.SIC_VIASANTE.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_VIASANTE
        /// </summary>
        public BE.SIC_VIASANTE Recuperar(BE.SIC_VIASANTE entSIC_VIASANTE)
        {
            BE.SIC_VIASANTE lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_VIASANTE().Recuperar(entSIC_VIASANTE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (07/05/2018)
        //Utilizado por	: WebApi.SIC_VIASANTE.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_VIASANTE, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_VIASANTE entSIC_VIASANTE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_VIASANTE().Grabar(entSIC_VIASANTE);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (07/05/2018)
        //Utilizado por	: WebApi.SIC_VIASANTE.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_VIASANTE
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_VIASANTE entSIC_VIASANTE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_VIASANTE().Actualizar(entSIC_VIASANTE);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (07/05/2018)
        //Utilizado por	: WebApi.SIC_VIASANTE.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_VIASANTE
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_VIASANTE entSIC_VIASANTE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_VIASANTE().Eliminar(entSIC_VIASANTE);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (16/06/2018)
        //Utilizado por	: WebApi.SIC_VIASANTE.ValidarFechas
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_VIASANTE
        /// </summary>
        public BE.SIC_RETORNO ValidarFechas(BE.SIC_VIASANTE entSIC_VIASANTE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_VIASANTE().ValidarFechas(entSIC_VIASANTE);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }

        public BE.SIC_RETORNO ValidarFechasActualizar(BE.SIC_VIASANTE entSIC_VIASANTE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_VIASANTE().ValidarFechasActualizar(entSIC_VIASANTE);
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
