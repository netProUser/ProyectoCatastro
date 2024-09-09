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
    public class SIC_LOTERRPP
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (11/06/2018)
        //Utilizado por	: WebApi.SIC_LOTERRPP.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_LOTERRPP, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_LOTERRPP entSIC_LOTERRPP)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_LOTERRPP().Grabar(entSIC_LOTERRPP);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (11/06/2018)
        //Utilizado por	: WebApi.SIC_LOTERRPP.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_LOTERRPP
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_LOTERRPP entSIC_LOTERRPP)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_LOTERRPP().Actualizar(entSIC_LOTERRPP);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (11/06/2018)
        //Utilizado por	: WebApi.SIC_LOTERRPP.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_LOTERRPP
        /// </summary>
        public BE.SIC_LOTERRPP Recuperar(BE.SIC_LOTERRPP entSIC_LOTERRPP)
        {
            BE.SIC_LOTERRPP lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_LOTERRPP().Recuperar(entSIC_LOTERRPP);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (11/06/2018)
        //Utilizado por	: WebApi.SIC_LOTERRPP.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_LOTERRPP
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_LOTERRPP entSIC_LOTERRPP)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_LOTERRPP().Eliminar(entSIC_LOTERRPP);
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
        //Utilizado por	: WebApi.SIC_LOTERRPP.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_LOTERRPP
        /// </summary>
        public ICollection<BE.SIC_LOTERRPP> Buscar(BE.SIC_LOTERRPP entSIC_LOTERRPP)
        {
            List<BE.SIC_LOTERRPP> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_LOTERRPP> entQuery = new DA.SIC_LOTERRPP().Buscar(entSIC_LOTERRPP);
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

        public ICollection<BE.SIC_LOTERRPP> CargarLoteOtrosDocumentos(BE.SIC_LOTERRPP entDDU_LICENCIA)
        {
            List<BE.SIC_LOTERRPP> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_LOTERRPP> entQuery = new DA.SIC_LOTERRPP().CargarLoteOtrosDocumentos(entDDU_LICENCIA);
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
