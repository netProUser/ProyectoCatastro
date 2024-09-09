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
    public class SIC_LOTEEXPEDOCU : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (07/06/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTEEXPEDOCU.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_LOTEEXPEDOCU, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_LOTEEXPEDOCU entSIC_LOTEEXPEDOCU)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTEEXPEDOCU.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEEXPEDOCU.PRC_INSERTAR" : ".PKG_MSISIC_PROC_LOTEEXPEDOCU.PRC_INSERTAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTEEXPEDOCU.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTEEXPEDOCU.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTEEXPEDOCU.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTEEXPEDOCU.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTEEXPEDOCU.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTEEXPEDOCU.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODSOLICITANTE", DbType.String, entSIC_LOTEEXPEDOCU.CODSOLICITANTE);
            db.AddInParameter(dbCommand, "pvcCODTIPODOCU", DbType.String, entSIC_LOTEEXPEDOCU.CODTIPODOCU);
            db.AddInParameter(dbCommand, "pvcTXTNUMERO", DbType.String, entSIC_LOTEEXPEDOCU.TXTNUMERO);
            db.AddInParameter(dbCommand, "pvcTXTSOLICITANTE", DbType.String, entSIC_LOTEEXPEDOCU.TXTSOLICITANTE);
            db.AddInParameter(dbCommand, "pvcTXTIDTRAMITEDOC", DbType.String, entSIC_LOTEEXPEDOCU.TXTIDTRAMITEDOC);
            db.AddInParameter(dbCommand, "pvcFLGINTEXT", DbType.String, entSIC_LOTEEXPEDOCU.FLGINTEXT);
            db.AddInParameter(dbCommand, "pvcFECDOCUMENTO", DbType.Date, entSIC_LOTEEXPEDOCU.FECDOCUMENTO);
            db.AddInParameter(dbCommand, "pvcTXTOBSERVACION", DbType.String, entSIC_LOTEEXPEDOCU.TXTOBSERVACION);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTEEXPEDOCU.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddOutParameter(dbCommand, "pvcCODCORRLOTEEXPEDOCU", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODCORRLOTEEXPEDOCU"));
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
        //Utilizado por	: BusinessLogic.SIC_LOTEEXPEDOCU.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_LOTEEXPEDOCU
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_LOTEEXPEDOCU entSIC_LOTEEXPEDOCU)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTEEXPEDOCU.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEEXPEDOCU.PRC_MODIFICAR" : ".PKG_MSISIC_PROC_LOTEEXPEDOCU.PRC_MODIFICAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTEEXPEDOCU.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTEEXPEDOCU.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTEEXPEDOCU.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTEEXPEDOCU.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTEEXPEDOCU.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTEEXPEDOCU.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODSOLICITANTE", DbType.String, entSIC_LOTEEXPEDOCU.CODSOLICITANTE);
            db.AddInParameter(dbCommand, "pvcCODTIPODOCU", DbType.String, entSIC_LOTEEXPEDOCU.CODTIPODOCU);
            db.AddInParameter(dbCommand, "pvcTXTNUMERO", DbType.String, entSIC_LOTEEXPEDOCU.TXTNUMERO);
            db.AddInParameter(dbCommand, "pvcTXTSOLICITANTE", DbType.String, entSIC_LOTEEXPEDOCU.TXTSOLICITANTE);
            db.AddInParameter(dbCommand, "pvcTXTIDTRAMITEDOC", DbType.String, entSIC_LOTEEXPEDOCU.TXTIDTRAMITEDOC);
            db.AddInParameter(dbCommand, "pvcFLGINTEXT", DbType.String, entSIC_LOTEEXPEDOCU.FLGINTEXT);
            db.AddInParameter(dbCommand, "pvcFECDOCUMENTO", DbType.Date, entSIC_LOTEEXPEDOCU.FECDOCUMENTO);
            db.AddInParameter(dbCommand, "pvcTXTOBSERVACION", DbType.String, entSIC_LOTEEXPEDOCU.TXTOBSERVACION);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTEEXPEDOCU.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddInParameter(dbCommand, "pvcCODCORRLOTEEXPEDOCU", DbType.String, entSIC_LOTEEXPEDOCU.CODCORRLOTEEXPEDOCU);
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
        //Utilizado por	: BusinessLogic.SIC_LOTEEXPEDOCU.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_LOTEEXPEDOCU
        /// </summary>
        public BE.SIC_LOTEEXPEDOCU Recuperar(BE.SIC_LOTEEXPEDOCU entSIC_LOTEEXPEDOCU)
        {
            BE.SIC_LOTEEXPEDOCU lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTEEXPEDOCU.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEEXPEDOCU.PRC_DATOS" : ".PKG_MSISIC_PROC_LOTEEXPEDOCU.PRC_DATOS_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[8]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_LOTEEXPEDOCU.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_LOTEEXPEDOCU.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_LOTEEXPEDOCU.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_LOTEEXPEDOCU.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_LOTEEXPEDOCU.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_LOTEEXPEDOCU.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCODCORRLOTEEXPEDOCU", entSIC_LOTEEXPEDOCU.CODCORRLOTEEXPEDOCU);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_LOTEEXPEDOCU(reader, BE.SIC_LOTEEXPEDOCU.Query.Recuperar);
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
        //Utilizado por	: BusinessLogic.SIC_LOTEEXPEDOCU.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_LOTEEXPEDOCU
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_LOTEEXPEDOCU entSIC_LOTEEXPEDOCU)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTEEXPEDOCU.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEEXPEDOCU.PRC_ELIMINAR" : ".PKG_MSISIC_PROC_LOTEEXPEDOCU.PRC_ELIMINAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTEEXPEDOCU.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTEEXPEDOCU.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTEEXPEDOCU.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTEEXPEDOCU.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTEEXPEDOCU.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTEEXPEDOCU.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODCORRLOTEEXPEDOCU", DbType.String, entSIC_LOTEEXPEDOCU.CODCORRLOTEEXPEDOCU);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTEEXPEDOCU.CODUSUARIO);
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
        //Creado por	: Jaime Díaz Espinoza (26/06/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTEEXPEDOCU.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_LOTEEXPEDOCU
        /// </summary>
        public IEnumerable<BE.SIC_LOTEEXPEDOCU> Buscar(BE.SIC_LOTEEXPEDOCU entSIC_LOTEEXPEDOCU)
        {
            List<BE.SIC_LOTEEXPEDOCU> lista = new List<BE.SIC_LOTEEXPEDOCU>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTEEXPEDOCU.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEEXPEDOCU.PRC_BUSCAR" : ".PKG_MSISIC_PROC_LOTEEXPEDOCU.PRC_BUSCAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[8]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_LOTEEXPEDOCU.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_LOTEEXPEDOCU.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_LOTEEXPEDOCU.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_LOTEEXPEDOCU.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_LOTEEXPEDOCU.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_LOTEEXPEDOCU.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcORDEN", entSIC_LOTEEXPEDOCU.ORDEN);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_LOTEEXPEDOCU(reader, BE.SIC_LOTEEXPEDOCU.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public IEnumerable<BE.SIC_LOTEEXPEDOCU> DocumentosLote(BE.SIC_LOTEEXPEDOCU entSIC_SOLISEGUI)
        {
            List<BE.SIC_LOTEEXPEDOCU> lista = new List<BE.SIC_LOTEEXPEDOCU>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_SOLISEGUI.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEEXPEDOCU.PRC_BUSCAR_DOCUMENTOS" : ".PKG_MSISIC_PROC_LOTEEXPEDOCU.PRC_BUSCAR_DOCUMENTOS_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODIGOCATASTRAL", entSIC_SOLISEGUI.TXTCODIGOCATASTRAL);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_LOTEEXPEDOCU(reader, BE.SIC_LOTEEXPEDOCU.Query.ListarDocumentos));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public BE.SIC_RETORNO AgregarDocumentos(BE.SIC_LOTEEXPEDOCU entSIC_LOTEDOCUMENTOS)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTEDOCUMENTOS.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEEXPEDOCU.PRC_INSERTAR_DOCUMENTOS" : ".PKG_MSISIC_PROC_LOTEEXPEDOCU.PRC_INSERTAR_DOCUMENTOS_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTEDOCUMENTOS.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTEDOCUMENTOS.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTEDOCUMENTOS.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTEDOCUMENTOS.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTEDOCUMENTOS.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTEDOCUMENTOS.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODTIPODOCU", DbType.String, entSIC_LOTEDOCUMENTOS.CODTIPODOCU);
            db.AddInParameter(dbCommand, "pvcTXTNUMERO", DbType.String, entSIC_LOTEDOCUMENTOS.TXTNUMERO);
            db.AddInParameter(dbCommand, "pvcTXTSOLICITANTE", DbType.String, entSIC_LOTEDOCUMENTOS.TXTSOLICITANTE);
            db.AddInParameter(dbCommand, "pvcFECDOCUMENTO", DbType.Date, entSIC_LOTEDOCUMENTOS.FECDOCUMENTO);
            db.AddInParameter(dbCommand, "pvcTXTOBSERVACION", DbType.String, entSIC_LOTEDOCUMENTOS.TXTOBSERVACION);
            db.AddInParameter(dbCommand, "pvcTXTIDTRAMITE", DbType.String, entSIC_LOTEDOCUMENTOS.TXTIDTRAMITE);
            db.AddInParameter(dbCommand, "pvcCODSOLICITANTE", DbType.String, entSIC_LOTEDOCUMENTOS.CODSOLICITANTE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTEDOCUMENTOS.CODUSUARIO);
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
        public BE.SIC_RETORNO EliminarDocumentos(BE.SIC_LOTEEXPEDOCU entSIC_LOTEDOCUMENTOS)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTEDOCUMENTOS.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEEXPEDOCU.PRC_ELIMINAR_DOCUMENTOS" : ".PKG_MSISIC_PROC_LOTEEXPEDOCU.PRC_ELIMINAR_DOCUMENTOS_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTEDOCUMENTOS.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTEDOCUMENTOS.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTEDOCUMENTOS.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTEDOCUMENTOS.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTEDOCUMENTOS.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTEDOCUMENTOS.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODCORRLOTEEXPEDOCU", DbType.String, entSIC_LOTEDOCUMENTOS.CODCORRLOTEEXPEDOCU);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTEDOCUMENTOS.CODUSUARIO);
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
