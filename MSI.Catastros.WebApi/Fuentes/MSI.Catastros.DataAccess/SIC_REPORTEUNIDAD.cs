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
    public class SIC_REPORTE_UNIDAD : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (24/07/2018)
        //Utilizado por	: Reports.aspx
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE DE UNIDAD (Cabecera)
        /// </summary>
        public DataSet DatosGenerico(DataSet gen, string codUnico)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPFICHAIND.PRC_DATOSGEN_TMP", new object[2]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", codUnico);

            try
            {
                gen = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return gen;
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
        public DataSet RecuperarFotoEdificacion(DataSet foto, string CodLote,string CodEdificacion)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("MSIACU.PKGACU_FOTO.PS_FOTOPRINCIPALEDI", new object[3]);
            db.SetParameterValue(dbCommand, "pvcCODLOTECATASTRAL", CodLote);
            db.SetParameterValue(dbCommand, "pvcCODEDIFICACIONCATASTRAL", CodEdificacion);
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


        public DataSet DatosGenerico_est(DataSet gen, string codUnico)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPFICHAIND.PRC_DATOSGEN", new object[2]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", codUnico);

            try
            {
                gen = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return gen;
        }
        public DataSet DatosIntTemp(DataSet inttemp, String codUnico)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPFICHAIND.PRC_DATOS_DIRECCIONINTTP_TMP", new object[2]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", codUnico);

            try
            {
                inttemp = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return inttemp;
        }

        public DataSet DatosIntTemp_est(DataSet inttemp, String codUnico)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPFICHAIND.PRC_DATOS_DIRECCIONINTTP", new object[2]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", codUnico);

            try
            {
                inttemp = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return inttemp;
        }

        public DataSet DatosIntAsig(DataSet intasig, String codUnico)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPFICHAIND.PRC_DATOS_DIRECINTASIG_TMP", new object[2]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", codUnico);

            try
            {
                intasig = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return intasig;
        }

        public DataSet DatosIntAsig_est(DataSet intasig, String codUnico)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPFICHAIND.PRC_DATOS_DIRECINTASIG", new object[2]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", codUnico);

            try
            {
                intasig = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return intasig;
        }


        public DataSet DatosQuintaLind(DataSet quintaL, String codUnico)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPFICHAIND.PRC_DATOQUINTALINDEROS_TMP", new object[2]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", codUnico);

            try
            {
                quintaL = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return quintaL;
        }

        public DataSet DatosQuintaLind_est(DataSet quintaL, String codUnico)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPFICHAIND.PRC_DATOQUINTALINDEROS", new object[2]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", codUnico);

            try
            {
                quintaL = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return quintaL;
        }


        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (24/07/2018)
        //Utilizado por	: Reports.aspx
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE DE UNIDAD (NUMERACION MUNICIPAL)
        /// </summary>
        public DataSet DatosNumMun(DataSet numMun,String codUnico, String codAsig)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPFICHAIND.PRC_DATOS_DIRECCION_TMP", new object[3]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", codUnico);
            db.SetParameterValue(dbCommand, "pvcCODTIPASIG", codAsig);

            try
            {
                numMun = db.ExecuteDataSet(dbCommand);
               
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return numMun;
        }

        public DataSet DatosNumMun_est(DataSet numMun, String codUnico, String codAsig)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPFICHAIND.PRC_DATOS_DIRECCION", new object[3]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", codUnico);
            db.SetParameterValue(dbCommand, "pvcCODTIPASIG", codAsig);

            try
            {
                numMun = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return numMun;
        }


        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (24/07/2018)
        //Utilizado por	: Reports.aspx
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE DE UNIDAD (NUMERACION DE CAMPO)
        /// </summary>
        public DataSet DatoNumCampo(DataSet numCampo, String codUnico, String codAsig)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPFICHAIND.PRC_DATOS_DIRECCION_TMP", new object[3]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", codUnico);
            db.SetParameterValue(dbCommand, "pvcCODTIPASIG", codAsig);

            try
            {
                numCampo = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return numCampo;
        }

        public DataSet DatoNumCampo_est(DataSet numCampo, String codUnico, String codAsig)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPFICHAIND.PRC_DATOS_DIRECCION", new object[3]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", codUnico);
            db.SetParameterValue(dbCommand, "pvcCODTIPASIG", codAsig);

            try
            {
                numCampo = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return numCampo;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (24/07/2018)
        //Utilizado por	: Reports.aspx
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE DE UNIDAD(CONSTRUCCIONES)
        /// </summary>
        public DataSet Construcc(DataSet construcc, String codUnico)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPFICHAIND.PRC_DATOS_LINECONS_TMP", new object[2]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", codUnico);

            try
            {
                construcc = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return construcc;
        }

        public DataSet Construcc_est(DataSet construcc, String codUnico)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPFICHAIND.PRC_DATOS_LINECONS", new object[2]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", codUnico);

            try
            {
                construcc = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return construcc;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (24/07/2018)
        //Utilizado por	: Reports.aspx
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE DE UNIDAD (OTRAS INSTALACIONES)
        /// </summary>
        public DataSet OtrasInstalac(DataSet otrasInstalac, String codUnico)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPFICHAIND.PRC_DATOS_OTRAINST_TMP", new object[2]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", codUnico);

            try
            {
                otrasInstalac = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return otrasInstalac;
        }

        public DataSet OtrasInstalac_est(DataSet otrasInstalac, String codUnico)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPFICHAIND.PRC_DATOS_OTRAINST", new object[2]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", codUnico);

            try
            {
                otrasInstalac = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return otrasInstalac;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (24/07/2018)
        //Utilizado por	: Reports.aspx
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE DE UNIDAD (Titular Catastral)
        /// </summary>
        public DataSet TitularCatas(DataSet titularCatas, String codUnico)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPFICHAIND.PRC_DATOS_TITULAR_TMP", new object[2]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", codUnico);

            try
            {
                titularCatas = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return titularCatas;
        }

        public DataSet TitularCatas_est(DataSet titularCatas, String codUnico)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPFICHAIND.PRC_DATOS_TITULAR", new object[2]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", codUnico);

            try
            {
                titularCatas = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return titularCatas;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (24/07/2018)
        //Utilizado por	: Reports.aspx
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE DE UNIDAD (Documentos RRPP)
        /// </summary>
        public DataSet DocumentosRRPP(DataSet documentosRRPP, String codUnico)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPFICHAIND.PRC_DATOS_DOCRRPP_TMP", new object[2]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", codUnico);

            try
            {
                documentosRRPP = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return documentosRRPP;
        }

        public DataSet DocumentosRRPP_est(DataSet documentosRRPP, String codUnico)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPFICHAIND.PRC_DATOS_DOCRRPP", new object[2]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", codUnico);

            try
            {
                documentosRRPP = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return documentosRRPP;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (24/07/2018)
        //Utilizado por	: Reports.aspx
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE DE UNIDAD (Documentos Tramitados)
        /// </summary>
        public DataSet DocumentosTramita(DataSet documentosTramita, String codUnico)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPFICHAIND.PRC_DATOS_DOCTRAMITADOS_TMP", new object[2]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", codUnico);

            try
            {
                documentosTramita = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return documentosTramita;
        }

        public DataSet DocumentosTramita_est(DataSet documentosTramita, String codUnico)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPFICHAIND.PRC_DATOS_DOCTRAMITADOS", new object[2]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", codUnico);

            try
            {
                documentosTramita = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return documentosTramita;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (24/07/2018)
        //Utilizado por	: Reports.aspx
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE DE UNIDAD (Obras Privadas)
        /// </summary>
        public DataSet ObrasPrivadas(DataSet obrasPriv, String codUnico)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPFICHAIND.PRC_DATOS_DOCOBRPRIV_TMP", new object[2]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", codUnico);

            try
            {
                obrasPriv = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return obrasPriv;
        }

        public DataSet ObrasPrivadas_est(DataSet obrasPriv, String codUnico)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPFICHAIND.PRC_DATOS_DOCOBRPRIV", new object[2]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", codUnico);

            try
            {
                obrasPriv = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return obrasPriv;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (24/07/2018)
        //Utilizado por	: Reports.aspx
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE DE UNIDAD (Licencia de Funcionamiento)
        /// </summary>
        public DataSet LicenciaFunc(DataSet licFunc, String codUnico)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPFICHAIND.PRC_DATOS_DOCLICFUNC_TMP", new object[2]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", codUnico);

            try
            {
                licFunc = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return licFunc;
        }

        public DataSet LicenciaFunc_est(DataSet licFunc, String codUnico)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPFICHAIND.PRC_DATOS_DOCLICFUNC", new object[2]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", codUnico);

            try
            {
                licFunc = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return licFunc;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (24/07/2018)
        //Utilizado por	: Reports.aspx
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE DE UNIDAD (Actividad Economica)
        /// </summary>
        public DataSet ActividadEcono(DataSet actEconom, String codUnico)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPFICHAIND.PRC_DATOS_ACTECO_TMP", new object[2]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", codUnico);

            try
            {
                actEconom = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return actEconom;
        }

        public DataSet ActividadEcono_est(DataSet actEconom, String codUnico)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPFICHAIND.PRC_DATOS_ACTECO", new object[2]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", codUnico);

            try
            {
                actEconom = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return actEconom;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (24/07/2018)
        //Utilizado por	: Reports.aspx
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE DE UNIDAD (Observaciones Gen)
        /// </summary>
        public DataSet ObservacionesGen(DataSet obsGen, String codUnico, String tipObs)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPFICHAIND.PRC_DATOOBSERV_TMP", new object[3]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", codUnico);
            db.SetParameterValue(dbCommand, "pvcTIPOBSERVA", tipObs);

            try
            {
                obsGen = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return obsGen;
        }

        public DataSet ObservacionesGen_est(DataSet obsGen, String codUnico, String tipObs)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPFICHAIND.PRC_DATOOBSERV", new object[3]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", codUnico);
            db.SetParameterValue(dbCommand, "pvcTIPOBSERVA", tipObs);

            try
            {
                obsGen = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return obsGen;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (24/07/2018)
        //Utilizado por	: Reports.aspx
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE DE UNIDAD (Observaciones Cargas en Sunarp)
        /// </summary>
        public DataSet ObservacionesCargas(DataSet obsCarg, String codUnico, String tipObs)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPFICHAIND.PRC_DATOOBSERV_TMP", new object[3]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", codUnico);
            db.SetParameterValue(dbCommand, "pvcTIPOBSERVA", tipObs);

            try
            {
                obsCarg = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return obsCarg;
        }

        public DataSet ObservacionesCargas_est(DataSet obsCarg, String codUnico, String tipObs)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPFICHAIND.PRC_DATOOBSERV", new object[3]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", codUnico);
            db.SetParameterValue(dbCommand, "pvcTIPOBSERVA", tipObs);

            try
            {
                obsCarg = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return obsCarg;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (24/07/2018)
        //Utilizado por	: Reports.aspx
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE DE UNIDAD (Observaciones Respecto a Carga)
        /// </summary>
        public DataSet ObservacionesRespecto(DataSet obsRespectCarg, String codUnico, String tipObs)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPFICHAIND.PRC_DATOOBSERV_TMP", new object[3]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", codUnico);
            db.SetParameterValue(dbCommand, "pvcTIPOBSERVA", tipObs);

            try
            {
                obsRespectCarg = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return obsRespectCarg;
        }

        public DataSet ObservacionesRespecto_est(DataSet obsRespectCarg, String codUnico, String tipObs)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPFICHAIND.PRC_DATOOBSERV", new object[3]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", codUnico);
            db.SetParameterValue(dbCommand, "pvcTIPOBSERVA", tipObs);

            try
            {
                obsRespectCarg = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return obsRespectCarg;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (24/07/2018)
        //Utilizado por	: Reports.aspx
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE DE BIENCOMUN (LINDEROS)
        /// </summary>
        public DataSet DatosLinderos(DataSet uniLinderos, String codUnico)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REP_BCOMUNES.PRC_DATOLINDEROS_TMP", new object[2]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", codUnico);
           
            try
            {
                uniLinderos = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return uniLinderos;
        }

        public DataSet DatosLinderos_est(DataSet uniLinderos, String codUnico)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REP_BCOMUNES.PRC_DATOLINDEROS", new object[2]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", codUnico);

            try
            {
                uniLinderos = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return uniLinderos;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (04/09/2018)
        //Utilizado por	: Reports.aspx
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE DE BIENCOMUN (RECAP DE BIENES COMUNES)
        /// </summary>
        public DataSet DatosRecapBC(DataSet recap, String codUnico)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REP_BCOMUNES.PRC_DATORECAPBCOM_TMP", new object[2]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", codUnico);

            try
            {
                recap = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return recap;
        }

        public DataSet DatosRecapBC_est(DataSet recap, String codUnico)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REP_BCOMUNES.PRC_DATORECAPBCOM", new object[2]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", codUnico);

            try
            {
                recap = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return recap;
        }

       
    }
}
