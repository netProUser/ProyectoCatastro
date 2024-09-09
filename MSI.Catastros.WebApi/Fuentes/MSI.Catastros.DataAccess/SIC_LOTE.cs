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
    public class SIC_LOTE : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (07/06/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTE.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_LOTE, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_LOTE entSIC_LOTE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTE.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTE.PRC_INSERTAR" : ".PKG_MSISIC_PROC_LOTE.PRC_INSERTAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTE.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTE.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTE.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTE.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTE.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTE.CODLOTE);
            db.AddInParameter(dbCommand, "pvcTXTDENOMINACION", DbType.String, entSIC_LOTE.TXTDENOMINACION);
            db.AddInParameter(dbCommand, "pvcFLGMONUHIST", DbType.String, entSIC_LOTE.FLGMONUHIST);
            db.AddInParameter(dbCommand, "pvcFLGLOTEESQU", DbType.String, entSIC_LOTE.FLGLOTEESQU);
            db.AddInParameter(dbCommand, "pvcCODTIPOLOTE", DbType.String, entSIC_LOTE.CODTIPOLOTE);
            db.AddInParameter(dbCommand, "pvcTXTLOTEURBA", DbType.String, entSIC_LOTE.TXTLOTEURBA);
            db.AddInParameter(dbCommand, "pvcTXTSUBLOTEURBA", DbType.String, entSIC_LOTE.TXTSUBLOTEURBA);
            db.AddInParameter(dbCommand, "pvcNUMAREATERRCAMP", DbType.Decimal, entSIC_LOTE.NUMAREATERRCAMP);
            db.AddInParameter(dbCommand, "pvcNUMAREATERROFIC", DbType.Decimal, entSIC_LOTE.NUMAREATERROFIC);
            db.AddInParameter(dbCommand, "pvcCODFUENTE", DbType.String, entSIC_LOTE.CODFUENTE);
            db.AddInParameter(dbCommand, "pvcNUMAREACONSTOTAL", DbType.Decimal, entSIC_LOTE.NUMAREACONSTOTAL);
            db.AddInParameter(dbCommand, "pvcTXTSECTVECI", DbType.String, entSIC_LOTE.TXTSECTVECI);
            db.AddInParameter(dbCommand, "pvcTXTSECTPLAN", DbType.String, entSIC_LOTE.TXTSECTPLAN);
            db.AddInParameter(dbCommand, "pvcTXTSECTSEGU", DbType.String, entSIC_LOTE.TXTSECTSEGU);
            db.AddInParameter(dbCommand, "pvcTXTSUBSECTVECI", DbType.String, entSIC_LOTE.TXTSUBSECTVECI);
            db.AddInParameter(dbCommand, "pvcTXTSUBSECTPLAN", DbType.String, entSIC_LOTE.TXTSUBSECTPLAN);
            db.AddInParameter(dbCommand, "pvcTXTSECTCATAS", DbType.String, entSIC_LOTE.TXTSECTCATAS);
            db.AddInParameter(dbCommand, "pvcTXTSUBSECTCATAS", DbType.String, entSIC_LOTE.TXTSUBSECTCATAS);
            db.AddInParameter(dbCommand, "pvcNUMALTULOTE", DbType.String, entSIC_LOTE.NUMALTULOTE);
            db.AddInParameter(dbCommand, "pvcCODUSOCLAS", DbType.String, entSIC_LOTE.CODUSOCLAS);
            db.AddInParameter(dbCommand, "pvcTXTRESONUM", DbType.String, entSIC_LOTE.TXTRESONUM);
            db.AddInParameter(dbCommand, "pvcFECRESOLUC", DbType.DateTime, entSIC_LOTE.FECRESOLUC);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTE.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = "0"; // (string)(db.GetParameterValue(dbCommand, "pvcCODMANZANA"));
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
        //Utilizado por	: BusinessLogic.SIC_LOTE.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_LOTE
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_LOTE entSIC_LOTE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTE.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTE.PRC_MODIFICAR" : ".PKG_MSISIC_PROC_LOTE.PRC_MODIFICAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTE.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTE.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTE.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTE.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTE.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTE.CODLOTE);
            db.AddInParameter(dbCommand, "pvcTXTDENOMINACION", DbType.String, entSIC_LOTE.TXTDENOMINACION);
            db.AddInParameter(dbCommand, "pvcFLGMONUHIST", DbType.String, entSIC_LOTE.FLGMONUHIST);
            db.AddInParameter(dbCommand, "pvcFLGLOTEESQU", DbType.String, entSIC_LOTE.FLGLOTEESQU);
            db.AddInParameter(dbCommand, "pvcCODTIPOLOTE", DbType.String, entSIC_LOTE.CODTIPOLOTE);
            db.AddInParameter(dbCommand, "pvcTXTLOTEURBA", DbType.String, entSIC_LOTE.TXTLOTEURBA);
            db.AddInParameter(dbCommand, "pvcTXTSUBLOTEURBA", DbType.String, entSIC_LOTE.TXTSUBLOTEURBA);
            db.AddInParameter(dbCommand, "pvcNUMAREATERRCAMP", DbType.Decimal, entSIC_LOTE.NUMAREATERRCAMP);
            db.AddInParameter(dbCommand, "pvcNUMAREATERROFIC", DbType.Decimal, entSIC_LOTE.NUMAREATERROFIC);
            db.AddInParameter(dbCommand, "pvcCODFUENTE", DbType.String, entSIC_LOTE.CODFUENTE);
            db.AddInParameter(dbCommand, "pvcNUMAREACONSTOTAL", DbType.Decimal, entSIC_LOTE.NUMAREACONSTOTAL);
            db.AddInParameter(dbCommand, "pvcTXTSECTVECI", DbType.String, entSIC_LOTE.TXTSECTVECI);
            db.AddInParameter(dbCommand, "pvcTXTSECTPLAN", DbType.String, entSIC_LOTE.TXTSECTPLAN);
            db.AddInParameter(dbCommand, "pvcTXTSECTSEGU", DbType.String, entSIC_LOTE.TXTSECTSEGU);
            db.AddInParameter(dbCommand, "pvcTXTSUBSECTVECI", DbType.String, entSIC_LOTE.TXTSUBSECTVECI);
            db.AddInParameter(dbCommand, "pvcTXTSUBSECTPLAN", DbType.String, entSIC_LOTE.TXTSUBSECTPLAN);
            db.AddInParameter(dbCommand, "pvcTXTSECTCATAS", DbType.String, entSIC_LOTE.TXTSECTCATAS);
            db.AddInParameter(dbCommand, "pvcTXTSUBSECTCATAS", DbType.String, entSIC_LOTE.TXTSUBSECTCATAS);
            db.AddInParameter(dbCommand, "pvcNUMALTULOTE", DbType.String, entSIC_LOTE.NUMALTULOTE);
            db.AddInParameter(dbCommand, "pvcCODUSOCLAS", DbType.String, entSIC_LOTE.CODUSOCLAS);
            db.AddInParameter(dbCommand, "pvcTXTNOMDOCU", DbType.String, entSIC_LOTE.TXTNOMDOCU);
            db.AddInParameter(dbCommand, "pvcTXTNOMDOCUINT", DbType.String, entSIC_LOTE.TXTNOMDOCUINT);
            db.AddInParameter(dbCommand, "pvcTXTRESONUM", DbType.String, entSIC_LOTE.TXTRESONUM);
            db.AddInParameter(dbCommand, "pvcFECRESOLUC", DbType.DateTime, entSIC_LOTE.FECRESOLUC);
            db.AddInParameter(dbCommand, "pvcTXTCUC", DbType.String, entSIC_LOTE.TXTCUC);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTE.CODUSUARIO);
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

        public IEnumerable<BE.SIC_LOTE> RecuperarSolicitud(BE.SIC_LOTE entSIC_LOTE)
        {
            List<BE.SIC_LOTE> lista = new List<BE.SIC_LOTE>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = ".PKG_MSISIC_PROC_LOTE.PRC_DATOS_SOLICITUD";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[7]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_LOTE.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_LOTE.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_LOTE.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_LOTE.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_LOTE.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_LOTE.CODLOTE);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_LOTE(reader, BE.SIC_LOTE.Query.RecuperarSolicitud));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (07/06/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTE.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_LOTE
        /// </summary>
        public BE.SIC_LOTE Recuperar(BE.SIC_LOTE entSIC_LOTE)
        {
            BE.SIC_LOTE lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTE.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTE.PRC_DATOS" : ".PKG_MSISIC_PROC_LOTE.PRC_DATOS_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[7]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_LOTE.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_LOTE.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_LOTE.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_LOTE.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_LOTE.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_LOTE.CODLOTE);
  
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_LOTE(reader, BE.SIC_LOTE.Query.Recuperar);
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
        //Utilizado por	: BusinessLogic.SIC_LOTE.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_LOTE
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_LOTE entSIC_LOTE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTE.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTE.PRC_ELIMINAR" : ".PKG_MSISIC_PROC_LOTE.PRC_ELIMINAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTE.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTE.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTE.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTE.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTE.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTE.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTE.CODUSUARIO);
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
        //Creado por	: Jaime Díaz Espinoza (20/06/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTE.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_LOTE
        /// </summary>
        public IEnumerable<BE.SIC_LOTE> Listar(BE.SIC_LOTE entSIC_LOTE)
        {
            List<BE.SIC_LOTE> lista = new List<BE.SIC_LOTE>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTE.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTE.PRC_LISTAR" : ".PKG_MSISIC_PROC_LOTE.PRC_LISTAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[7]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_LOTE.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_LOTE.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_LOTE.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_LOTE.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_LOTE.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_LOTE.CODLOTE);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_LOTE(reader, BE.SIC_LOTE.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }

        public IEnumerable<BE.SIC_LOTE> ListarEstaticoIgual(BE.SIC_LOTE entSIC_LOTE)
        {
            List<BE.SIC_LOTE> lista = new List<BE.SIC_LOTE>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_LOTE.PRC_LISTAR_EST", new object[7]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_LOTE.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_LOTE.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_LOTE.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_LOTE.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_LOTE.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_LOTE.CODLOTE);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_LOTE(reader, BE.SIC_LOTE.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }

        public IEnumerable<BE.SIC_LOTE> ListarEstatico(BE.SIC_LOTE entSIC_LOTE)
        {
            List<BE.SIC_LOTE> lista = new List<BE.SIC_LOTE>();

            Database db = DatabaseFactory.CreateDatabase();

            string NombreProcedure = (entSIC_LOTE.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTE.PRC_LISTAR" : ".PKG_MSISIC_PROC_LOTE.PRC_LISTAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[7]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_LOTE.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_LOTE.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_LOTE.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_LOTE.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_LOTE.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_LOTE.CODLOTE);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_LOTE(reader, BE.SIC_LOTE.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        
            public IEnumerable<BE.SIC_LOTE> ListarColindanteLoteMobiliarioUrbanoSelect(BE.SIC_LOTE entSIC_LOTE)
        {
            List<BE.SIC_LOTE> lista = new List<BE.SIC_LOTE>();

            Database db = DatabaseFactory.CreateDatabase();

            string NombreProcedure =  ".PKG_MSISIC_PROC_LOTE.PRC_LISTARLOTE" ;
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[6]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_LOTE.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_LOTE.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_LOTE.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_LOTE.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_LOTE.CODMANZANA);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_LOTE(reader, BE.SIC_LOTE.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (18/07/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTE.ListarDocum
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_LOTE
        /// </summary>
        public IEnumerable<BE.SIC_LOTE> ListarDocum(BE.SIC_LOTE entSIC_LOTE)
        {
            List<BE.SIC_LOTE> lista = new List<BE.SIC_LOTE>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTE.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTE.PRC_LOTE_DOCUM" : ".PKG_MSISIC_PROC_LOTE.PRC_LOTE_DOCUM_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODIGO_CATASTRAL", entSIC_LOTE.CODIGO_CATASTRAL);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_LOTE(reader, BE.SIC_LOTE.Query.ListarDocum));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (18/07/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTE.ListarInspec
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_LOTE
        /// </summary>
        public IEnumerable<BE.SIC_LOTE> ListarInspec(BE.SIC_LOTE entSIC_LOTE)
        {
            List<BE.SIC_LOTE> lista = new List<BE.SIC_LOTE>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTE.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTE.PRC_LOTE_INSPEC" : ".PKG_MSISIC_PROC_LOTE.PRC_LOTE_INSPEC_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[7]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_LOTE.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_LOTE.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_LOTE.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_LOTE.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_LOTE.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_LOTE.CODLOTE);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_LOTE(reader, BE.SIC_LOTE.Query.ListarInspec));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }



        public BE.SIC_RETORNO MigrarEstaticoTemporal(BE.SIC_LOTE entSIC_LOTE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_ESTATEMP.PRC_INSERTAR_ESTA_TEMP_LOTE");
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTE.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTE.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTE.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTE.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTE.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTE.CODLOTE);
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
    }
}
