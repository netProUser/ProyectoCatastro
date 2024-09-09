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
    public class SIC_CERTIFICADO : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (08/08/2018)
        //Utilizado por	: BusinessLogic.SIC_CERTIFICADO.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_CERTIFICADO
        /// </summary>
        public IEnumerable<BE.SIC_CERTIFICADO> Buscar(BE.SIC_CERTIFICADO entSIC_CERTIFICADO)
        {
            List<BE.SIC_CERTIFICADO> lista = new List<BE.SIC_CERTIFICADO>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_CERTIFICADO.PRC_BUSCAR", new object[8]);
            db.SetParameterValue(dbCommand, "pvcCODCERTIFICADO", entSIC_CERTIFICADO.CODCERTIFICADO);
            db.SetParameterValue(dbCommand, "pvcCODANOCERTI", entSIC_CERTIFICADO.CODANOCERTI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOCERTI", entSIC_CERTIFICADO.CODTIPOCERTI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_CERTIFICADO.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_CERTIFICADO.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_CERTIFICADO.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCTIPODOCUMENTO", entSIC_CERTIFICADO.CTIPODOCUMENTO);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_CERTIFICADO(reader, BE.SIC_CERTIFICADO.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public IEnumerable<BE.SIC_CERTIFICADO> BuscarCertificados(BE.SIC_CERTIFICADO entSIC_CERTIFICADO)
        {
            List<BE.SIC_CERTIFICADO> lista = new List<BE.SIC_CERTIFICADO>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_CERTIFICADO.PRC_BUSCAR_CERTIFICADO", new object[9]);
            db.SetParameterValue(dbCommand, "pvcCODCERTIFICADO", entSIC_CERTIFICADO.CODCERTIFICADO);
            db.SetParameterValue(dbCommand, "pvcCODANOCERTI", entSIC_CERTIFICADO.CODANOCERTI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOCERTI", entSIC_CERTIFICADO.CODTIPOCERTI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_CERTIFICADO.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_CERTIFICADO.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_CERTIFICADO.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCTIPODOCUMENTO", entSIC_CERTIFICADO.CTIPODOCUMENTO);
            db.SetParameterValue(dbCommand, "pvcORDEN", entSIC_CERTIFICADO.ORDEN);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_CERTIFICADO(reader, BE.SIC_CERTIFICADO.Query.ListarCertificado));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (07/08/2018)
        //Utilizado por	: BusinessLogic.SIC_CERTIFICADO.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_CERTIFICADO, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_CERTIFICADO entSIC_CERTIFICADO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_CERTIFICADO.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcCODTIPOCERTI", DbType.String, entSIC_CERTIFICADO.CODTIPOCERTI);
            db.AddInParameter(dbCommand, "pvcCODANOCERTI", DbType.String, entSIC_CERTIFICADO.CODANOCERTI);
            db.AddInParameter(dbCommand, "pvcCODANOSOLI", DbType.String, entSIC_CERTIFICADO.CODANOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNUMESOLI", DbType.String, entSIC_CERTIFICADO.CODNUMESOLI);
            //db.AddInParameter(dbCommand, "pvcCTIPODOCUMENTO", DbType.String, entSIC_CERTIFICADO.CTIPODOCUMENTO);
            db.AddInParameter(dbCommand, "pvcCTIPODOCUMENTO", DbType.String, entSIC_CERTIFICADO.CTIPODOCUMENTO == "REQI" ? "" : entSIC_CERTIFICADO.CTIPODOCUMENTO);
            db.AddInParameter(dbCommand, "pvcCODTIPOSOLI", DbType.String, entSIC_CERTIFICADO.CODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcTXTTIPOLLENADO", DbType.String, entSIC_CERTIFICADO.TXTTIPOLLENADO);
            db.AddInParameter(dbCommand, "pvcTXTDETALLE", DbType.String, entSIC_CERTIFICADO.TXTDETALLE);
            db.AddInParameter(dbCommand, "pvcCODOFICINA", DbType.String, entSIC_CERTIFICADO.CODOFICINA);
            db.AddInParameter(dbCommand, "pvcTXTSIGLA", DbType.String, entSIC_CERTIFICADO.TXTSIGLA);
            db.AddInParameter(dbCommand, "pvcCODCARCAT", DbType.String, entSIC_CERTIFICADO.CODCARCAT);
            db.AddInParameter(dbCommand, "pvcCODUSUASIS", DbType.String, entSIC_CERTIFICADO.CODUSUASIS);
            db.AddInParameter(dbCommand, "pvcCODPERSONA", DbType.String, entSIC_CERTIFICADO.CODPERSONA);
            db.AddInParameter(dbCommand, "pvcTXTUNIDAD", DbType.String, entSIC_CERTIFICADO.TXTUNIDAD);
            db.AddInParameter(dbCommand, "pvcTXTUNIDADDIREC", DbType.String, entSIC_CERTIFICADO.TXTUNIDADDIREC);
            db.AddInParameter(dbCommand, "pvcTXTCODIGOUNICO", DbType.String, entSIC_CERTIFICADO.TXTCODIGOUNICO);
            db.AddInParameter(dbCommand, "pvcTXTUNIDADTITULAR", DbType.String, entSIC_CERTIFICADO.TXTUNIDADTITULAR);
            db.AddInParameter(dbCommand, "pvcTXTSOLICITANTE", DbType.String, entSIC_CERTIFICADO.TXTSOLICITANTE);
            db.AddInParameter(dbCommand, "pvcTXTDIRECSOLIC", DbType.String, entSIC_CERTIFICADO.TXTDIRECSOLIC);
            db.AddInParameter(dbCommand, "pvcTXTCODTIPOSOLI", DbType.String, entSIC_CERTIFICADO.TXTCODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcTXTPARTIDA", DbType.String, entSIC_CERTIFICADO.TXTPARTIDA);
            db.AddInParameter(dbCommand, "pvcTXTMANZANAURB", DbType.String, entSIC_CERTIFICADO.TXTMANZANAURB);
            db.AddInParameter(dbCommand, "pvcTXTLOTEURB", DbType.String, entSIC_CERTIFICADO.TXTLOTEURB);
            db.AddInParameter(dbCommand, "pvcTXTSUBLOTEURB", DbType.String, entSIC_CERTIFICADO.TXTSUBLOTEURB);
            db.AddInParameter(dbCommand, "pvcTXTOBSERV", DbType.String, entSIC_CERTIFICADO.TXTOBSERV);
            db.AddInParameter(dbCommand, "pvcTXTNIVEL", DbType.String, entSIC_CERTIFICADO.TXTNIVEL);
            db.AddInParameter(dbCommand, "pvcTXTDESCRIPVIVIENDA", DbType.String, entSIC_CERTIFICADO.TXTDESCRIPVIVIENDA);
            db.AddInParameter(dbCommand, "pvcTXTINTERIOR", DbType.String, entSIC_CERTIFICADO.TXTINTERIOR);
            db.AddInParameter(dbCommand, "pvcCODPEREMISION", DbType.String, entSIC_CERTIFICADO.CODPEREMISION);

            db.AddInParameter(dbCommand, "pvcTXTCODHOJACATAS", DbType.String, entSIC_CERTIFICADO.TXTCODHOJACATAS);
            db.AddInParameter(dbCommand, "pvcFECCERTIFICADO", DbType.String, entSIC_CERTIFICADO.FECCERTIFICADO);
            db.AddInParameter(dbCommand, "pvcTXTASUNTOCERT", DbType.String, entSIC_CERTIFICADO.TXTASUNTOCERT);
            db.AddInParameter(dbCommand, "pvcTXTPLANOCATAS", DbType.String, entSIC_CERTIFICADO.TXTPLANOCATAS);
            db.AddInParameter(dbCommand, "pvcCODTIPINSC", DbType.String, entSIC_CERTIFICADO.CODTIPINSC);
            db.AddInParameter(dbCommand, "pvcTXTRECIBO", DbType.String, entSIC_CERTIFICADO.TXTRECIBO);
            db.AddInParameter(dbCommand, "pvcTXTURBANIZACION", DbType.String, entSIC_CERTIFICADO.TXTURBANIZACION);
            db.AddInParameter(dbCommand, "pvcTXTHOJAPLANO", DbType.String, entSIC_CERTIFICADO.TXTHOJAPLANO);
            db.AddInParameter(dbCommand, "pvcTXTESCAPLANO", DbType.String, entSIC_CERTIFICADO.TXTESCAPLANO);
            db.AddInParameter(dbCommand, "pvcNUMAREATECHCOM", DbType.String, entSIC_CERTIFICADO.NUMAREATECHCOM);
            db.AddInParameter(dbCommand, "pvcFECPAGO", DbType.DateTime, entSIC_CERTIFICADO.FECPAGO);
            db.AddInParameter(dbCommand, "pvcTXTCUC", DbType.String, entSIC_CERTIFICADO.TXTCUC);            

            db.AddInParameter(dbCommand, "pvcCODTRAMITE", DbType.String, entSIC_CERTIFICADO.CODTRAMITE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_CERTIFICADO.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddOutParameter(dbCommand, "pvcCODCERTIFICADO", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODCERTIFICADO"));
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
        //Creado por	: Pedro Peña Salazar (07/08/2018)
        //Utilizado por	: BusinessLogic.SIC_CERTIFICADO.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_CERTIFICADO
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_CERTIFICADO entSIC_CERTIFICADO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_CERTIFICADO.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODCERTIFICADO", DbType.String, entSIC_CERTIFICADO.CODCERTIFICADO);
            db.AddInParameter(dbCommand, "pvcCODTIPOCERTI", DbType.String, entSIC_CERTIFICADO.CODTIPOCERTI);
            db.AddInParameter(dbCommand, "pvcCODANOCERTI", DbType.String, entSIC_CERTIFICADO.CODANOCERTI);
            db.AddInParameter(dbCommand, "pvcCODANOSOLI", DbType.String, entSIC_CERTIFICADO.CODANOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNUMESOLI", DbType.String, entSIC_CERTIFICADO.CODNUMESOLI);
            db.AddInParameter(dbCommand, "pvcCTIPODOCUMENTO", DbType.String, entSIC_CERTIFICADO.CTIPODOCUMENTO);
            db.AddInParameter(dbCommand, "pvcCODTIPOSOLI", DbType.String, entSIC_CERTIFICADO.CODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcTXTTIPOLLENADO", DbType.String, entSIC_CERTIFICADO.TXTTIPOLLENADO);
            db.AddInParameter(dbCommand, "pvcTXTDETALLE", DbType.String, entSIC_CERTIFICADO.TXTDETALLE);
            db.AddInParameter(dbCommand, "pvcCODOFICINA", DbType.String, entSIC_CERTIFICADO.CODOFICINA);
            db.AddInParameter(dbCommand, "pvcTXTSIGLA", DbType.String, entSIC_CERTIFICADO.TXTSIGLA);
            db.AddInParameter(dbCommand, "pvcCODCARCAT", DbType.String, entSIC_CERTIFICADO.CODCARCAT);
            db.AddInParameter(dbCommand, "pvcCODUSUASIS", DbType.String, entSIC_CERTIFICADO.CODUSUASIS);
            db.AddInParameter(dbCommand, "pvcCODPERSONA", DbType.String, entSIC_CERTIFICADO.CODPERSONA);
            db.AddInParameter(dbCommand, "pvcTXTUNIDAD", DbType.String, entSIC_CERTIFICADO.TXTUNIDAD);
            db.AddInParameter(dbCommand, "pvcTXTUNIDADDIREC", DbType.String, entSIC_CERTIFICADO.TXTUNIDADDIREC);
            db.AddInParameter(dbCommand, "pvcTXTCODIGOUNICO", DbType.String, entSIC_CERTIFICADO.TXTCODIGOUNICO);
            db.AddInParameter(dbCommand, "pvcTXTUNIDADTITULAR", DbType.String, entSIC_CERTIFICADO.TXTUNIDADTITULAR);
            db.AddInParameter(dbCommand, "pvcTXTSOLICITANTE", DbType.String, entSIC_CERTIFICADO.TXTSOLICITANTE);
            db.AddInParameter(dbCommand, "pvcTXTDIRECSOLIC", DbType.String, entSIC_CERTIFICADO.TXTDIRECSOLIC);
            db.AddInParameter(dbCommand, "pvcTXTCODTIPOSOLI", DbType.String, entSIC_CERTIFICADO.TXTCODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcTXTPARTIDA", DbType.String, entSIC_CERTIFICADO.TXTPARTIDA);
            db.AddInParameter(dbCommand, "pvcTXTMANZANAURB", DbType.String, entSIC_CERTIFICADO.TXTMANZANAURB);
            db.AddInParameter(dbCommand, "pvcTXTLOTEURB", DbType.String, entSIC_CERTIFICADO.TXTLOTEURB);
            db.AddInParameter(dbCommand, "pvcTXTSUBLOTEURB", DbType.String, entSIC_CERTIFICADO.TXTSUBLOTEURB);
            db.AddInParameter(dbCommand, "pvcTXTOBSERV", DbType.String, entSIC_CERTIFICADO.TXTOBSERV);
            db.AddInParameter(dbCommand, "pvcTXTNIVEL", DbType.String, entSIC_CERTIFICADO.TXTNIVEL);
            db.AddInParameter(dbCommand, "pvcTXTDESCRIPVIVIENDA", DbType.String, entSIC_CERTIFICADO.TXTDESCRIPVIVIENDA);
            db.AddInParameter(dbCommand, "pvcTXTINTERIOR", DbType.StringFixedLength, entSIC_CERTIFICADO.TXTINTERIOR);
            db.AddInParameter(dbCommand, "pvcCODPEREMISION", DbType.String, entSIC_CERTIFICADO.CODPEREMISION);
            db.AddInParameter(dbCommand, "pvcFECPAGO", DbType.DateTime, entSIC_CERTIFICADO.FECPAGO);

            db.AddInParameter(dbCommand, "pvcTXTCUC", DbType.String, entSIC_CERTIFICADO.TXTCUC);
            db.AddInParameter(dbCommand, "pvcTXTCODHOJACATAS", DbType.String, entSIC_CERTIFICADO.TXTCODHOJACATAS);
            db.AddInParameter(dbCommand, "pvcFECCERTIFICADO", DbType.DateTime, entSIC_CERTIFICADO.FECCERTIFICADO); // 
            db.AddInParameter(dbCommand, "pvcTXTASUNTOCERT", DbType.String, entSIC_CERTIFICADO.TXTASUNTOCERT);
            db.AddInParameter(dbCommand, "pvcTXTPLANOCATAS", DbType.String, entSIC_CERTIFICADO.TXTPLANOCATAS);
            db.AddInParameter(dbCommand, "pvcCODTIPINSC", DbType.String, entSIC_CERTIFICADO.CODTIPINSC);
            db.AddInParameter(dbCommand, "pvcTXTRECIBO", DbType.String, entSIC_CERTIFICADO.TXTRECIBO);
            db.AddInParameter(dbCommand, "pvcTXTURBANIZACION", DbType.String, entSIC_CERTIFICADO.TXTURBANIZACION);
            db.AddInParameter(dbCommand, "pvcTXTHOJAPLANO", DbType.String, entSIC_CERTIFICADO.TXTHOJAPLANO);
            db.AddInParameter(dbCommand, "pvcTXTESCAPLANO", DbType.String, entSIC_CERTIFICADO.TXTESCAPLANO);
            db.AddInParameter(dbCommand, "pvcNUMAREATECHCOM", DbType.Decimal, entSIC_CERTIFICADO.NUMAREATECHCOM); // 
            db.AddInParameter(dbCommand, "pvcTXTRUTAIMAGEN", DbType.String, entSIC_CERTIFICADO.TXTRUTAIMAGEN);


            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_CERTIFICADO.CODUSUARIO);
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
        public BE.SIC_RETORNO Eliminar(BE.SIC_CERTIFICADO entSIC_CERTIFICADO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_CERTIFICADO.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODCERTIFICADO", DbType.String, entSIC_CERTIFICADO.CODCERTIFICADO);
            db.AddInParameter(dbCommand, "pvcCODTIPOCERTI", DbType.String, entSIC_CERTIFICADO.CODTIPOCERTI);
            db.AddInParameter(dbCommand, "pvcCODANOCERTI", DbType.String, entSIC_CERTIFICADO.CODANOCERTI);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_CERTIFICADO.CODUSUARIO);
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
        //Creado por	: Pedro Peña Salazar (07/08/2018)
        //Utilizado por	: BusinessLogic.SIC_CERTIFICADO.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_CERTIFICADO
        /// </summary>
        public BE.SIC_CERTIFICADO Recuperar(BE.SIC_CERTIFICADO entSIC_CERTIFICADO)
        {
            BE.SIC_CERTIFICADO lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_CERTIFICADO.PRC_DATOS", new object[4]);
            db.SetParameterValue(dbCommand, "pvcCODCERTIFICADO", entSIC_CERTIFICADO.CODCERTIFICADO);
            db.SetParameterValue(dbCommand, "pvcCODTIPOCERTI", entSIC_CERTIFICADO.CODTIPOCERTI);
            db.SetParameterValue(dbCommand, "pvcCODANOCERTI", entSIC_CERTIFICADO.CODANOCERTI);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_CERTIFICADO(reader, BE.SIC_CERTIFICADO.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }

        public BE.SIC_CERTIFICADO RecuperarUrbanizacion(BE.SIC_CERTIFICADO entSIC_CERTIFICADO)
        {
            BE.SIC_CERTIFICADO lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_CERTIFICADO.PRC_DATOS_URBA", new object[2]);
            db.SetParameterValue(dbCommand, "pvcTXTUNIDAD", entSIC_CERTIFICADO.TXTUNIDAD);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_CERTIFICADO(reader, BE.SIC_CERTIFICADO.Query.Urbanizacion);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (12/09/2018)
        //Utilizado por	: REPORTS.ASPX
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE HOJA INFORMATIVA (DATOS GENERICOS)
        /// </summary>
        public DataSet DatosGenerico(DataSet dtSubGen, string CodigoCertificado, string CodigoAnhoCertificado, string CodigoTipoCertificado)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REP_CERTIFICADO.PRC_DATOSGEN_HINF", new object[4]);

            db.SetParameterValue(dbCommand, "pvcCODCERTIFICADO", CodigoCertificado);
            db.SetParameterValue(dbCommand, "pvcCODANOCERTI", CodigoAnhoCertificado);
            db.SetParameterValue(dbCommand, "pvcCODTIPOCERTI", CodigoTipoCertificado);
 
            try
            {
                dtSubGen = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtSubGen;
        }

        public DataSet RecuperarFoto(DataSet foto, string CodLote)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSIACU.PKGACU_FOTO.PS_FOTOPRINCIPAL_MSISIC", new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODLOTECATASTRAL", CodLote);
            try
            {
                foto = db.ExecuteDataSet(dbCommand);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return foto;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (12/09/2018)
        //Utilizado por	: REPORTS.ASPX
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE HOJA INFORMATIVA (DATOS titulares)
        /// </summary>
        public DataSet DatosHojaTit(DataSet dtSubHojaTit, string CodigoCertificado, string CodigoAnhoCertificado, string CodigoTipoCertificado, string masDe3)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REP_CERTIFICADO.PRC_DATOSTIT_HINF", new object[5]);

            db.SetParameterValue(dbCommand, "pvcCODCERTIFICADO", CodigoCertificado);
            db.SetParameterValue(dbCommand, "pvcCODANOCERTI", CodigoAnhoCertificado);
            db.SetParameterValue(dbCommand, "pvcCODTIPOCERTI", CodigoTipoCertificado);
            db.SetParameterValue(dbCommand, "pvcMASDE3", masDe3);

            try
            {
                dtSubHojaTit = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtSubHojaTit;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (12/09/2018)
        //Utilizado por	: REPORTS.ASPX
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE HOJA INFORMATIVA (DATOS COLINDANTES)
        /// </summary>
        public DataSet DatosHojaLind(DataSet dtSubHojaLind, string CodigoCertificado, string CodigoAnhoCertificado, string CodigoTipoCertificado, string masDe4)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REP_CERTIFICADO.PRC_DATOSLIND_HINF", new object[5]);

            db.SetParameterValue(dbCommand, "pvcCODCERTIFICADO", CodigoCertificado);
            db.SetParameterValue(dbCommand, "pvcCODANOCERTI", CodigoAnhoCertificado);
            db.SetParameterValue(dbCommand, "pvcCODTIPOCERTI", CodigoTipoCertificado);
            db.SetParameterValue(dbCommand, "pvcMASDE4", masDe4);

            try
            {
                dtSubHojaLind = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtSubHojaLind;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Quispe (12/09/2018)
        //Utilizado por	: REPORTS.ASPX6
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE HOJA INFORMATIVA (DATOS GENERICOS)
        /// </summary>
        public DataSet DatosRecuperardt(DataSet dtSubGen, string CodigoCertificado, string CodigoAnhoCertificado, string CodigoTipoCertificado)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REP_CERTIFICADO.PRC_DATOS", new object[4]);

            db.SetParameterValue(dbCommand, "pvcCODCERTIFICADO", CodigoCertificado);
            db.SetParameterValue(dbCommand, "pvcCODANOCERTI", CodigoAnhoCertificado);
            db.SetParameterValue(dbCommand, "pvcCODTIPOCERTI", CodigoTipoCertificado);

            try
            {
                dtSubGen = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtSubGen;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Quispe (12/09/2018)
        //Utilizado por	: REPORTS.ASPX
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE HOJA INFORMATIVA (DATOS GENERICOS)
        /// </summary>
        public DataSet ListarUrbanizaciondt(DataSet dtSubGen, string CodigoCertificado, string CodigoAnhoCertificado, string CodigoTipoCertificado)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REP_CERTIFICADO.PRC_LISTA_URBANIZACION", new object[4]);

            db.SetParameterValue(dbCommand, "pvcCODCERTIFICADO", CodigoCertificado);
            db.SetParameterValue(dbCommand, "pvcCODANOCERTI", CodigoAnhoCertificado);
            db.SetParameterValue(dbCommand, "pvcCODTIPOCERTI", CodigoTipoCertificado);

            try
            {
                dtSubGen = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtSubGen;
        }
        public DataSet ListarRecibosCertificadosdt(DataSet dtSubGen, string CodigoCertificado, string CodigoAnhoCertificado, string CodigoTipoCertificado)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REP_CERTIFICADO.PRC_LISTA_RECIBOS", new object[4]);

            db.SetParameterValue(dbCommand, "pvcCODCERTIFICADO", CodigoCertificado);
            db.SetParameterValue(dbCommand, "pvcCODANOCERTI", CodigoAnhoCertificado);
            db.SetParameterValue(dbCommand, "pvcCODTIPOCERTI", CodigoTipoCertificado);

            try
            {
                dtSubGen = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtSubGen;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Quispe (12/09/2018)
        //Utilizado por	: REPORTS.ASPX
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE HOJA INFORMATIVA (DATOS GENERICOS)
        /// </summary>
        public DataSet ListarAnotaciondt(DataSet dtSubGen, string CodigoCertificado, string CodigoAnhoCertificado, string CodigoTipoCertificado)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REP_CERTIFICADO.PRC_LISTA_ANOTACION", new object[4]);

            db.SetParameterValue(dbCommand, "pvcCODCERTIFICADO", CodigoCertificado);
            db.SetParameterValue(dbCommand, "pvcCODANOCERTI", CodigoAnhoCertificado);
            db.SetParameterValue(dbCommand, "pvcCODTIPOCERTI", CodigoTipoCertificado);

            try
            {
                dtSubGen = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtSubGen;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (14/09/2018)
        //Utilizado por	: REPORTS.ASPX
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE CERTIFICADO DE ACUMULACION (DATOS GENERICOS)
        /// </summary>
        public DataSet DatosGenericoAcum(DataSet dtSubGen, string CodigoCertificado, string CodigoAnhoCertificado, string CodigoTipoCertificado)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REP_CERTIFICADO.PRC_DATOSGEN_ACUM", new object[4]);

            db.SetParameterValue(dbCommand, "pvcCODCERTIFICADO", CodigoCertificado);
            db.SetParameterValue(dbCommand, "pvcCODANOCERTI", CodigoAnhoCertificado);
            db.SetParameterValue(dbCommand, "pvcCODTIPOCERTI", CodigoTipoCertificado);

            try
            {
                dtSubGen = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtSubGen;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (18/09/2018)
        //Utilizado por	: REPORTS.ASPX
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE CERTIFICADO DE ACUMULACION (DATOS TITULARES)
        /// </summary>
        public DataSet DatosTituAcum(DataSet dtSubTit, string CodigoCertificado, string CodigoAnhoCertificado, string CodigoTipoCertificado, string masde3)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REP_CERTIFICADO.PRC_DATOSTIT_ACUM", new object[5]);

            db.SetParameterValue(dbCommand, "pvcCODCERTIFICADO", CodigoCertificado);
            db.SetParameterValue(dbCommand, "pvcCODANOCERTI", CodigoAnhoCertificado);
            db.SetParameterValue(dbCommand, "pvcCODTIPOCERTI", CodigoTipoCertificado);
            db.SetParameterValue(dbCommand, "pvcMASDE3", masde3);

            try
            {
                dtSubTit = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtSubTit;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (18/09/2018)
        //Utilizado por	: REPORTS.ASPX
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE CERTIFICADO DE ACUMULACION (DATOS DOCUMENTOS)
        /// </summary>
        public DataSet DatosDocAcum(DataSet dtSubDoc, string CodigoCertificado, string CodigoAnhoCertificado, string CodigoTipoCertificado, string masde6)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REP_CERTIFICADO.PRC_DATOSDOC_ACUM", new object[5]);

            db.SetParameterValue(dbCommand, "pvcCODCERTIFICADO", CodigoCertificado);
            db.SetParameterValue(dbCommand, "pvcCODANOCERTI", CodigoAnhoCertificado);
            db.SetParameterValue(dbCommand, "pvcCODTIPOCERTI", CodigoTipoCertificado);
            db.SetParameterValue(dbCommand, "pvcMASDE6", masde6);

            try
            {
                dtSubDoc = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtSubDoc;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (18/09/2018)
        //Utilizado por	: REPORTS.ASPX
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE CERTIFICADO DE ACUMULACION (DATOS OBSV)
        /// </summary>
        public DataSet DatosObsAcum(DataSet dtSubObs, string CodigoCertificado, string CodigoAnhoCertificado, string CodigoTipoCertificado, string masde4)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REP_CERTIFICADO.PRC_DATOSOBS_ACUM", new object[5]);

            db.SetParameterValue(dbCommand, "pvcCODCERTIFICADO", CodigoCertificado);
            db.SetParameterValue(dbCommand, "pvcCODANOCERTI", CodigoAnhoCertificado);
            db.SetParameterValue(dbCommand, "pvcCODTIPOCERTI", CodigoTipoCertificado);
            db.SetParameterValue(dbCommand, "pvcMASDE4", masde4);

            try
            {
                dtSubObs = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtSubObs;
        }
        public IEnumerable<BE.SIC_CERTIFICADO> CargarGrillaCertificados(BE.SIC_CERTIFICADO entSIC_SOLISEGUI)
        {
            List<BE.SIC_CERTIFICADO> lista = new List<BE.SIC_CERTIFICADO>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_CERTIFICADO.PCR_LISTA_CERTIFICADOS", new object[8]);
            db.SetParameterValue(dbCommand, "pvcCODTIPOCERTIFICADO", entSIC_SOLISEGUI.CODTIPOCERTI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_SOLISEGUI.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPODOC", entSIC_SOLISEGUI.CTIPODOCUMENTO);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_SOLISEGUI.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcFECINICIO", entSIC_SOLISEGUI.FECINICIO);
            db.SetParameterValue(dbCommand, "pvcFECFIN", entSIC_SOLISEGUI.FECFIN);
            db.SetParameterValue(dbCommand, "pvcCODIGOCATASTRAL", entSIC_SOLISEGUI.TXTCODIGOCATASTRAL);
            



            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_CERTIFICADO(reader, BE.SIC_CERTIFICADO.Query.ListarConsultaCertificado));
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
