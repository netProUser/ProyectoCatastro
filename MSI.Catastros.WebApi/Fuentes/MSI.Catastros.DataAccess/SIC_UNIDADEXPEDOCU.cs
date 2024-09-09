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
    public class SIC_UNIDADEXPEDOCU : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/04/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDADEXPEDOCU.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_UNIDADEXPEDOCU, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_UNIDADEXPEDOCU entSIC_UNIDADEXPEDOCU)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDADEXPEDOCU.ESTATICO == true) ? ".PKG_MSISIC_PROC_UNIDADEXPEDOCU.PRC_INSERTAR" : ".PKG_MSISIC_PROC_UNIDADEXPEDOCU.PRC_INSERTAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.String, entSIC_UNIDADEXPEDOCU.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODSOLICITANTE", DbType.String, entSIC_UNIDADEXPEDOCU.CODSOLICITANTE);
            db.AddInParameter(dbCommand, "pvcCODTIPODOCU", DbType.String, entSIC_UNIDADEXPEDOCU.CODTIPODOCU);
            db.AddInParameter(dbCommand, "pvcTXTNUMERO", DbType.String, entSIC_UNIDADEXPEDOCU.TXTNUMERO);
            db.AddInParameter(dbCommand, "pvcFECDOCUMENTO", DbType.Date, entSIC_UNIDADEXPEDOCU.FECDOCUMENTO);
            db.AddInParameter(dbCommand, "pvcTXTOBSERVACION", DbType.String, entSIC_UNIDADEXPEDOCU.TXTOBSERVACION);
            db.AddInParameter(dbCommand, "pvcTXTSOLICITANTE", DbType.String, entSIC_UNIDADEXPEDOCU.TXTSOLICITANTE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDADEXPEDOCU.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_UNIDADEXPEDOCU.TXTIPREG);
            db.AddInParameter(dbCommand, "pvcCODCORRLOTEEXPEDOCU", DbType.String, entSIC_UNIDADEXPEDOCU.CODCORRLOTEEXPEDOCU);
            db.AddOutParameter(dbCommand, "pvcCODCORRUNIDEXPEDOCU", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODCORRUNIDEXPEDOCU"));
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
        //Creado por	: Jaime Díaz Espinoza (22/04/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDADEXPEDOCU.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_UNIDADEXPEDOCU
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_UNIDADEXPEDOCU entSIC_UNIDADEXPEDOCU)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDADEXPEDOCU.ESTATICO == true) ? ".PKG_MSISIC_PROC_UNIDADEXPEDOCU.PRC_MODIFICAR" : ".PKG_MSISIC_PROC_UNIDADEXPEDOCU.PRC_MODIFICAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.String, entSIC_UNIDADEXPEDOCU.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODSOLICITANTE", DbType.String, entSIC_UNIDADEXPEDOCU.CODSOLICITANTE);
            db.AddInParameter(dbCommand, "pvcCODTIPODOCU", DbType.String, entSIC_UNIDADEXPEDOCU.CODTIPODOCU);
            db.AddInParameter(dbCommand, "pvcTXTNUMERO", DbType.String, entSIC_UNIDADEXPEDOCU.TXTNUMERO);
            db.AddInParameter(dbCommand, "pvcFECDOCUMENTO", DbType.Date, entSIC_UNIDADEXPEDOCU.FECDOCUMENTO);
            db.AddInParameter(dbCommand, "pvcTXTOBSERVACION", DbType.String, entSIC_UNIDADEXPEDOCU.TXTOBSERVACION);
            db.AddInParameter(dbCommand, "pvcTXTSOLICITANTE", DbType.String, entSIC_UNIDADEXPEDOCU.TXTSOLICITANTE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDADEXPEDOCU.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_UNIDADEXPEDOCU.TXTIPREG);
            db.AddInParameter(dbCommand, "pvcCODCORRAUTOLICE", DbType.String, entSIC_UNIDADEXPEDOCU.CODCORRUNIDEXPEDOCU);
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
        //Creado por	: Jaime Díaz Espinoza (22/06/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDADEXPEDOCU.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_UNIDADEXPEDOCU
        /// </summary>
        public BE.SIC_UNIDADEXPEDOCU Recuperar(BE.SIC_UNIDADEXPEDOCU entSIC_UNIDADEXPEDOCU)
        {
            BE.SIC_UNIDADEXPEDOCU lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDADEXPEDOCU.ESTATICO == true) ? ".PKG_MSISIC_PROC_UNIDADEXPEDOCU.PRC_DATOS" : ".PKG_MSISIC_PROC_UNIDADEXPEDOCU.PRC_DATOS_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[3]);
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDADEXPEDOCU.CODUNI);
            db.SetParameterValue(dbCommand, "pvcCODCORRAUTOLICE", entSIC_UNIDADEXPEDOCU.CODCORRUNIDEXPEDOCU);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_UNIDADEXPEDOCU(reader, BE.SIC_UNIDADEXPEDOCU.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/06/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDADEXPEDOCU.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_UNIDADEXPEDOCU
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_UNIDADEXPEDOCU entSIC_UNIDADEXPEDOCU)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDADEXPEDOCU.ESTATICO == true) ? ".PKG_MSISIC_PROC_UNIDADEXPEDOCU.PRC_ELIMINAR" : ".PKG_MSISIC_PROC_UNIDADEXPEDOCU.PRC_ELIMINAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.String, entSIC_UNIDADEXPEDOCU.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODCORRAUTOLICE", DbType.String, entSIC_UNIDADEXPEDOCU.CODCORRUNIDEXPEDOCU);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDADEXPEDOCU.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_UNIDADEXPEDOCU.TXTIPREG);
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

        public IEnumerable<BE.SIC_UNIDADEXPEDOCU> Listar(BE.SIC_UNIDADEXPEDOCU entSIC_UNIDADEXPEDOCU)
        {
            List<BE.SIC_UNIDADEXPEDOCU> lista = new List<BE.SIC_UNIDADEXPEDOCU>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDADEXPEDOCU.ESTATICO == true) ? ".PKG_MSISIC_PROC_UNIDADEXPEDOCU.PRC_LISTAR" : ".PKG_MSISIC_PROC_UNIDADEXPEDOCU.PRC_LISTAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[2]);  
           
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDADEXPEDOCU.CODUNI);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_UNIDADEXPEDOCU(reader, BE.SIC_UNIDADEXPEDOCU.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        
        public IEnumerable<BE.SIC_UNIDADEXPEDOCU> CargarUnidadExpedienteDocHistorica(BE.SIC_UNIDADEXPEDOCU entSIC_UNIDADEXPEDOCU)
        {
            List<BE.SIC_UNIDADEXPEDOCU> lista = new List<BE.SIC_UNIDADEXPEDOCU>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = ".PKG_MSISIC_HST_FNC.PRC_OBTENERDOCHISTORICO";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[3]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDADEXPEDOCU.CODUNI);
            db.SetParameterValue(dbCommand, "pvcNUMVERSION", entSIC_UNIDADEXPEDOCU.NUMVERSION);
            
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_UNIDADEXPEDOCU(reader, BE.SIC_UNIDADEXPEDOCU.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
    }
}
