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
    public class SIC_UNIDADINFORME : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/04/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDADINFORME.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_UNIDADINFORME, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_UNIDADINFORME entSIC_UNIDADINFORME)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_UNIDADINFORME.PRC_INSERTAR_TMP");
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.String, entSIC_UNIDADINFORME.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODTIPODOCU", DbType.String, entSIC_UNIDADINFORME.CODTIPODOCU);
            db.AddInParameter(dbCommand, "pvcFECDOCUMENTO", DbType.Date, entSIC_UNIDADINFORME.FECDOCUMENTO);
            db.AddInParameter(dbCommand, "pvcCODRESPONSABLE", DbType.String, entSIC_UNIDADINFORME.CODRESPONSABLE);
            db.AddInParameter(dbCommand, "pvcTXTNUMEDOCU", DbType.String, entSIC_UNIDADINFORME.TXTNUMEDOCU);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDADINFORME.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_UNIDADINFORME.TXTIPREG);
            db.AddOutParameter(dbCommand, "pvcCODCORRUNIDINFO", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODCORRUNIDINFO"));
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
        //Utilizado por	: BusinessLogic.SIC_UNIDADINFORME.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_UNIDADINFORME
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_UNIDADINFORME entSIC_UNIDADINFORME)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_UNIDADINFORME.PRC_MODIFICAR_TMP");
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.String, entSIC_UNIDADINFORME.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODTIPODOCU", DbType.String, entSIC_UNIDADINFORME.CODTIPODOCU);
            db.AddInParameter(dbCommand, "pvcFECDOCUMENTO", DbType.Date, entSIC_UNIDADINFORME.FECDOCUMENTO);
            db.AddInParameter(dbCommand, "pvcCODRESPONSABLE", DbType.String, entSIC_UNIDADINFORME.CODRESPONSABLE);
            db.AddInParameter(dbCommand, "pvcTXTNUMEDOCU", DbType.String, entSIC_UNIDADINFORME.TXTNUMEDOCU);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDADINFORME.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_UNIDADINFORME.TXTIPREG);
            db.AddInParameter(dbCommand, "pvcCODCORRUNIDINFO", DbType.String, entSIC_UNIDADINFORME.CODCORRUNIDINFO);
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
        //Utilizado por	: BusinessLogic.SIC_UNIDADINFORME.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_UNIDADINFORME
        /// </summary>
        public BE.SIC_UNIDADINFORME Recuperar(BE.SIC_UNIDADINFORME entSIC_UNIDADINFORME)
        {
            BE.SIC_UNIDADINFORME lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_UNIDADINFORME.PRC_DATOS_TMP", new object[3]);
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDADINFORME.CODUNI);
            db.SetParameterValue(dbCommand, "pvcCODCORRUNIDINFO", entSIC_UNIDADINFORME.CODCORRUNIDINFO);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_UNIDADINFORME(reader, BE.SIC_UNIDADINFORME.Query.Recuperar);
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
        //Utilizado por	: BusinessLogic.SIC_UNIDADINFORME.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_UNIDADINFORME
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_UNIDADINFORME entSIC_UNIDADINFORME)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_UNIDADINFORME.PRC_ELIMINAR_TMP");
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.String, entSIC_UNIDADINFORME.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODCORRUNIDINFO", DbType.String, entSIC_UNIDADINFORME.CODCORRUNIDINFO);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDADINFORME.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_UNIDADINFORME.TXTIPREG);
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
