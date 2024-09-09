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
    public class SIC_MANZANAVIA
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (28/06/2018)
        //Utilizado por	: WebApi.SIC_MANZANAVIA.BuscarVias
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_MANZANAVIA
        /// </summary>
        public ICollection<BE.SIC_MANZANAVIA> BuscarVias(BE.SIC_MANZANAVIA entSIC_MANZANAVIA)
        {
            List<BE.SIC_MANZANAVIA> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_MANZANAVIA> entQuery = new DA.SIC_MANZANAVIA().BuscarVias(entSIC_MANZANAVIA);
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
        //Creado por	: Jaime Díaz Espinoza (18/04/2018)
        //Utilizado por	: WebApi.SIC_MANZANAVIA.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_MANZANAVIA
        /// </summary>
        public ICollection<BE.SIC_MANZANAVIA> Buscar(BE.SIC_MANZANAVIA entSIC_MANZANAVIA)
        {
            List<BE.SIC_MANZANAVIA> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_MANZANAVIA> entQuery = new DA.SIC_MANZANAVIA().Buscar(entSIC_MANZANAVIA);
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
        //Creado por	: Pedro Peña Salazar (25/09/2018)
        //Utilizado por	: WebApi.SIC_MANZANAVIA.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_MANZANAVIA
        /// </summary>
        public ICollection<BE.SIC_MANZANAVIA> BuscarDetalle(BE.SIC_MANZANAVIA entSIC_MANZANAVIA)
        {
            List<BE.SIC_MANZANAVIA> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_MANZANAVIA> entQuery = new DA.SIC_MANZANAVIA().BuscarDetalle(entSIC_MANZANAVIA);
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
        //Creado por	: Jaime Díaz Espinoza (18/04/2018)
        //Utilizado por	: WebApi.SIC_MANZANAVIA.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_MANZANAVIA
        /// </summary>
        public BE.SIC_MANZANAVIA Recuperar(BE.SIC_MANZANAVIA entSIC_MANZANAVIA)
        {
            BE.SIC_MANZANAVIA lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_MANZANAVIA().Recuperar(entSIC_MANZANAVIA);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        public BE.SIC_MANZANAVIA RecuperarVerificacion(BE.SIC_MANZANAVIA entSIC_MANZANAVIA)
        {
            BE.SIC_MANZANAVIA lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_MANZANAVIA().RecuperarVerif(entSIC_MANZANAVIA);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (18/04/2018)
        //Utilizado por	: WebApi.SIC_MANZANAVIA.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_MANZANAVIA, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_MANZANAVIA entSIC_MANZANAVIA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_MANZANAVIA().Grabar(entSIC_MANZANAVIA);
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
        //Utilizado por	: WebApi.SIC_MANZANAVIA.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_MANZANAVIA
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_MANZANAVIA entSIC_MANZANAVIA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_MANZANAVIA().Actualizar(entSIC_MANZANAVIA);
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
        //Utilizado por	: WebApi.SIC_MANZANAVIA.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_MANZANAVIA
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_MANZANAVIA entSIC_MANZANAVIA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_MANZANAVIA().Eliminar(entSIC_MANZANAVIA);
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
