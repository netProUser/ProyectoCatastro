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
    public class SIC_CONSULTAHST : Base
    {
        public IEnumerable<BE.SIC_CONSULTAHST> Buscar(BE.SIC_CONSULTAHST entSIC_CONSULTAHST)
        {
            List<BE.SIC_CONSULTAHST> lista = new List<BE.SIC_CONSULTAHST>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_CONSULTAGEN.PRC_DATOSCONSULTAHST", new object[14]);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_CONSULTAHST.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_CONSULTAHST.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_CONSULTAHST.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_CONSULTAHST.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCODEDIFICACION", entSIC_CONSULTAHST.CODEDIFICACION);
            db.SetParameterValue(dbCommand, "pvcCODENTRADA", entSIC_CONSULTAHST.CODENTRADA);
            db.SetParameterValue(dbCommand, "pvcCODPISO", entSIC_CONSULTAHST.CODPISO);
            db.SetParameterValue(dbCommand, "pvcCODUNIDAD", entSIC_CONSULTAHST.CODUNIDAD);
            db.SetParameterValue(dbCommand, "pvcCODTIPODOC", entSIC_CONSULTAHST.CODTIPODOC);
            db.SetParameterValue(dbCommand, "pvcFECHAINI", entSIC_CONSULTAHST.FECHAINI);
            db.SetParameterValue(dbCommand, "pvcFECHAFIN", entSIC_CONSULTAHST.FECHAFIN);
            db.SetParameterValue(dbCommand, "pinNUMPAG", entSIC_CONSULTAHST.PAGINANUMERO);
            db.SetParameterValue(dbCommand, "pinNUMREG", entSIC_CONSULTAHST.PAGINAREGISTROS);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_CONSULTAHST(reader, BE.SIC_CONSULTAHST.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }

        public BE.SIC_CONSULTAHST BuscarInt(BE.SIC_CONSULTAHST entSIC_CONSULTAHST)
        {
            BE.SIC_CONSULTAHST lista = new BE.SIC_CONSULTAHST();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_CONSULTAGEN.PRC_DATOSCONSULTAHST_INT");
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_CONSULTAHST.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_CONSULTAHST.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_CONSULTAHST.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_CONSULTAHST.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODEDIFICACION", DbType.String, entSIC_CONSULTAHST.CODEDIFICACION);
            db.AddInParameter(dbCommand, "pvcCODENTRADA", DbType.String, entSIC_CONSULTAHST.CODENTRADA);
            db.AddInParameter(dbCommand, "pvcCODPISO", DbType.String, entSIC_CONSULTAHST.CODPISO);
            db.AddInParameter(dbCommand, "pvcCODUNIDAD", DbType.String, entSIC_CONSULTAHST.CODUNIDAD);
            db.AddInParameter(dbCommand, "pvcCODTIPODOC", DbType.String, entSIC_CONSULTAHST.CODTIPODOC);
            db.AddInParameter(dbCommand, "pvcFECHAINI", DbType.Date, entSIC_CONSULTAHST.FECHAINI);
            db.AddInParameter(dbCommand, "pvcFECHAFIN", DbType.Date, entSIC_CONSULTAHST.FECHAFIN);
            db.AddInParameter(dbCommand, "pinNUMREG", DbType.Int32, entSIC_CONSULTAHST.PAGINAREGISTROS);
            db.AddOutParameter(dbCommand, "pinTOTPAG", DbType.Int32, 0);
            db.AddOutParameter(dbCommand, "pinTOTREG", DbType.Int32, 0);

            try
            {
                db.ExecuteNonQuery(dbCommand);
                lista.TOTALPAGINAS = Convert.ToInt32(db.GetParameterValue(dbCommand, "pinTOTPAG"));
                lista.TOTALREGISTROS = Convert.ToInt32(db.GetParameterValue(dbCommand, "pinTOTREG"));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }

        public BE.SIC_SOLUNIDAD obtenerReferen(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            BE.SIC_SOLUNIDAD lista = new BE.SIC_SOLUNIDAD();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_CONSULTAGEN.PRC_DATOSUNIDREFEREN", new object[10]);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_SOLUNIDAD.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_SOLUNIDAD.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_SOLUNIDAD.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_SOLUNIDAD.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCODEDIFICACION", entSIC_SOLUNIDAD.CODEDIFICACION);
            db.SetParameterValue(dbCommand, "pvcCODENTRADA", entSIC_SOLUNIDAD.CODENTRADA);
            db.SetParameterValue(dbCommand, "pvcCODPISO", entSIC_SOLUNIDAD.CODPISO);
            db.SetParameterValue(dbCommand, "pvcCODUNIDAD", entSIC_SOLUNIDAD.CODUNIDAD);
            db.SetParameterValue(dbCommand, "pvcCODTIPODOC", entSIC_SOLUNIDAD.CTIPODOCUMENTO);//NUEVO
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_SOLUNIDAD(reader, BE.SIC_SOLUNIDAD.Query.BuscarReferen);
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
