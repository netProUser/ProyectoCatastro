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
    public class SIC_UNIDADBIENCOMUN : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (03/09/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDADBIENCOMUN.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_UNIDADBIENCOMUN, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_UNIDADBIENCOMUN entSIC_UNIDADBIENCOMUN)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_UNIDADBIENCOM.PRC_INSERTAR_TMP");
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.Int32, entSIC_UNIDADBIENCOMUN.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODBIENCOMUN", DbType.Int32, entSIC_UNIDADBIENCOMUN.CODBIENCOMUN);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_UNIDADBIENCOMUN.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_UNIDADBIENCOMUN.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_UNIDADBIENCOMUN.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_UNIDADBIENCOMUN.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_UNIDADBIENCOMUN.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_UNIDADBIENCOMUN.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODEDIFICACION", DbType.String, entSIC_UNIDADBIENCOMUN.CODEDIFICACION);
            db.AddInParameter(dbCommand, "pvcCODENTRADA", DbType.String, entSIC_UNIDADBIENCOMUN.CODENTRADA);
            db.AddInParameter(dbCommand, "pvcCODPISO", DbType.String, entSIC_UNIDADBIENCOMUN.CODPISO);
            db.AddInParameter(dbCommand, "pvcCODUNIDAD", DbType.String, entSIC_UNIDADBIENCOMUN.CODUNIDAD);
            db.AddInParameter(dbCommand, "pvcNUMPOROFI", DbType.Decimal, entSIC_UNIDADBIENCOMUN.NUMPOROFI);
            db.AddInParameter(dbCommand, "pvcNUMPORCAL", DbType.Decimal, entSIC_UNIDADBIENCOMUN.NUMPORCAL);
            db.AddInParameter(dbCommand, "pvcNUMATECOM", DbType.Decimal, entSIC_UNIDADBIENCOMUN.NUMATECOM);
            db.AddInParameter(dbCommand, "pvcNUMACONCOM", DbType.Decimal, entSIC_UNIDADBIENCOMUN.NUMATECOM);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDADBIENCOMUN.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTTIPREG", DbType.String, entSIC_UNIDADBIENCOMUN.TXTTIPREG);
            db.AddOutParameter(dbCommand, "pvcCODCORRUNIDBC", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODCORRUNIDBC"));
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
        //Creado por	: AA (03/09/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDADBIENCOMUN.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_UNIDADBIENCOMUN
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_UNIDADBIENCOMUN entSIC_UNIDADBIENCOMUN)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_UNIDADBIENCOM.PRC_MODIFICAR_TMP");
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.Int32, entSIC_UNIDADBIENCOMUN.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODBIENCOMUN", DbType.Int32, entSIC_UNIDADBIENCOMUN.CODBIENCOMUN);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_UNIDADBIENCOMUN.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_UNIDADBIENCOMUN.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_UNIDADBIENCOMUN.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_UNIDADBIENCOMUN.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_UNIDADBIENCOMUN.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_UNIDADBIENCOMUN.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODEDIFICACION", DbType.String, entSIC_UNIDADBIENCOMUN.CODEDIFICACION);
            db.AddInParameter(dbCommand, "pvcCODENTRADA", DbType.String, entSIC_UNIDADBIENCOMUN.CODENTRADA);
            db.AddInParameter(dbCommand, "pvcCODPISO", DbType.String, entSIC_UNIDADBIENCOMUN.CODPISO);
            db.AddInParameter(dbCommand, "pvcCODUNIDAD", DbType.String, entSIC_UNIDADBIENCOMUN.CODUNIDAD);
            db.AddInParameter(dbCommand, "pvcNUMPOROFI", DbType.Decimal, entSIC_UNIDADBIENCOMUN.NUMPOROFI);
            db.AddInParameter(dbCommand, "pvcNUMPORCAL", DbType.Decimal, entSIC_UNIDADBIENCOMUN.NUMPORCAL);
            db.AddInParameter(dbCommand, "pvcNUMATECOM", DbType.Decimal, entSIC_UNIDADBIENCOMUN.NUMATECOM);
            db.AddInParameter(dbCommand, "pvcNUMACONCOM", DbType.Decimal, entSIC_UNIDADBIENCOMUN.NUMATECOM);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDADBIENCOMUN.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTTIPREG", DbType.String, entSIC_UNIDADBIENCOMUN.TXTTIPREG);
            db.AddInParameter(dbCommand, "pvcCODCORRUNIDBC", DbType.String, entSIC_UNIDADBIENCOMUN.CODCORRUNIDBC);
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
        //Creado por	: AA (03/09/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDADBIENCOMUN.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_UNIDADBIENCOMUN
        /// </summary>
        public BE.SIC_UNIDADBIENCOMUN Recuperar(BE.SIC_UNIDADBIENCOMUN entSIC_UNIDADBIENCOMUN)
        {
            BE.SIC_UNIDADBIENCOMUN lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_UNIDADBIENCOM.PRC_DATOS_TMP", new object[3]);
            db.SetParameterValue(dbCommand, "pvcCODBIENCOMUN", entSIC_UNIDADBIENCOMUN.CODBIENCOMUN);
            db.SetParameterValue(dbCommand, "pvcCODCORRUNIDBC", entSIC_UNIDADBIENCOMUN.CODCORRUNIDBC);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_UNIDADBIENCOMUN(reader, BE.SIC_UNIDADBIENCOMUN.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (03/09/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDADBIENCOMUN.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_UNIDADBIENCOMUN
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_UNIDADBIENCOMUN entSIC_UNIDADBIENCOMUN)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_UNIDADBIENCOM.PRC_ELIMINAR_TMP");
            db.AddInParameter(dbCommand, "pvcCODBIENCOMUN", DbType.Int32, entSIC_UNIDADBIENCOMUN.CODBIENCOMUN);
            db.AddInParameter(dbCommand, "pvcCODCORRUNIDBC", DbType.String, entSIC_UNIDADBIENCOMUN.CODCORRUNIDBC);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDADBIENCOMUN.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTTIPREG", DbType.String, entSIC_UNIDADBIENCOMUN.TXTTIPREG);
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
        //Creado por	: AA (03/09/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDADBIENCOMUN.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los registros de la tabla SIC_UNIDADBIENCOMUN
        /// </summary>
        public IEnumerable<BE.SIC_UNIDADBIENCOMUN> Listar(BE.SIC_UNIDADBIENCOMUN entSIC_UNIDADBIENCOMUN)
        {
            List<BE.SIC_UNIDADBIENCOMUN> lista = new List<BE.SIC_UNIDADBIENCOMUN>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_UNIDADBIENCOM.PRC_LISTAR_TMP", new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODBIENCOMUN", entSIC_UNIDADBIENCOMUN.CODBIENCOMUN);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_UNIDADBIENCOMUN(reader, BE.SIC_UNIDADBIENCOMUN.Query.Listar));
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
