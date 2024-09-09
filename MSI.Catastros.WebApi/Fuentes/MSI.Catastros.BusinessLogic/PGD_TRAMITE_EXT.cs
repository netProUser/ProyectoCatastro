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
    public class PGD_TRAMITE_EXT
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (05/06/2018)
        //Utilizado por	: WebApi.PGD_TRAMITE_EXT.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla CD_DOCTRAMITE2, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.PGD_TRAMITE_EXT entPGD_TRAMITE_EXT)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.PGD_TRAMITE_EXT().Grabar(entPGD_TRAMITE_EXT);
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
        //Utilizado por	: WebApi.PGD_TRAMITE_EXT.Consulta
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla PGD_TRAMITE_EXT
        /// </summary>
        public BE.PGD_TRAMITE_EXT Consulta(BE.PGD_TRAMITE_EXT entPGD_TRAMITE_EXT)
        {
            BE.PGD_TRAMITE_EXT lisQuery = null;
            try
            {
                lisQuery = new DA.PGD_TRAMITE_EXT().Consulta(entPGD_TRAMITE_EXT);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
    }
}
