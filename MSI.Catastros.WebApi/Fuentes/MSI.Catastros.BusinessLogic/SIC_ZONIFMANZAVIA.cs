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
    public class SIC_ZONIFMANZAVIA
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (11/07/2018)
        //Utilizado por	: WebApi.SIC_ZONIFMANZAVIA.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_ZONIFMANZA
        /// </summary>
        public ICollection<BE.SIC_ZONIFMANZAVIA> Buscar(BE.SIC_ZONIFMANZAVIA entSIC_LOTELINDEROVIADET)
        {
            List<BE.SIC_ZONIFMANZAVIA> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_ZONIFMANZAVIA> entQuery = new DA.SIC_ZONIFMANZAVIA().Buscar(entSIC_LOTELINDEROVIADET);
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
        //Utilizado por	: WebApi.SIC_ZONIFMANZA.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_ZONIFMANZA, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_ZONIFMANZAVIA entSIC_ZONIFLOTE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_ZONIFMANZAVIA().Grabar(entSIC_ZONIFLOTE);
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
        //Utilizado por	: WebApi.SIC_ZONIFMANZA.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_ZONIFMANZA
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_ZONIFMANZAVIA entSIC_ZONIFLOTE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_ZONIFMANZAVIA().Actualizar(entSIC_ZONIFLOTE);
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
        //Utilizado por	: WebApi.SIC_ZONIFMANZA.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_ZONIFMANZA
        /// </summary>
        public BE.SIC_ZONIFMANZA Recuperar(BE.SIC_ZONIFMANZAVIA entSIC_ZONIFLOTE)
        {
            BE.SIC_ZONIFMANZA lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_ZONIFMANZAVIA().Recuperar(entSIC_ZONIFLOTE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (04/07/2018)
        //Utilizado por	: WebApi.SIC_ZONIFMANZA.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_ZONIFMANZA
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_ZONIFMANZAVIA entSIC_ZONIFLOTE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_ZONIFMANZAVIA().Eliminar(entSIC_ZONIFLOTE);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Eistein Dolores Tarazon(18/04/2018)
        //Utilizado por	: WebApi.SIC_MANZANA.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_ZONIFMANZAVIA
        /// </summary>
        public ICollection<BE.SIC_ZONIFMANZAVIA> Listar(BE.SIC_ZONIFMANZAVIA entSIC_MANZANA)
        {
            List<BE.SIC_ZONIFMANZAVIA> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_ZONIFMANZAVIA> entQuery = new DA.SIC_ZONIFMANZAVIA().Listar(entSIC_MANZANA);
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
