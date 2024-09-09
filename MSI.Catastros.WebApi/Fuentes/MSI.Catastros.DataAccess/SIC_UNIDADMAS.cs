using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BE = MSI.Catastros.BusinessEntities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace MSI.Catastros.DataAccess
{
    public class SIC_UNIDADMAS : Base
    {

        public BE.SIC_RETORNO Grabar(BE.SIC_UNIDADMAS entSIC_UNIDADMAS)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_UNIDADMAS.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcCODANOSOLI", DbType.Int32, entSIC_UNIDADMAS.CODANOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNUMESOLI", DbType.String, entSIC_UNIDADMAS.CODNUMESOLI);
            db.AddInParameter(dbCommand, "pvcCODTIPOSOLI", DbType.String, entSIC_UNIDADMAS.CODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcCORRELUNIDAD", DbType.String, entSIC_UNIDADMAS.CORRELUNIDAD);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.String, entSIC_UNIDADMAS.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_UNIDADMAS.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_UNIDADMAS.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_UNIDADMAS.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_UNIDADMAS.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_UNIDADMAS.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_UNIDADMAS.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODEDIFICACION", DbType.String, entSIC_UNIDADMAS.CODEDIFICACION);
            db.AddInParameter(dbCommand, "pvcCODENTRADA", DbType.String, entSIC_UNIDADMAS.CODENTRADA);
            db.AddInParameter(dbCommand, "pvcCODPISO", DbType.String, entSIC_UNIDADMAS.CODPISO);
            db.AddInParameter(dbCommand, "pvcNROUNIDADES", DbType.String, entSIC_UNIDADMAS.NROUNIDADES);
            db.AddInParameter(dbCommand, "pvcCODTIPONINTE", DbType.String, entSIC_UNIDADMAS.CODTIPONINTE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDADMAS.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_UNIDADMAS.TXTIPREG);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = "0"; // (string)(db.GetParameterValue(dbCommand, "pvcCODCORRUNIDINSP"));
                entSIC_RETORNO.NoMENSAJE = Convert.ToInt32(db.GetParameterValue(dbCommand, "pvcNROMENSAJE"));
                entSIC_RETORNO.Ok = ((int)entSIC_RETORNO.NoMENSAJE == 0);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return entSIC_RETORNO;
        }

        public IEnumerable<BE.SIC_UNIDADMAS> Buscar(BE.SIC_UNIDADMAS entSIC_UNIDADMAS)
        {
            List<BE.SIC_UNIDADMAS> lista = new List<BE.SIC_UNIDADMAS>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_UNIDADMAS.PRC_BUSCAR", new object[9]);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_UNIDADMAS.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_UNIDADMAS.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_UNIDADMAS.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCORRELUNIDAD", entSIC_UNIDADMAS.CORRELUNIDAD);
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDADMAS.CODUNI);
            db.SetParameterValue(dbCommand, "pvcORDEN", entSIC_UNIDADMAS.ORDEN);
            db.SetParameterValue(dbCommand, "pinNUMPAG", entSIC_UNIDADMAS.PAGINANUMERO);
            db.SetParameterValue(dbCommand, "pinNUMREG", entSIC_UNIDADMAS.PAGINAREGISTROS);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_UNIDADMAS(reader, BE.SIC_UNIDADMAS.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public DataTable Excel(BE.SIC_UNIDADMAS entSIC_UNIDADMAS)
        {
            DataTable dt = new DataTable();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_UNIDADMAS.PRC_REPORTE", new object[9]);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_UNIDADMAS.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_UNIDADMAS.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_UNIDADMAS.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCORRELUNIDAD", entSIC_UNIDADMAS.CORRELUNIDAD);
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDADMAS.CODUNI);
            db.SetParameterValue(dbCommand, "pvcORDEN", entSIC_UNIDADMAS.ORDEN);
            db.SetParameterValue(dbCommand, "pinNUMPAG", entSIC_UNIDADMAS.PAGINANUMERO);
            db.SetParameterValue(dbCommand, "pinNUMREG", entSIC_UNIDADMAS.PAGINAREGISTROS);
            try
            {
                dt = db.ExecuteDataSet(dbCommand).Tables[0];
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return dt;
        }
    }
}
