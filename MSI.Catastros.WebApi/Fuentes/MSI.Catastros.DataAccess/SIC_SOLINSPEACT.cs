using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE = MSI.Catastros.BusinessEntities;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace MSI.Catastros.DataAccess
{
    public class SIC_SOLINSPEACT : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (31/05/2018)
        //Utilizado por	: BusinessLogic.SIC_SOLINSPEACT.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_SOLINSPEACT, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_SOLINSPEACT entSIC_SOLINSPEACT)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_SOLINSPEACT.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcCODANOSOLI", DbType.String, entSIC_SOLINSPEACT.CODANOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNUMESOLI", DbType.String, entSIC_SOLINSPEACT.CODNUMESOLI);
            db.AddInParameter(dbCommand, "pvcCODTIPOSOLI", DbType.String, entSIC_SOLINSPEACT.CODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcCODCORRSEG", DbType.String, entSIC_SOLINSPEACT.CODCORRSEG);
            db.AddInParameter(dbCommand, "pvcCODINDDET", DbType.String, entSIC_SOLINSPEACT.CODINDDET);
            db.AddInParameter(dbCommand, "pvcCODTIPOINSP", DbType.String, entSIC_SOLINSPEACT.CODTIPOINSP);
            db.AddInParameter(dbCommand, "pvcTXTDETALLE", DbType.String, entSIC_SOLINSPEACT.TXTDETALLE);
            db.AddInParameter(dbCommand, "pvcFECPROGRAMA", DbType.Date, entSIC_SOLINSPEACT.FECPROGRAMA);
            db.AddInParameter(dbCommand, "pvcTXTDETTIPINS", DbType.String, entSIC_SOLINSPEACT.TXTDETTIPINS);
            db.AddInParameter(dbCommand, "pvcCODTIPINSP", DbType.String, entSIC_SOLINSPEACT.CODTIPINSP);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_SOLINSPEACT.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_SOLINSPEACT.TXTIPREG);
            db.AddInParameter(dbCommand, "pvcCTIPODOCUMENTO", DbType.String, entSIC_SOLINSPEACT.CTIPODOCUMENTO);
            db.AddOutParameter(dbCommand, "pvcCODCORRCOD", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODCORRCOD"));
                entSIC_RETORNO.NoMENSAJE = Convert.ToInt32(db.GetParameterValue(dbCommand, "pvcNROMENSAJE"));
                entSIC_RETORNO.Ok = ((int)entSIC_RETORNO.NoMENSAJE == 0);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (31/05/2018)
        //Utilizado por	: BusinessLogic.SIC_SOLINSPEACT.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_SOLINSPEACT, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_SOLINSPEACT entSIC_SOLINSPEACT)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_SOLINSPEACT.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODANOSOLI", DbType.String, entSIC_SOLINSPEACT.CODANOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNUMESOLI", DbType.String, entSIC_SOLINSPEACT.CODNUMESOLI);
            db.AddInParameter(dbCommand, "pvcCODTIPOSOLI", DbType.String, entSIC_SOLINSPEACT.CODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcCODCORRSEG", DbType.String, entSIC_SOLINSPEACT.CODCORRSEG);
            db.AddInParameter(dbCommand, "pvcCODINDDET", DbType.String, entSIC_SOLINSPEACT.CODINDDET);
            db.AddInParameter(dbCommand, "pvcCODTIPOINSP", DbType.String, entSIC_SOLINSPEACT.CODTIPOINSP);
            db.AddInParameter(dbCommand, "pvcTXTDETALLE", DbType.String, entSIC_SOLINSPEACT.TXTDETALLE);
            db.AddInParameter(dbCommand, "pvcFECPROGRAMA", DbType.Date, entSIC_SOLINSPEACT.FECPROGRAMA);
            db.AddInParameter(dbCommand, "pvcTXTDETTIPINS", DbType.String, entSIC_SOLINSPEACT.TXTDETTIPINS);
            db.AddInParameter(dbCommand, "pvcCODTIPINSP", DbType.String, entSIC_SOLINSPEACT.CODTIPINSP);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_SOLINSPEACT.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_SOLINSPEACT.TXTIPREG);
            db.AddInParameter(dbCommand, "pvcCODCORRCOD", DbType.String, entSIC_SOLINSPEACT.CODCORRCOD);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.NoMENSAJE = Convert.ToInt32(db.GetParameterValue(dbCommand, "pvcNROMENSAJE"));
                entSIC_RETORNO.Ok = ((int)entSIC_RETORNO.NoMENSAJE == 0);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (31/05/2018)
        //Utilizado por	: BusinessLogic.SIC_SOLINSPEACT.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_SOLINSPEACT
        /// </summary>
        public BE.SIC_SOLINSPEACT Recuperar(BE.SIC_SOLINSPEACT entSIC_SOLINSPEACT)
        {
            BE.SIC_SOLINSPEACT lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_SOLINSPEACT.PRC_DATOS", new object[7]);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_SOLINSPEACT.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_SOLINSPEACT.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_SOLINSPEACT.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODCORRSEG", entSIC_SOLINSPEACT.CODCORRSEG);
            db.SetParameterValue(dbCommand, "pvcCODCORRCOD", entSIC_SOLINSPEACT.CODCORRCOD);
            db.SetParameterValue(dbCommand, "pvcCODINDDET", entSIC_SOLINSPEACT.CODINDDET);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_SOLINSPEACT(reader, BE.SIC_SOLINSPEACT.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
    }
}
