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
    public class SIC_INFORME : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (08/08/2018)
        //Utilizado por	: BusinessLogic.SIC_INFORME.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_INFORME
        /// </summary>
        public IEnumerable<BE.SIC_INFORME> Buscar(BE.SIC_INFORME entSIC_INFORME)
        {
            List<BE.SIC_INFORME> lista = new List<BE.SIC_INFORME>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_INFORME.PRC_BUSCAR", new object[8]);
            db.SetParameterValue(dbCommand, "pvcCODINFORME", entSIC_INFORME.CODINFORME);
            db.SetParameterValue(dbCommand, "pvcCODANOINFO", entSIC_INFORME.CODANOINFO);
            db.SetParameterValue(dbCommand, "pvcCODTIPOINFOR", entSIC_INFORME.CODTIPOINFOR);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_INFORME.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_INFORME.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_INFORME.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCTIPODOCUMENTO", entSIC_INFORME.CTIPODOCUMENTO);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_INFORME(reader, BE.SIC_INFORME.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public IEnumerable<BE.SIC_INFORME> BuscarInformes(BE.SIC_INFORME entSIC_INFORME)
        {
            List<BE.SIC_INFORME> lista = new List<BE.SIC_INFORME>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_INFORME.PRC_BUSCAR_INFORME", new object[8]);
            db.SetParameterValue(dbCommand, "pvcCODINFORME", entSIC_INFORME.CODINFORME);
            db.SetParameterValue(dbCommand, "pvcCODANOINFO", entSIC_INFORME.CODANOINFO);
            db.SetParameterValue(dbCommand, "pvcCODTIPOINFOR", entSIC_INFORME.CODTIPOINFOR);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_INFORME.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_INFORME.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_INFORME.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCTIPODOCUMENTO", entSIC_INFORME.CTIPODOCUMENTO);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_INFORME(reader, BE.SIC_INFORME.Query.ListarInforme));
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
        //Utilizado por	: BusinessLogic.SIC_INFORME.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_INFORME, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_INFORME entSIC_INFORME)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_INFORME.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcCODANOINFO", DbType.String, entSIC_INFORME.CODANOINFO);
            db.AddInParameter(dbCommand, "pvcCODTIPOSOLI", DbType.String, entSIC_INFORME.CODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcCODANOSOLI", DbType.String, entSIC_INFORME.CODANOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNUMESOLI", DbType.String, entSIC_INFORME.CODNUMESOLI);
            db.AddInParameter(dbCommand, "pvcCTIPODOCUMENTO", DbType.String, entSIC_INFORME.CTIPODOCUMENTO);
            db.AddInParameter(dbCommand, "pvcCODOFICINA", DbType.String, entSIC_INFORME.CODOFICINA);
            db.AddInParameter(dbCommand, "pvcTXTSIGLA", DbType.String, entSIC_INFORME.TXTSIGLA);
            db.AddInParameter(dbCommand, "pvcCODTIPOINFOR", DbType.String, entSIC_INFORME.CODTIPOINFOR);
            db.AddInParameter(dbCommand, "pvcCODCARCAT", DbType.String, entSIC_INFORME.CODCARCAT);
            db.AddInParameter(dbCommand, "pvcCODUSUASIS", DbType.String, entSIC_INFORME.CODUSUASIS);
            db.AddInParameter(dbCommand, "pvcCODPERSONA", DbType.String, entSIC_INFORME.CODPERSONA);
            db.AddInParameter(dbCommand, "pvcFECINSPECCION", DbType.DateTime, entSIC_INFORME.FECINSPECCION);
            db.AddInParameter(dbCommand, "pvcTXTTIPOLLENADO", DbType.String, entSIC_INFORME.TXTTIPOLLENADO);
            db.AddInParameter(dbCommand, "pvcTXTASUNTO", DbType.String, entSIC_INFORME.TXTASUNTO);
            db.AddInParameter(dbCommand, "pvcTXTUNIDAD", DbType.String, entSIC_INFORME.TXTUNIDAD);
            db.AddInParameter(dbCommand, "pvcTXTCODIGOUNICO", DbType.String, entSIC_INFORME.TXTCODIGOUNICO);
            db.AddInParameter(dbCommand, "pvcTXTUNIDADDIREC", DbType.String, entSIC_INFORME.TXTUNIDADDIREC);
            db.AddInParameter(dbCommand, "pvcTXTUNIDADTITULAR", DbType.String, entSIC_INFORME.TXTUNIDADTITULAR);
            db.AddInParameter(dbCommand, "pvcTXTSOLICITANTE", DbType.String, entSIC_INFORME.TXTSOLICITANTE);
            db.AddInParameter(dbCommand, "pvcTXTDESCRIPCIONINFORME", DbType.String, entSIC_INFORME.TXTDESCRIPCIONINFORME);
            db.AddInParameter(dbCommand, "pvcTXTOFICINA", DbType.String, entSIC_INFORME.TXTOFICINA);
            db.AddInParameter(dbCommand, "pvcTXTUNIDADES", DbType.String, entSIC_INFORME.TXTUNIDADES);
            db.AddInParameter(dbCommand, "pvcCODPEREMISION", DbType.String, entSIC_INFORME.CODPEREMISION);
            db.AddInParameter(dbCommand, "pvcCODTRAMITE", DbType.String, entSIC_INFORME.CODTRAMITE);            
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_INFORME.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddInParameter(dbCommand, "pvcCODINFORME", DbType.String, entSIC_INFORME.CODINFORME);
            db.AddOutParameter(dbCommand, "pvcCODCORRINFO", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODINFORME"));
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
        //Utilizado por	: BusinessLogic.SIC_INFORME.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_INFORME
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_INFORME entSIC_INFORME)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_INFORME.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODINFORME", DbType.String, entSIC_INFORME.CODINFORME);
            db.AddInParameter(dbCommand, "pvcCODCORRINFO", DbType.String, entSIC_INFORME.CODCORRINFO);
            db.AddInParameter(dbCommand, "pvcCODANOINFO", DbType.String, entSIC_INFORME.CODANOINFO);
            db.AddInParameter(dbCommand, "pvcCODTIPOSOLI", DbType.String, entSIC_INFORME.CODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcCODANOSOLI", DbType.String, entSIC_INFORME.CODANOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNUMESOLI", DbType.String, entSIC_INFORME.CODNUMESOLI);
            db.AddInParameter(dbCommand, "pvcCTIPODOCUMENTO", DbType.String, entSIC_INFORME.CTIPODOCUMENTO);
            db.AddInParameter(dbCommand, "pvcCODOFICINA", DbType.String, entSIC_INFORME.CODOFICINA);
            db.AddInParameter(dbCommand, "pvcTXTSIGLA", DbType.String, entSIC_INFORME.TXTSIGLA);
            db.AddInParameter(dbCommand, "pvcCODTIPOINFOR", DbType.String, entSIC_INFORME.CODTIPOINFOR);
            db.AddInParameter(dbCommand, "pvcCODCARCAT", DbType.String, entSIC_INFORME.CODCARCAT);
            db.AddInParameter(dbCommand, "pvcCODUSUASIS", DbType.String, entSIC_INFORME.CODUSUASIS);
            db.AddInParameter(dbCommand, "pvcCODPERSONA", DbType.String, entSIC_INFORME.CODPERSONA);
            db.AddInParameter(dbCommand, "pvcFECINSPECCION", DbType.DateTime, entSIC_INFORME.FECINSPECCION);
            db.AddInParameter(dbCommand, "pvcTXTTIPOLLENADO", DbType.String, entSIC_INFORME.TXTTIPOLLENADO);
            db.AddInParameter(dbCommand, "pvcTXTASUNTO", DbType.String, entSIC_INFORME.TXTASUNTO);
            db.AddInParameter(dbCommand, "pvcTXTUNIDAD", DbType.String, entSIC_INFORME.TXTUNIDAD);
            db.AddInParameter(dbCommand, "pvcTXTCODIGOUNICO", DbType.String, entSIC_INFORME.TXTCODIGOUNICO);
            db.AddInParameter(dbCommand, "pvcTXTUNIDADDIREC", DbType.String, entSIC_INFORME.TXTUNIDADDIREC);
            db.AddInParameter(dbCommand, "pvcTXTUNIDADTITULAR", DbType.String, entSIC_INFORME.TXTUNIDADTITULAR);
            db.AddInParameter(dbCommand, "pvcTXTSOLICITANTE", DbType.String, entSIC_INFORME.TXTSOLICITANTE);
            db.AddInParameter(dbCommand, "pvcTXTDESCRIPCIONINFORME", DbType.String, entSIC_INFORME.TXTDESCRIPCIONINFORME);
            db.AddInParameter(dbCommand, "pvcTXTOFICINA", DbType.String, entSIC_INFORME.TXTOFICINA);
            db.AddInParameter(dbCommand, "pvcTXTANIO", DbType.String, entSIC_INFORME.TXTANIO);
            db.AddInParameter(dbCommand, "pvcTXTNOMBREFIRMA", DbType.String, entSIC_INFORME.TXTNOMBREFIRMA);
            db.AddInParameter(dbCommand, "pvcTXTCARGOFIRMA", DbType.String, entSIC_INFORME.TXTCARGOFIRMA);
            db.AddInParameter(dbCommand, "pvcTXTUNIDADES", DbType.String, entSIC_INFORME.TXTUNIDADES);
            db.AddInParameter(dbCommand, "pvcCODPEREMISION", DbType.String, entSIC_INFORME.CODPEREMISION);
            db.AddInParameter(dbCommand, "pvcCODTRAMITE", DbType.String, entSIC_INFORME.CODTRAMITE);
            db.AddInParameter(dbCommand, "pvcCODDOCUMGEN", DbType.String, entSIC_INFORME.CODDOCUMGEN);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_INFORME.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddInParameter(dbCommand, "pvcNROCALIDADVERIFICACION", DbType.String, entSIC_INFORME.NROCALIDADVERIFICACION);           
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

        public BE.SIC_RETORNO Eliminar(BE.SIC_INFORME entSIC_INFORME)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_INFORME.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODINFORME", DbType.String, entSIC_INFORME.CODINFORME);
            db.AddInParameter(dbCommand, "pvcCODCORRINFO", DbType.String, entSIC_INFORME.CODCORRINFO);
            db.AddInParameter(dbCommand, "pvcCODANOINFO", DbType.String, entSIC_INFORME.CODANOINFO);
            db.AddInParameter(dbCommand, "pvcCODTIPOINFOR", DbType.String, entSIC_INFORME.CODTIPOINFOR);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_INFORME.CODUSUARIO);
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
        //Utilizado por	: BusinessLogic.SIC_INFORME.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_INFORME
        /// </summary>
        public BE.SIC_INFORME Recuperar(BE.SIC_INFORME entSIC_INFORME)
        {
            BE.SIC_INFORME lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_INFORME.PRC_DATOS", new object[5]);
            db.SetParameterValue(dbCommand, "pvcCODINFORME", entSIC_INFORME.CODINFORME);
            db.SetParameterValue(dbCommand, "pvcCODCORRINFO", entSIC_INFORME.CODCORRINFO);
            db.SetParameterValue(dbCommand, "pvcCODANOINFO", entSIC_INFORME.CODANOINFO);
            db.SetParameterValue(dbCommand, "pvcCODTIPOINFOR", entSIC_INFORME.CODTIPOINFOR);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_INFORME(reader, BE.SIC_INFORME.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        public BE.SIC_INFORME RecuperarNumeroRegistro(BE.SIC_INFORME entSIC_INFORME)
        {
            BE.SIC_INFORME lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_INFORME.PRC_TOTALDATOS", new object[5]);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_INFORME.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_INFORME.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODANOINFO", entSIC_INFORME.CODANOINFO);
            db.SetParameterValue(dbCommand, "pvcCODTIPOINFOR", entSIC_INFORME.CODTIPOINFOR);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_INFORME(reader, BE.SIC_INFORME.Query.Total);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Quispe Ipanaque (07/08/2018)
        //Utilizado por	: BusinessLogic.SIC_INFORME.DatosInforme
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un dataset de la tabla SIC_INFORME
        /// </summary>
        public DataSet DatosInforme(DataSet dtDatosInforme, string codigoInforme, string codigoAnio, string codigoTipoInforme, string CodigoCorrInforme)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_INFORME.PRC_DATOS", new object[5]);
            db.SetParameterValue(dbCommand, "pvcCODINFORME", codigoInforme);
            db.SetParameterValue(dbCommand, "pvcCODCORRINFO", CodigoCorrInforme);
            db.SetParameterValue(dbCommand, "pvcCODANOINFO", codigoAnio);
            db.SetParameterValue(dbCommand, "pvcCODTIPOINFOR", codigoTipoInforme);
            try
            {
                dtDatosInforme = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtDatosInforme;
        }

        public DataSet BuscarInformeVerificacionCatastral(DataSet dtSubGen,string codigoTipoInforme,string numeroInforme, string correlativoInforme, string codigoAnioInforme)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REP_INFORME.PRC_BUSCAR_INSPECCION", new object[5]);
            db.SetParameterValue(dbCommand, "pvcCODTIPOINF", codigoTipoInforme);
            db.SetParameterValue(dbCommand, "pvcNUMEROINF", numeroInforme);
            db.SetParameterValue(dbCommand, "pvcCORRELATIVOINF", correlativoInforme);
            db.SetParameterValue(dbCommand, "pvcCODANIO", codigoAnioInforme);
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
        
        public DataSet BuscarUnidadesInformeVerificacionCatastrak(DataSet dtSubGen, string codigoTipoInforme, string numeroInforme, string correlativoInforme, string codigoAnioInforme)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REP_INFORME.PRC_BUSCAR_UNIDADES_INF", new object[5]);
            db.SetParameterValue(dbCommand, "pvcCODTIPOINF", codigoTipoInforme);
            db.SetParameterValue(dbCommand, "pvcNUMEROINF", numeroInforme);
            db.SetParameterValue(dbCommand, "pvcCORRELATIVOINF", correlativoInforme);
            db.SetParameterValue(dbCommand, "pvcCODANIO", codigoAnioInforme);
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
        public DataSet BuscarDireccionInformeVerificacionCatastral(DataSet dtSubGen, string codigoTipoInforme, string numeroInforme, string correlativoInforme, string codigoAnioInforme)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REP_INFORME.PRC_BUSCAR_UBICACION_INF", new object[5]);
            db.SetParameterValue(dbCommand, "pvcCODTIPOINF", codigoTipoInforme);
            db.SetParameterValue(dbCommand, "pvcNUMEROINF", numeroInforme);
            db.SetParameterValue(dbCommand, "pvcCORRELATIVOINF", correlativoInforme);
            db.SetParameterValue(dbCommand, "pvcCODANIO", codigoAnioInforme);
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
    }
}
