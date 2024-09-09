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
    public class SIC_MOVINSPEC
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (28/05/2018)
        //Utilizado por	: WebApi.SIC_MOVINSPEC.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_MOVINSPEC, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_MOVINSPEC entSIC_MOVINSPEC)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_MOVINSPEC().Grabar(entSIC_MOVINSPEC);
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
        //Utilizado por	: WebApi.SIC_MOVINSPEC.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_MOVINSPEC
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_MOVINSPEC entSIC_MOVINSPEC)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_MOVINSPEC().Actualizar(entSIC_MOVINSPEC);
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
        //Utilizado por	: WebApi.SIC_MOVINSPEC.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_MOVINSPEC
        /// </summary>
        public BE.SIC_MOVINSPEC Recuperar(BE.SIC_MOVINSPEC entSIC_MOVINSPEC)
        {
            BE.SIC_MOVINSPEC lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_MOVINSPEC().Recuperar(entSIC_MOVINSPEC);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (28/05/2018)
        //Utilizado por	: WebApi.SIC_MOVINSPEC.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_MOVINSPEC
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_MOVINSPEC entSIC_MOVINSPEC)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_MOVINSPEC().Eliminar(entSIC_MOVINSPEC);
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
        //Utilizado por	: WebApi.SIC_MOVINSPEC.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_MOVINSPEC
        /// </summary>
        public ICollection<BE.SIC_MOVINSPEC> Listar(BE.SIC_MOVINSPEC entSIC_MOVINSPEC)
        {
            List<BE.SIC_MOVINSPEC> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_MOVINSPEC> entQuery = new DA.SIC_MOVINSPEC().Listar(entSIC_MOVINSPEC);
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
        public ICollection<BE.SIC_MOVINSPEC> ListarInforme(BE.SIC_MOVINSPEC entSIC_MOVINSPEC)
        {
            List<BE.SIC_MOVINSPEC> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_MOVINSPEC> entQuery = new DA.SIC_MOVINSPEC().ListarInforme(entSIC_MOVINSPEC);
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
        //Creado por	: Jaime Díaz Espinoza (19/06/2018)
        //Utilizado por	: WebApi.SIC_MOVINSPEC.Inspectores
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_MOVINSPEC
        /// </summary>
        public ICollection<BE.SIC_MOVINSPEC> Inspectores(BE.SIC_MOVINSPEC entSIC_MOVINSPEC)
        {
            List<BE.SIC_MOVINSPEC> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_MOVINSPEC> entQuery = new DA.SIC_MOVINSPEC().Inspectores(entSIC_MOVINSPEC);
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
