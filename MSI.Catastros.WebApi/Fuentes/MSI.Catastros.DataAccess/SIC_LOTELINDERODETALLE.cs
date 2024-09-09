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
    public class SIC_LOTELINDERODETALLE : Base
    {
        public IEnumerable<BE.SIC_LOTELINDEROVIADET> BuscarLinderosLote(BE.SIC_LOTELINDEROVIADET entSIC_LOTELINDEROVIADET)
        {
            List<BE.SIC_LOTELINDEROVIADET> lista = new List<BE.SIC_LOTELINDEROVIADET>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTELINDEROVIADET.ESTATICO == true) ? ".PKG_MSISIC_LOTELINDEROD.PRC_BUSCAR_LINDERO" : ".PKG_MSISIC_LOTELINDEROD.PRC_BUSCAR_LINDERO_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[9]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_LOTELINDEROVIADET.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_LOTELINDEROVIADET.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_LOTELINDEROVIADET.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_LOTELINDEROVIADET.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_LOTELINDEROVIADET.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_LOTELINDEROVIADET.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCODLADO", entSIC_LOTELINDEROVIADET.CODLADO);
            db.SetParameterValue(dbCommand, "pvcCODCORRLADO", entSIC_LOTELINDEROVIADET.CODCORRLADO);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_LOTELINDEROVIADET(reader, BE.SIC_LOTELINDEROVIADET.Query.ListarColindantes));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public BE.SIC_RETORNO GrabarLoteLinderoDetalle(BE.SIC_LOTELINDEROVIADET entSIC_LOTELINDEROVIADET)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTELINDEROVIADET.ESTATICO == true) ? ".PKG_MSISIC_LOTELINDEROD.PRC_INSERTAR_DETALLE" : ".PKG_MSISIC_LOTELINDEROD.PRC_INSERTAR_DETALLE_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTELINDEROVIADET.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTELINDEROVIADET.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTELINDEROVIADET.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTELINDEROVIADET.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTELINDEROVIADET.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTELINDEROVIADET.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODLADO", DbType.String, entSIC_LOTELINDEROVIADET.CODLADO);
            db.AddInParameter(dbCommand, "pvcCODCORRLADO", DbType.String, entSIC_LOTELINDEROVIADET.CODCORRLADO);
            db.AddInParameter(dbCommand, "pvcCODTIPOCOLI", DbType.String, entSIC_LOTELINDEROVIADET.CODTIPOCOLI);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_LOTELINDEROVIADET.CODVIA);
            db.AddInParameter(dbCommand, "pvcCODCORRMANZVIA", DbType.String, entSIC_LOTELINDEROVIADET.CODCORRMANZVIA);
            db.AddInParameter(dbCommand, "pvcCODSECTCOLI", DbType.String, entSIC_LOTELINDEROVIADET.CODSECTCOLI);
            db.AddInParameter(dbCommand, "pvcCODMANZCOLI", DbType.String, entSIC_LOTELINDEROVIADET.CODMANZCOLI);
            db.AddInParameter(dbCommand, "pvcCODLOTECOLI", DbType.String, entSIC_LOTELINDEROVIADET.CODLOTECOLI);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTELINDEROVIADET.CODUSUARIO);
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
        public BE.SIC_RETORNO EliminarDetalleLindero(BE.SIC_LOTELINDERODET entSIC_LOTELINDERODET)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTELINDERODET.ESTATICO == true) ? ".PKG_MSISIC_LOTELINDEROD.PRC_ELIMINAR_DETALLE" : ".PKG_MSISIC_LOTELINDEROD.PRC_ELIMINAR_DETALLE_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTELINDERODET.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTELINDERODET.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTELINDERODET.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTELINDERODET.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTELINDERODET.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTELINDERODET.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODLADO", DbType.String, entSIC_LOTELINDERODET.CODLADO);
            db.AddInParameter(dbCommand, "pvcCODCORRLADO", DbType.String, entSIC_LOTELINDERODET.CODCORRLADO);
            db.AddInParameter(dbCommand, "pvcCODTIPOCOLI", DbType.String, entSIC_LOTELINDERODET.CODTIPOCOLI);
            db.AddInParameter(dbCommand, "pvcCORRELATIVO", DbType.String, entSIC_LOTELINDERODET.CORRELATIVO);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_LOTELINDERODET.CODVIA);
            db.AddInParameter(dbCommand, "pvcCODCORMANZANA", DbType.String, entSIC_LOTELINDERODET.CODCORMANZANA);
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
        public BE.SIC_RETORNO GrabarColidante(BE.SIC_LOTELINDERO entSIC_LOTELINDERO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTELINDERO.ESTATICO == true) ? ".PKG_MSISIC_LOTELINDEROD.PRC_INSERTAR_LINDERO" : ".PKG_MSISIC_LOTELINDEROD.PRC_INSERTAR_LINDERO_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTELINDERO.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTELINDERO.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTELINDERO.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTELINDERO.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTELINDERO.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTELINDERO.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODLADO", DbType.String, entSIC_LOTELINDERO.CODLADO);
            db.AddInParameter(dbCommand, "pvcNUMMEDICAMP", DbType.Decimal, entSIC_LOTELINDERO.NUMMEDICAMP);
            db.AddInParameter(dbCommand, "pvcNUMMEDIOFIC", DbType.Decimal, entSIC_LOTELINDERO.NUMMEDIOFIC);
            db.AddInParameter(dbCommand, "pvcCODALTVIAFOR", DbType.String, entSIC_LOTELINDERO.CODALTVIAFOR);
            db.AddInParameter(dbCommand, "pvcCODFTELIN", DbType.String, entSIC_LOTELINDERO.CODFTELIN);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTELINDERO.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddOutParameter(dbCommand, "pvcCODCORRLADO", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODCORRLADO"));
                var asc = db.GetParameterValue(dbCommand, "pvcNROMENSAJE");
                entSIC_RETORNO.NoMENSAJE = Convert.ToInt32(db.GetParameterValue(dbCommand, "pvcNROMENSAJE"));
                entSIC_RETORNO.Ok = ((int)entSIC_RETORNO.NoMENSAJE == 0);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO ActualizarColidante(BE.SIC_LOTELINDERO entSIC_LOTELINDERO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTELINDERO.ESTATICO == true) ? ".PKG_MSISIC_LOTELINDEROD.PRC_MODIFICAR_LINDERO" : ".PKG_MSISIC_LOTELINDEROD.PRC_MODIFICAR_LINDERO_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTELINDERO.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTELINDERO.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTELINDERO.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTELINDERO.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTELINDERO.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTELINDERO.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODLADO", DbType.String, entSIC_LOTELINDERO.CODLADO);
            db.AddInParameter(dbCommand, "pvcNUMMEDICAMP", DbType.Decimal, entSIC_LOTELINDERO.NUMMEDICAMP);
            db.AddInParameter(dbCommand, "pvcNUMMEDIOFIC", DbType.Decimal, entSIC_LOTELINDERO.NUMMEDIOFIC);
            db.AddInParameter(dbCommand, "pvcCODALTVIAFOR", DbType.String, entSIC_LOTELINDERO.CODALTVIAFOR);
            db.AddInParameter(dbCommand, "pvcCODFTELIN", DbType.String, entSIC_LOTELINDERO.CODFTELIN);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTELINDERO.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddInParameter(dbCommand, "pvcCODCORRLADO", DbType.String, entSIC_LOTELINDERO.CODCORRLADO);
            db.AddOutParameter(dbCommand, "lvcCODCORRLADO", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "lvcCODCORRLADO"));
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
