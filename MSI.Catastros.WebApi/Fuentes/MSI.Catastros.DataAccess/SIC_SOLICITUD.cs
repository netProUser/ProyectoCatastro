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
    public class SIC_SOLICITUD : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (17/05/2018)
        //Utilizado por	: BusinessLogic.SIC_SOLICITUD.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_SOLICITUD, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_SOLICITUD entSIC_SOLICITUD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_SOLICITUD.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcCODANOSOLI", DbType.String, entSIC_SOLICITUD.CODANOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNUMESOLI", DbType.String, entSIC_SOLICITUD.CODNUMESOLI);
            db.AddInParameter(dbCommand, "pvcCODTIPOSOLI", DbType.String, entSIC_SOLICITUD.CODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcCODAREASOLI", DbType.String, entSIC_SOLICITUD.CODAREASOLI);
            db.AddInParameter(dbCommand, "pvcFECSOLICITUD", DbType.Date, entSIC_SOLICITUD.FECSOLICITUD);
            db.AddInParameter(dbCommand, "pvcFECRECEP", DbType.Date, entSIC_SOLICITUD.FECRECEP);
            db.AddInParameter(dbCommand, "pvcTXTASUNTO", DbType.String, entSIC_SOLICITUD.TXTASUNTO);
            db.AddInParameter(dbCommand, "pvcCODTIPOLLENA", DbType.String, entSIC_SOLICITUD.CODTIPOLLENA);
            db.AddInParameter(dbCommand, "pvcCODTIPODOC", DbType.String, entSIC_SOLICITUD.CODTIPODOC);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_SOLICITUD.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcNUMFOLSOL", DbType.String, entSIC_SOLICITUD.NUMFOLSOL);
            db.AddInParameter(dbCommand, "pvcID_REF", DbType.String, entSIC_SOLICITUD.ID_REF);
            db.AddInParameter(dbCommand, "pvcCODIGO_CONTRIBUYENTE", DbType.String, entSIC_SOLICITUD.CODIGO_CONTRIBUYENTE);
            db.AddInParameter(dbCommand, "pvcCOD_RECURRENTE", DbType.String, entSIC_SOLICITUD.COD_RECURRENTE);
            db.AddInParameter(dbCommand, "pvcTXTSOLICITANTE", DbType.String, entSIC_SOLICITUD.TXTSOLICITANTE);
            db.AddInParameter(dbCommand, "pvcTXTDESC_TIPODOCREC", DbType.String, entSIC_SOLICITUD.TXTDESC_TIPODOCREC);
            db.AddInParameter(dbCommand, "pvcTXTDOCIDRECURRENTE", DbType.String, entSIC_SOLICITUD.TXTDOCIDRECURRENTE);
            db.AddInParameter(dbCommand, "pvcTXTREPRESENTANTEL", DbType.String, entSIC_SOLICITUD.TXTREPRESENTANTEL);
            db.AddInParameter(dbCommand, "pvcTXTCODTIPODOCUMENTOREC", DbType.String, entSIC_SOLICITUD.TXTCODTIPODOCUMENTOREC);
            db.AddInParameter(dbCommand, "pvcTXTDES_TIPODOCREPL", DbType.String, entSIC_SOLICITUD.TXTDES_TIPODOCREPL);
            db.AddInParameter(dbCommand, "pvcTXTCODTIPODOCREPLEGAL", DbType.String, entSIC_SOLICITUD.TXTCODTIPODOCREPLEGAL);
            db.AddInParameter(dbCommand, "pvcTXTDOCIDEREPRESENTANTEL", DbType.String, entSIC_SOLICITUD.TXTDOCIDEREPRESENTANTEL);
            db.AddOutParameter(dbCommand, "pvcGENNUMESOLI", DbType.String, 20);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcGENNUMESOLI"));
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
        //Creado por	: Jaime Díaz Espinoza (22/05/2018)
        //Utilizado por	: BusinessLogic.SIC_SOLICITUD.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_SOLICITUD
        /// </summary>
        public BE.SIC_SOLICITUD Recuperar(BE.SIC_SOLICITUD entSIC_SOLICITUD)
        {
            BE.SIC_SOLICITUD lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_SOLICITUD.PRC_DATOS", new object[7]);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_SOLICITUD.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_SOLICITUD.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_SOLICITUD.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcFECRECEP", entSIC_SOLICITUD.FECRECEP);
            db.SetParameterValue(dbCommand, "pvcCODUSUARIO", entSIC_SOLICITUD.CODUSUARIO);
            db.SetParameterValue(dbCommand, "pvcCODTIPODOC", entSIC_SOLICITUD.CODTIPODOC);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_SOLICITUD(reader, BE.SIC_SOLICITUD.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (17/05/2018)
        //Utilizado por	: BusinessLogic.SIC_SOLICITUD.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_SOLICITUD
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_SOLICITUD entSIC_SOLICITUD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_SOLICITUD.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODANOSOLI", DbType.String, entSIC_SOLICITUD.CODANOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNUMESOLI", DbType.String, entSIC_SOLICITUD.CODNUMESOLI);
            db.AddInParameter(dbCommand, "pvcCODTIPOSOLI", DbType.String, entSIC_SOLICITUD.CODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcCODAREASOLI", DbType.String, entSIC_SOLICITUD.CODAREASOLI);
            db.AddInParameter(dbCommand, "pvcFECSOLICITUD", DbType.Date, entSIC_SOLICITUD.FECSOLICITUD);
            db.AddInParameter(dbCommand, "pvcFECRECEP", DbType.Date, entSIC_SOLICITUD.FECRECEP);
            db.AddInParameter(dbCommand, "pvcTXTASUNTO", DbType.String, entSIC_SOLICITUD.TXTASUNTO);
            db.AddInParameter(dbCommand, "pvcCODTIPOLLENA", DbType.String, entSIC_SOLICITUD.CODTIPOLLENA);
            db.AddInParameter(dbCommand, "pvcCODTIPODOC", DbType.String, entSIC_SOLICITUD.CODTIPODOC);
            db.AddInParameter(dbCommand, "pvcFECFINSOLICITUD", DbType.Date, entSIC_SOLICITUD.FECFINSOLICITUD);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_SOLICITUD.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcCODESTADOFINAL", DbType.String, entSIC_SOLICITUD.CODESTADOFINAL);
            db.AddInParameter(dbCommand, "pvcNUMFOLSOL", DbType.String, entSIC_SOLICITUD.NUMFOLSOL);
            db.AddInParameter(dbCommand, "pvcESTADO", DbType.String, entSIC_SOLICITUD.ESTADO);
            db.AddInParameter(dbCommand, "pvcNUMCALVER", DbType.String, entSIC_SOLICITUD.NUMCALVER);
            db.AddInParameter(dbCommand, "pvcTXTANOCALVER", DbType.String, entSIC_SOLICITUD.TXTANOCALVER);
            db.AddInParameter(dbCommand, "pvcCODIGO_CONTRIBUYENTE", DbType.String, entSIC_SOLICITUD.CODIGO_CONTRIBUYENTE);
            db.AddInParameter(dbCommand, "pvcCOD_RECURRENTE", DbType.String, entSIC_SOLICITUD.COD_RECURRENTE);
            db.AddInParameter(dbCommand, "pvcTXTSOLICITANTE", DbType.String, entSIC_SOLICITUD.TXTSOLICITANTE);
            db.AddInParameter(dbCommand, "pvcTXTDESC_TIPODOCREC", DbType.String, entSIC_SOLICITUD.TXTDESC_TIPODOCREC);
            db.AddInParameter(dbCommand, "pvcTXTDOCIDRECURRENTE", DbType.String, entSIC_SOLICITUD.TXTDOCIDRECURRENTE);
            db.AddInParameter(dbCommand, "pvcTXTREPRESENTANTEL", DbType.String, entSIC_SOLICITUD.TXTREPRESENTANTEL);
            db.AddInParameter(dbCommand, "pvcTXTCODTIPODOCUMENTOREC", DbType.String, entSIC_SOLICITUD.TXTCODTIPODOCUMENTOREC);
            db.AddInParameter(dbCommand, "pvcTXTDES_TIPODOCREPL", DbType.String, entSIC_SOLICITUD.TXTDES_TIPODOCREPL);
            db.AddInParameter(dbCommand, "pvcTXTCODTIPODOCREPLEGAL", DbType.String, entSIC_SOLICITUD.TXTCODTIPODOCREPLEGAL);
            db.AddInParameter(dbCommand, "pvcTXTDOCIDEREPRESENTANTEL", DbType.String, entSIC_SOLICITUD.TXTDOCIDEREPRESENTANTEL);
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
        public BE.SIC_RETORNO ActualizarInspecciones(BE.SIC_SOLICITUD entSIC_SOLICITUD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_SOLICITUD.PRC_MODIFICAR_INSPECCION");
            db.AddInParameter(dbCommand, "pvcCODANOSOLI", DbType.String, entSIC_SOLICITUD.CODANOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNUMESOLI", DbType.String, entSIC_SOLICITUD.CODNUMESOLI);
            db.AddInParameter(dbCommand, "pvcCODTIPOSOLI", DbType.String, entSIC_SOLICITUD.CODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcCODAREASOLI", DbType.String, entSIC_SOLICITUD.CODAREASOLI);
            db.AddInParameter(dbCommand, "pvcFECSOLICITUD", DbType.Date, entSIC_SOLICITUD.FECSOLICITUD);
            db.AddInParameter(dbCommand, "pvcFECRECEP", DbType.Date, entSIC_SOLICITUD.FECRECEP);
            db.AddInParameter(dbCommand, "pvcTXTASUNTO", DbType.String, entSIC_SOLICITUD.TXTASUNTO);
            db.AddInParameter(dbCommand, "pvcCODTIPOLLENA", DbType.String, entSIC_SOLICITUD.CODTIPOLLENA);
            db.AddInParameter(dbCommand, "pvcCODTIPODOC", DbType.String, entSIC_SOLICITUD.CODTIPODOC);
            db.AddInParameter(dbCommand, "pvcFECFINSOLICITUD", DbType.Date, entSIC_SOLICITUD.FECFINSOLICITUD);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_SOLICITUD.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcCODESTADOFINAL", DbType.String, entSIC_SOLICITUD.CODESTADOFINAL);
            db.AddInParameter(dbCommand, "pvcNUMFOLSOL", DbType.String, entSIC_SOLICITUD.NUMFOLSOL);
            db.AddInParameter(dbCommand, "pvcESTADO", DbType.String, entSIC_SOLICITUD.ESTADO);
            db.AddInParameter(dbCommand, "pvcNUMCALVER", DbType.String, entSIC_SOLICITUD.NUMCALVER);
            db.AddInParameter(dbCommand, "pvcTXTANOCALVER", DbType.String, entSIC_SOLICITUD.TXTANOCALVER);
            db.AddInParameter(dbCommand, "pvcCODIGO_CONTRIBUYENTE", DbType.String, entSIC_SOLICITUD.CODIGO_CONTRIBUYENTE);
            db.AddInParameter(dbCommand, "pvcCOD_RECURRENTE", DbType.String, entSIC_SOLICITUD.COD_RECURRENTE);
            db.AddInParameter(dbCommand, "pvcTXTSOLICITANTE", DbType.String, entSIC_SOLICITUD.TXTSOLICITANTE);
            db.AddInParameter(dbCommand, "pvcTXTDESC_TIPODOCREC", DbType.String, entSIC_SOLICITUD.TXTDESC_TIPODOCREC);
            db.AddInParameter(dbCommand, "pvcTXTDOCIDRECURRENTE", DbType.String, entSIC_SOLICITUD.TXTDOCIDRECURRENTE);
            db.AddInParameter(dbCommand, "pvcTXTREPRESENTANTEL", DbType.String, entSIC_SOLICITUD.TXTREPRESENTANTEL);
            db.AddInParameter(dbCommand, "pvcTXTCODTIPODOCUMENTOREC", DbType.String, entSIC_SOLICITUD.TXTCODTIPODOCUMENTOREC);
            db.AddInParameter(dbCommand, "pvcTXTDES_TIPODOCREPL", DbType.String, entSIC_SOLICITUD.TXTDES_TIPODOCREPL);
            db.AddInParameter(dbCommand, "pvcTXTCODTIPODOCREPLEGAL", DbType.String, entSIC_SOLICITUD.TXTCODTIPODOCREPLEGAL);
            db.AddInParameter(dbCommand, "pvcTXTDOCIDEREPRESENTANTEL", DbType.String, entSIC_SOLICITUD.TXTDOCIDEREPRESENTANTEL);
            db.AddInParameter(dbCommand, "pvcTXTFECLIMITE", DbType.String, entSIC_SOLICITUD.TXTFECLIMITE );
            db.AddInParameter(dbCommand, "pvcTXTFECLIMITEPROGINSP", DbType.String, entSIC_SOLICITUD.TXTFECLIMITEPROGINSP );
            db.AddInParameter(dbCommand, "pvcTXTFECLIMITEINSPECCION", DbType.String, entSIC_SOLICITUD.TXTFECLIMITEINSPECCION);
            db.AddInParameter(dbCommand, "pvcTXTTELEFONO", DbType.String, entSIC_SOLICITUD.TXTTELEFONO);
            db.AddInParameter(dbCommand, "pvcTXTUBICACION", DbType.String, entSIC_SOLICITUD.TXTUBICACION);


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
        public BE.SIC_RETORNO RechazaraDocumentos(BE.SIC_SOLICITUD entSIC_SOLICITUD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_DOCUMENTOS.PRC_RECHAZARDOCUMENTO");
            db.AddInParameter(dbCommand, "pvcCODANOSOLI", DbType.String, entSIC_SOLICITUD.CODANOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNUMESOLI", DbType.String, entSIC_SOLICITUD.CODNUMESOLI);
            db.AddInParameter(dbCommand, "pvcCODTIPOSOLI", DbType.String, entSIC_SOLICITUD.CODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcCODTIPODOC", DbType.String, entSIC_SOLICITUD.CODTIPODOC);
            db.AddInParameter(dbCommand, "pvcCORMAXSOLI", DbType.String, entSIC_SOLICITUD.CORMAXSOLI);
            db.AddOutParameter(dbCommand,"pvcNROMENSAJE", DbType.Int32, 0);
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
        //Creado por	: Jaime Díaz Espinoza (17/05/2018)
        //Utilizado por	: BusinessLogic.SIC_SOLICITUD.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_SOLICITUD
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_SOLICITUD entSIC_SOLICITUD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_SOLICITUD.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODANOSOLI", DbType.String, entSIC_SOLICITUD.CODANOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNUMESOLI", DbType.String, entSIC_SOLICITUD.CODNUMESOLI);
            db.AddInParameter(dbCommand, "pvcCODTIPOSOLI", DbType.String, entSIC_SOLICITUD.CODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_SOLICITUD.CODUSUARIO);
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
        //Creado por	: Jaime Díaz Espinoza (17/05/2018)
        //Utilizado por	: BusinessLogic.SIC_SOLICITUD.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_SOLICITUD
        /// </summary>
        public IEnumerable<BE.SIC_SOLICITUD> Buscar(BE.SIC_SOLICITUD entSIC_SOLICITUD)
        {
            List<BE.SIC_SOLICITUD> lista = new List<BE.SIC_SOLICITUD>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_SOLICITUD.PRC_BUSCAR", new object[6]);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_SOLICITUD.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_SOLICITUD.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcORDEN", entSIC_SOLICITUD.ORDEN);
            db.SetParameterValue(dbCommand, "pinNUMPAG", entSIC_SOLICITUD.PAGINANUMERO);
            db.SetParameterValue(dbCommand, "pinNUMREG", entSIC_SOLICITUD.PAGINAREGISTROS);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_SOLICITUD(reader, BE.SIC_SOLICITUD.Query.Buscar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (21/05/2018)
        //Utilizado por	: BusinessLogic.SIC_SOLICITUD.BuscarInt
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_SOLICITUD
        /// </summary>
        public BE.SIC_SOLICITUD BuscarInt(BE.SIC_SOLICITUD entSIC_SOLICITUD)
        {
            BE.SIC_SOLICITUD lista = new BE.SIC_SOLICITUD();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_SOLICITUD.PRC_BUSCAR_INT");
            db.AddInParameter(dbCommand, "pvcCODTIPOSOLI", DbType.String, entSIC_SOLICITUD.CODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNUMESOLI", DbType.String, entSIC_SOLICITUD.CODNUMESOLI);
            db.AddInParameter(dbCommand, "pinNUMREG", DbType.String, entSIC_SOLICITUD.PAGINAREGISTROS);
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
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (30/05/2018)
        //Utilizado por	: BusinessLogic.SIC_SOLICITUD.Seguimiento
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_SOLICITUD
        /// </summary>
        public IEnumerable<BE.SIC_SOLICITUD> Seguimiento(BE.SIC_SOLICITUD entSIC_SOLICITUD)
        {
            List<BE.SIC_SOLICITUD> lista = new List<BE.SIC_SOLICITUD>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_SOLICITUD.PRC_SEGUIMIENTO", new object[11]);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_SOLICITUD.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_SOLICITUD.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcFECHAINICIO", entSIC_SOLICITUD.FECSOLICITUD);
            db.SetParameterValue(dbCommand, "pvcFECHAFINAL", entSIC_SOLICITUD.FECFINSOLICITUD);
            db.SetParameterValue(dbCommand, "pvcTXTASUNTO", entSIC_SOLICITUD.TXTASUNTO);
            db.SetParameterValue(dbCommand, "pvcTXTNOMBRETITULAR", entSIC_SOLICITUD.TXTNOMBRETITULAR);
            db.SetParameterValue(dbCommand, "pvcTXTUNIDADCATASTRAL", entSIC_SOLICITUD.TXTUNIDADCATASTRAL);
            db.SetParameterValue(dbCommand, "pvcORDEN", entSIC_SOLICITUD.ORDEN);
            db.SetParameterValue(dbCommand, "pinNUMPAG", entSIC_SOLICITUD.PAGINANUMERO);
            db.SetParameterValue(dbCommand, "pinNUMREG", entSIC_SOLICITUD.PAGINAREGISTROS);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_SOLICITUD(reader, BE.SIC_SOLICITUD.Query.Seguimiento));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public IEnumerable<BE.SIC_SOLICITUD> CargarGrillaCatastral(BE.SIC_SOLICITUD entSIC_SOLISEGUI)
        {
            List<BE.SIC_SOLICITUD> lista = new List<BE.SIC_SOLICITUD>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_DOCUMENTOS.PRC_DOCUMENTOSCATASTRALES", new object[8]);
            db.SetParameterValue(dbCommand, "pvcESTADODOCUMENTO", entSIC_SOLISEGUI.ESTADO);
            db.SetParameterValue(dbCommand, "pvcTIPOSOLICITUD", entSIC_SOLISEGUI.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcTIPODOCUMENTO", entSIC_SOLISEGUI.CODTIPODOC);
            db.SetParameterValue(dbCommand, "pvcNUMEROSOLICITUD", entSIC_SOLISEGUI.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcFECINICIO", entSIC_SOLISEGUI.FECINICIO);
            db.SetParameterValue(dbCommand, "pvcFECFIN", entSIC_SOLISEGUI.FECFIN);
            db.SetParameterValue(dbCommand, "pvcCODUSUARIO", entSIC_SOLISEGUI.CODUSUARIO);

            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_SOLICITUD(reader, BE.SIC_SOLICITUD.Query.RecepcionDocumento));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        
        public IEnumerable<BE.SIC_SOLICITUD> CargarGrillaCatastralInternaPendiente(BE.SIC_SOLICITUD entSIC_SOLISEGUI)
        {
            List<BE.SIC_SOLICITUD> lista = new List<BE.SIC_SOLICITUD>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_DOCUMENTOS.PRC_DOCUMENTOSCATASTRALES_IN", new object[8]);
            db.SetParameterValue(dbCommand, "pvcESTADODOCUMENTO", entSIC_SOLISEGUI.ESTADO);
            db.SetParameterValue(dbCommand, "pvcTIPOSOLICITUD", entSIC_SOLISEGUI.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcTIPODOCUMENTO", entSIC_SOLISEGUI.CODTIPODOC);
            db.SetParameterValue(dbCommand, "pvcNUMEROSOLICITUD", entSIC_SOLISEGUI.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcFECINICIO", null);
            db.SetParameterValue(dbCommand, "pvcFECFIN", null);
            db.SetParameterValue(dbCommand, "pvcCODUSUARIO", entSIC_SOLISEGUI.CODUSUARIO);

            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_SOLICITUD(reader, BE.SIC_SOLICITUD.Query.RecepcionDocumentoInterno));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public IEnumerable<BE.SIC_SOLICITUD> CargarGrillaCatastralExternaPendiente(BE.SIC_SOLICITUD entSIC_SOLISEGUI)
        {
            List<BE.SIC_SOLICITUD> lista = new List<BE.SIC_SOLICITUD>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_DOCUMENTOS.PRC_DOCUMENTOSCATASTRALES_EX", new object[8]);
            db.SetParameterValue(dbCommand, "pvcESTADODOCUMENTO", entSIC_SOLISEGUI.ESTADO);
            db.SetParameterValue(dbCommand, "pvcTIPOSOLICITUD", entSIC_SOLISEGUI.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcTIPODOCUMENTO", entSIC_SOLISEGUI.CODTIPODOC);
            db.SetParameterValue(dbCommand, "pvcNUMEROSOLICITUD", entSIC_SOLISEGUI.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcFECINICIO", null);
            db.SetParameterValue(dbCommand, "pvcFECFIN", null);
            db.SetParameterValue(dbCommand, "pvcCODUSUARIO", entSIC_SOLISEGUI.CODUSUARIO);

            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_SOLICITUD(reader, BE.SIC_SOLICITUD.Query.RecepcionDocumentoExterno));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public BE.SIC_SOLICITUD RecuperarDatosSolicitud(BE.SIC_SOLICITUD entSIC_UNIDAD)
        {

            BE.SIC_SOLICITUD lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = ".PKG_MSISIC_GEST_DOCUMENTOS.PRC_DATOSSOLICITUDINDIVIDUAL";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[5]);

            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_UNIDAD.CODANOSOLI );
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_UNIDAD.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_UNIDAD.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPODOC", entSIC_UNIDAD.CODTIPODOC);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_SOLICITUD(reader, BE.SIC_SOLICITUD.Query.RecuperarDatosRelevantes);
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
