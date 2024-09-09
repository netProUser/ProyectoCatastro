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
    public class SIC_LOTEOTRODOC : Base
    {
        public BE.SIC_RETORNO EliminarOtrosDocumentos(BE.SIC_LOTEOTRODOC entSIC_LOTELINDEROVIADET)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTELINDEROVIADET.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEDOCADI.PRC_ELIMINAR" : ".PKG_MSISIC_PROC_LOTEDOCADI.PRC_ELIMINAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTELINDEROVIADET.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTELINDEROVIADET.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTELINDEROVIADET.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTELINDEROVIADET.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCORRELATIVO", DbType.String, entSIC_LOTELINDEROVIADET.CORRELATIVO);
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
        public BE.SIC_LOTEOTRODOC DescargarOtrosDocumento(BE.SIC_LOTEOTRODOC entSIC_LOTERRPP)
        {
            BE.SIC_LOTEOTRODOC lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTERRPP.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEDOCADI.PRC_PDFOTROSDOC" : ".PKG_MSISIC_PROC_LOTEDOCADI.PRC_PDFOTROSDOC_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[6]);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_LOTERRPP.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_LOTERRPP.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_LOTERRPP.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_LOTERRPP.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCORRELATIVO", entSIC_LOTERRPP.CORRELATIVO);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_LOTEOTRODOC(reader, BE.SIC_LOTEOTRODOC.Query.ListarOtrosDocumentos);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        public IEnumerable<BE.SIC_LOTEOTRODOC> ListarTipoOtrosDocumentos()
        {
            List<BE.SIC_LOTEOTRODOC> lista = new List<BE.SIC_LOTEOTRODOC>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_LOTEDOCADI.PRC_LISTARTIPOOTRODOC", new object[1]);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_LOTEOTRODOC(reader, BE.SIC_LOTEOTRODOC.Query.ListarTipoOtrosDocumentos));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public BE.SIC_RETORNO ActualizarOtrosDocumentos(BE.SIC_LOTEOTRODOC entSIC_LOTELINDERO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTELINDERO.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEDOCADI.PRC_MODIFICAR_OTROSDOC" : ".PKG_MSISIC_PROC_LOTEDOCADI.PRC_MODIFICAR_OTROSDOC_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTELINDERO.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTELINDERO.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTELINDERO.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTELINDERO.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODDOCUMENTO", DbType.String, entSIC_LOTELINDERO.CODDOCUMENTO);
            db.AddInParameter(dbCommand, "pvcTXTNRODOCUMENTO", DbType.String, entSIC_LOTELINDERO.TXTNRODOCUMENTO);
            db.AddInParameter(dbCommand, "pvcFECDOCUMENTO", DbType.DateTime, entSIC_LOTELINDERO.FECDOCUMENTO);
            db.AddInParameter(dbCommand, "pvcTXTOBSERVACION", DbType.String, entSIC_LOTELINDERO.TXTOBSERVACION);
            db.AddInParameter(dbCommand, "pvcCORRELATIVO", DbType.String, entSIC_LOTELINDERO.CORRELATIVO);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTELINDERO.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
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

        public BE.SIC_RETORNO ActualizarPDFOtrosDocumentos(BE.SIC_LOTEOTRODOC entSIC_LOTELINDERO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTELINDERO.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEDOCADI.PRC_MODIFICAR_PDFOTROSDOC" : ".PKG_MSISIC_PROC_LOTEDOCADI.PRC_MODIFICAR_PDFOTROSDOC_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTELINDERO.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTELINDERO.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTELINDERO.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTELINDERO.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCORRELATIVO", DbType.String, entSIC_LOTELINDERO.CORRELATIVO);
            db.AddInParameter(dbCommand, "pvcTXTPDF", DbType.String, entSIC_LOTELINDERO.TXTPDF);
            db.AddInParameter(dbCommand, "pvcTXTRUTAPDF", DbType.String, entSIC_LOTELINDERO.TXTRUTAPDF);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTELINDERO.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
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
        public BE.SIC_RETORNO GrabarOtrosDocumentos(BE.SIC_LOTEOTRODOC entSIC_LOTELINDERO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTELINDERO.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEDOCADI.PRC_INSERTAR_OTROSDOC" : ".PKG_MSISIC_PROC_LOTEDOCADI.PRC_INSERTAR_OTROSDOC_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTELINDERO.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTELINDERO.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTELINDERO.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTELINDERO.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODDOCUMENTO", DbType.String, entSIC_LOTELINDERO.CODDOCUMENTO);
            db.AddInParameter(dbCommand, "pvcTXTNRODOCUMENTO", DbType.String, entSIC_LOTELINDERO.TXTNRODOCUMENTO);
            db.AddInParameter(dbCommand, "pvcFECDOCUMENTO", DbType.DateTime, entSIC_LOTELINDERO.FECDOCUMENTO);
            db.AddInParameter(dbCommand, "pvcTXTOBSERVACION", DbType.String, entSIC_LOTELINDERO.TXTOBSERVACION);
            db.AddInParameter(dbCommand, "pvcCORRELATIVO", DbType.String, entSIC_LOTELINDERO.CORRELATIVO);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTELINDERO.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
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
        public BE.SIC_LOTEOTRODOC BuscarCantidadRegistros(BE.SIC_LOTEOTRODOC entSIC_EDIFICACION)
        {
            BE.SIC_LOTEOTRODOC lista = new BE.SIC_LOTEOTRODOC();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_LOTEDOCADI.PRC_BUSCAR_CANTREG");
            db.AddInParameter(dbCommand, "pvcCODDOCUMENTO", DbType.String, entSIC_EDIFICACION.CODDOCUMENTO);
            db.AddInParameter(dbCommand, "pvcTXTDOCUMENTO", DbType.String, entSIC_EDIFICACION.TXTDOCUMENTO);
            db.AddInParameter(dbCommand, "pinNUMREG", DbType.Int32, entSIC_EDIFICACION.PAGINAREGISTROS);
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
        public IEnumerable<BE.SIC_LOTEOTRODOC> BuscarOtrosDocumentos(BE.SIC_LOTEOTRODOC entSIC_EDIFICACION)
        {
            List<BE.SIC_LOTEOTRODOC> lista = new List<BE.SIC_LOTEOTRODOC>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_LOTEDOCADI.PRC_BUSCAR_OTRODOC", new object[6]);
            db.SetParameterValue(dbCommand, "pvcCODDOCUMENTO", entSIC_EDIFICACION.CODDOCUMENTO);
            db.SetParameterValue(dbCommand, "pvcTXTDOCUMENTO",  entSIC_EDIFICACION.TXTDOCUMENTO);
            db.SetParameterValue(dbCommand, "pvcORDEN", entSIC_EDIFICACION.ORDEN);
            db.SetParameterValue(dbCommand, "pinNUMPAG", entSIC_EDIFICACION.PAGINANUMERO);
            db.SetParameterValue(dbCommand, "pinNUMREG", entSIC_EDIFICACION.PAGINAREGISTROS);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_LOTEOTRODOC(reader, BE.SIC_LOTEOTRODOC.Query.ListarTipoOtrosDocumentos));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public BE.SIC_LOTEOTRODOC RecuperarOtroDocId(BE.SIC_LOTEOTRODOC entSIC_EDIFICACION)
        {
            BE.SIC_LOTEOTRODOC lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_LOTEDOCADI.PRC_BUSCAR_OTRODOC_ID", new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODDOCUMENTO", entSIC_EDIFICACION.CODDOCUMENTO);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_LOTEOTRODOC(reader, BE.SIC_LOTEOTRODOC.Query.ListarTipoOtrosDocumentos);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        public BE.SIC_RETORNO GrabarTipoOtroDocumentos(BE.SIC_LOTEOTRODOC entSIC_EDIFICACION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_LOTEDOCADI.PRC_INSERTAR_TIPOTRODOC");
            db.AddInParameter(dbCommand, "pvcTXTDOCUMENTO", DbType.String, entSIC_EDIFICACION.TXTDOCUMENTO);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_EDIFICACION.CODUSUARIO);
            db.AddOutParameter(dbCommand, "pvcCODDOCUMENTO", DbType.String, 3);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODDOCUMENTO"));
                entSIC_RETORNO.NoMENSAJE = Convert.ToInt32(db.GetParameterValue(dbCommand, "pvcNROMENSAJE"));
                entSIC_RETORNO.Ok = ((int)entSIC_RETORNO.NoMENSAJE == 0);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO ActualizarTipoOtroDocumentos(BE.SIC_LOTEOTRODOC entSIC_EDIFICACION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_LOTEDOCADI.PRC_MODIFICAR_TIPOTRODOC");
            db.AddInParameter(dbCommand, "pvcCODDOCUMENTO", DbType.String, entSIC_EDIFICACION.CODDOCUMENTO);
            db.AddInParameter(dbCommand, "pvcTXTDOCUMENTO", DbType.String, entSIC_EDIFICACION.TXTDOCUMENTO);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_EDIFICACION.CODUSUARIO);
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
        public BE.SIC_RETORNO EliminarTipoOtroDocumentos(BE.SIC_LOTEOTRODOC entSIC_EDIFICACION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_LOTEDOCADI.PRC_ELIMINAR_TIPOTRODOC");
            db.AddInParameter(dbCommand, "pvcCODDOCUMENTO", DbType.String, entSIC_EDIFICACION.CODDOCUMENTO);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_EDIFICACION.CODUSUARIO);
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