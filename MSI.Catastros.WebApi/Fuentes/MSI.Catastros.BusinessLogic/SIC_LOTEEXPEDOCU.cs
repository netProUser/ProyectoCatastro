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
    public class SIC_LOTEEXPEDOCU
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (07/06/2018)
        //Utilizado por	: WebApi.SIC_LOTEEXPEDOCU.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_LOTEEXPEDOCU, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_LOTEEXPEDOCU entSIC_LOTEEXPEDOCU)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_LOTEEXPEDOCU().Grabar(entSIC_LOTEEXPEDOCU);
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
        //Utilizado por	: WebApi.SIC_LOTEEXPEDOCU.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_LOTEEXPEDOCU
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_LOTEEXPEDOCU entSIC_LOTEEXPEDOCU)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_LOTEEXPEDOCU().Actualizar(entSIC_LOTEEXPEDOCU);
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
        //Utilizado por	: WebApi.SIC_LOTEEXPEDOCU.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_LOTEEXPEDOCU
        /// </summary>
        public BE.SIC_LOTEEXPEDOCU Recuperar(BE.SIC_LOTEEXPEDOCU entSIC_LOTEEXPEDOCU)
        {
            BE.SIC_LOTEEXPEDOCU lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_LOTEEXPEDOCU().Recuperar(entSIC_LOTEEXPEDOCU);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (07/06/2018)
        //Utilizado por	: WebApi.SIC_LOTEEXPEDOCU.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_LOTEEXPEDOCU
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_LOTEEXPEDOCU entSIC_LOTEEXPEDOCU)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_LOTEEXPEDOCU().Eliminar(entSIC_LOTEEXPEDOCU);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (26/06/2018)
        //Utilizado por	: WebApi.SIC_LOTEEXPEDOCU.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_LOTEEXPEDOCU
        /// </summary>
        public ICollection<BE.SIC_LOTEEXPEDOCU> Buscar(BE.SIC_LOTEEXPEDOCU entSIC_LOTEEXPEDOCU)
        {
            List<BE.SIC_LOTEEXPEDOCU> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_LOTEEXPEDOCU> entQuery = new DA.SIC_LOTEEXPEDOCU().Buscar(entSIC_LOTEEXPEDOCU);
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
        public ICollection<BE.SIC_LOTEEXPEDOCU> DocumentosLote(BE.SIC_LOTEEXPEDOCU entSIC_SOLICITUD)
        {
            List<BE.SIC_LOTEEXPEDOCU> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_LOTEEXPEDOCU> entQuery = new DA.SIC_LOTEEXPEDOCU().DocumentosLote(entSIC_SOLICITUD);
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
        public BE.SIC_RETORNO AgregarDocumentos(BE.SIC_LOTEEXPEDOCU entSIC_LOTELINDEROVIADET)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_LOTEEXPEDOCU().AgregarDocumentos(entSIC_LOTELINDEROVIADET);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO EliminarDocumentos(BE.SIC_LOTEEXPEDOCU entSIC_LOTELINDEROVIADET)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_LOTEEXPEDOCU().EliminarDocumentos(entSIC_LOTELINDEROVIADET);
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
