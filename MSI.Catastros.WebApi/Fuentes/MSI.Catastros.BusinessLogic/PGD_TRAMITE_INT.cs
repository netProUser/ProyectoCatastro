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
    public class PGD_TRAMITE_INT
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (05/06/2018)
        //Utilizado por	: WebApi.PGD_TRAMITE_INT.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla CD_DOC_OFICINA01, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.PGD_TRAMITE_INT entPGD_TRAMITE_INT)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.PGD_TRAMITE_INT().Grabar(entPGD_TRAMITE_INT);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (13/06/2018)
        //Utilizado por	: WebApi.PGD_TRAMITE_INT.Consulta
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla PGD_TRAMITE_INT
        /// </summary>
        public BE.PGD_TRAMITE_INT Consulta(BE.PGD_TRAMITE_INT entPGD_TRAMITE_INT)
        {
            BE.PGD_TRAMITE_INT lisQuery = null;
            try
            {
                lisQuery = new DA.PGD_TRAMITE_INT().Consulta(entPGD_TRAMITE_INT);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }

        public BE.SIC_RETORNO ObtenerDocumento(BE.PGD_TRAMITE_INT entPGD_TRAMITE_INT)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.PGD_TRAMITE_INT().ObtenerDocInterno(entPGD_TRAMITE_INT);
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
