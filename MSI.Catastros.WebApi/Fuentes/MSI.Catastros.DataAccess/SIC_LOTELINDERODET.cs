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
    public class SIC_LOTELINDERODET : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (07/06/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTELINDERODET.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_LOTELINDERODET, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_LOTELINDERODET entSIC_LOTELINDERODET)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTELINDERODET.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTELINDERODET.PRC_INSERTAR" : ".PKG_MSISIC_PROC_LOTELINDERODET.PRC_INSERTAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTELINDERODET.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTELINDERODET.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTELINDERODET.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTELINDERODET.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTELINDERODET.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTELINDERODET.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODLADO", DbType.String, entSIC_LOTELINDERODET.CODLADO);
            db.AddInParameter(dbCommand, "pvcCODCORRLADO", DbType.String, entSIC_LOTELINDERODET.CODCORRLADO);
            db.AddInParameter(dbCommand, "pvcCODSECTCOLI", DbType.String, entSIC_LOTELINDERODET.CODSECTCOLI);
            db.AddInParameter(dbCommand, "pvcCODMANZCOLI", DbType.String, entSIC_LOTELINDERODET.CODMANZCOLI);
            db.AddInParameter(dbCommand, "pvcCODLOTECOLI", DbType.String, entSIC_LOTELINDERODET.CODLOTECOLI);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTELINDERODET.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = "0"; // (string)(db.GetParameterValue(dbCommand, "pvcCODCORRLADO"));
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
        //Creado por	: Jaime Díaz Espinoza (07/06/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTELINDERODET.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_LOTELINDERODET
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_LOTELINDERODET entSIC_LOTELINDERODET)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTELINDERODET.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTELINDERODET.PRC_MODIFICAR" : ".PKG_MSISIC_PROC_LOTELINDERODET.PRC_MODIFICAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTELINDERODET.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTELINDERODET.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTELINDERODET.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTELINDERODET.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTELINDERODET.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTELINDERODET.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODLADO", DbType.String, entSIC_LOTELINDERODET.CODLADO);
            db.AddInParameter(dbCommand, "pvcCODCORRLADO", DbType.String, entSIC_LOTELINDERODET.CODCORRLADO);
            db.AddInParameter(dbCommand, "pvcCODSECTCOLI", DbType.String, entSIC_LOTELINDERODET.CODSECTCOLI);
            db.AddInParameter(dbCommand, "pvcCODMANZCOLI", DbType.String, entSIC_LOTELINDERODET.CODMANZCOLI);
            db.AddInParameter(dbCommand, "pvcCODLOTECOLI", DbType.String, entSIC_LOTELINDERODET.CODLOTECOLI);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTELINDERODET.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
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
        //Creado por	: Jaime Díaz Espinoza (07/06/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTELINDERODET.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_LOTELINDERODET
        /// </summary>
        public BE.SIC_LOTELINDERODET Recuperar(BE.SIC_LOTELINDERODET entSIC_LOTELINDERODET)
        {
            BE.SIC_LOTELINDERODET lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTELINDERODET.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTELINDERODET.PRC_DATOS" : ".PKG_MSISIC_PROC_LOTELINDERODET.PRC_DATOS_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[10]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_LOTELINDERODET.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_LOTELINDERODET.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_LOTELINDERODET.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_LOTELINDERODET.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_LOTELINDERODET.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_LOTELINDERODET.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCODLADO", entSIC_LOTELINDERODET.CODLADO);
            db.SetParameterValue(dbCommand, "pvcCODCORRLADO", entSIC_LOTELINDERODET.CODCORRLADO);
            db.SetParameterValue(dbCommand, "pvcCODLOTECOLI", entSIC_LOTELINDERODET.CODLOTECOLI);
            
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_LOTELINDERODET(reader, BE.SIC_LOTELINDERODET.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (07/06/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTELINDERODET.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_LOTELINDERODET
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_LOTELINDERODET entSIC_LOTELINDERODET)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTELINDERODET.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTELINDERODET.PRC_ELIMINAR" : ".PKG_MSISIC_PROC_LOTELINDERODET.PRC_ELIMINAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTELINDERODET.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTELINDERODET.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTELINDERODET.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTELINDERODET.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTELINDERODET.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTELINDERODET.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODLADO", DbType.String, entSIC_LOTELINDERODET.CODLADO);
            db.AddInParameter(dbCommand, "pvcCODCORRLADO", DbType.String, entSIC_LOTELINDERODET.CODCORRLADO);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTELINDERODET.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
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
        
        
    }
}
