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
    public class SIC_LOTELINDEROVIADET
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (02/07/2018)
        //Utilizado por	: WebApi.SIC_LOTELINDEROVIADET.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_LOTELINDEROVIADET
        /// </summary>
        public ICollection<BE.SIC_LOTELINDEROVIADET> Buscar(BE.SIC_LOTELINDEROVIADET entSIC_LOTELINDEROVIADET)
        {
            List<BE.SIC_LOTELINDEROVIADET> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_LOTELINDEROVIADET> entQuery = new DA.SIC_LOTELINDEROVIADET().Buscar(entSIC_LOTELINDEROVIADET);
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
       
        public ICollection<BE.SIC_LOTELINDEROVIADET> BuscarVias(BE.SIC_LOTELINDEROVIADET entSIC_LOTELINDEROVIADET)
        {
            List<BE.SIC_LOTELINDEROVIADET> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_LOTELINDEROVIADET> entQuery = new DA.SIC_LOTELINDEROVIADET().BuscarVias(entSIC_LOTELINDEROVIADET);
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
        //Utilizado por	: WebApi.SIC_LOTELINDEROVIADET.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_LOTELINDEROVIADET, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_LOTELINDEROVIADET entSIC_LOTELINDEROVIADET)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_LOTELINDEROVIADET().Grabar(entSIC_LOTELINDEROVIADET);
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
        //Utilizado por	: WebApi.SIC_LOTELINDEROVIADET.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_LOTELINDEROVIADET
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_LOTELINDEROVIADET entSIC_LOTELINDEROVIADET)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_LOTELINDEROVIADET().Actualizar(entSIC_LOTELINDEROVIADET);
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
        //Utilizado por	: WebApi.SIC_LOTELINDEROVIADET.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_LOTELINDEROVIADET
        /// </summary>
        public BE.SIC_LOTELINDEROVIADET Recuperar(BE.SIC_LOTELINDEROVIADET entSIC_LOTELINDEROVIADET)
        {
            BE.SIC_LOTELINDEROVIADET lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_LOTELINDEROVIADET().Recuperar(entSIC_LOTELINDEROVIADET);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (07/06/2018)
        //Utilizado por	: WebApi.SIC_LOTELINDEROVIADET.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_LOTELINDEROVIADET
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_LOTELINDEROVIADET entSIC_LOTELINDEROVIADET)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_LOTELINDEROVIADET().Eliminar(entSIC_LOTELINDEROVIADET);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO EliminarColindante(BE.SIC_LOTELINDEROVIADET entSIC_LOTELINDEROVIADET)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_LOTELINDEROVIADET().EliminarColindante(entSIC_LOTELINDEROVIADET);
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
