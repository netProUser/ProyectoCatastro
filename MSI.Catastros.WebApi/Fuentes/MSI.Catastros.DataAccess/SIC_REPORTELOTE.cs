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
    public class SIC_REPORTE_LOTE : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (20/07/2018)
        //Utilizado por	: Reports.aspx
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE DE LOTE (Cabecera)
        /// </summary>
        public DataSet DatosGenerico(DataSet gen,string CodigoDistrito, string CodigoSector, string CodigoManzana, string CodigoLote)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPLOTE.PRC_DATOGEN_TMP", new object[7]);

            db.SetParameterValue(dbCommand, "PVCCODDEPARTAMENTO", "15");
            db.SetParameterValue(dbCommand, "PVCCODPROVINCIA", "01");
            db.SetParameterValue(dbCommand, "PVCCODDISTRITO", "31");
            db.SetParameterValue(dbCommand, "PVCCODSECTOR", CodigoSector);
            db.SetParameterValue(dbCommand, "PVCCODMANZANA", CodigoManzana);
            db.SetParameterValue(dbCommand, "PVCCODLOTE", CodigoLote);

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

        public DataSet DatosGenerico_est(DataSet gen, string CodigoDistrito, string CodigoSector, string CodigoManzana, string CodigoLote)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPLOTE.PRC_DATOGEN", new object[7]);

            db.SetParameterValue(dbCommand, "PVCCODDEPARTAMENTO", "15");
            db.SetParameterValue(dbCommand, "PVCCODPROVINCIA", "01");
            db.SetParameterValue(dbCommand, "PVCCODDISTRITO", "31");
            db.SetParameterValue(dbCommand, "PVCCODSECTOR", CodigoSector);
            db.SetParameterValue(dbCommand, "PVCCODMANZANA", CodigoManzana);
            db.SetParameterValue(dbCommand, "PVCCODLOTE", CodigoLote);

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
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (20/07/2018)
        //Utilizado por	: Reports.aspx
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE DE LOTE (ZONIFICACION)
        /// </summary>
        public DataSet DatosZonifLote(DataSet dtsubZonifLote, String codDist, String codSect, String codManz, String codLote)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPLOTE.PRC_DATOZONIFLOTE_TMP", new object[7]);

            db.SetParameterValue(dbCommand, "PVCCODDEPARTAMENTO", "15");
            db.SetParameterValue(dbCommand, "PVCCODPROVINCIA", "01");
            db.SetParameterValue(dbCommand, "PVCCODDISTRITO", codDist);
            db.SetParameterValue(dbCommand, "PVCCODSECTOR", codSect);
            db.SetParameterValue(dbCommand, "PVCCODMANZANA", codManz);
            db.SetParameterValue(dbCommand, "PVCCODLOTE", codLote);

            try
            {
                dtsubZonifLote = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtsubZonifLote;
        }

        public DataSet DatosZonifLote_est(DataSet dtsubZonifLote, String codDist, String codSect, String codManz, String codLote)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPLOTE.PRC_DATOZONIFLOTE", new object[7]);

            db.SetParameterValue(dbCommand, "PVCCODDEPARTAMENTO", "15");
            db.SetParameterValue(dbCommand, "PVCCODPROVINCIA", "01");
            db.SetParameterValue(dbCommand, "PVCCODDISTRITO", codDist);
            db.SetParameterValue(dbCommand, "PVCCODSECTOR", codSect);
            db.SetParameterValue(dbCommand, "PVCCODMANZANA", codManz);
            db.SetParameterValue(dbCommand, "PVCCODLOTE", codLote);

            try
            {
                dtsubZonifLote = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtsubZonifLote;
        }


        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (20/07/2018)
        //Utilizado por	: Reports.aspx
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE DE LOTE (Direccion)
        /// </summary>
        public DataSet DatosUbicCentrMuni(DataSet dtsubUbicEntrMuni,String codDist, String codSect, String codManz, String codLote)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPLOTE.PRC_DATOUBICENTRMUNI_TMP", new object[7]);
           
            db.SetParameterValue(dbCommand, "PVCCODDEPARTAMENTO", "15");
            db.SetParameterValue(dbCommand, "PVCCODPROVINCIA", "01");
            db.SetParameterValue(dbCommand, "PVCCODDISTRITO", codDist);
            db.SetParameterValue(dbCommand, "PVCCODSECTOR", codSect);
            db.SetParameterValue(dbCommand, "PVCCODMANZANA", codManz);
            db.SetParameterValue(dbCommand, "PVCCODLOTE", codLote);

            try
            {
                dtsubUbicEntrMuni = db.ExecuteDataSet(dbCommand);
               
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtsubUbicEntrMuni;
        }

        /// GENERA REPORTE DE LOTE (Direccion)
        /// </summary>
        public DataSet DatosUbicCentrMuni_est(DataSet dtsubUbicEntrMuni, String codDist, String codSect, String codManz, String codLote)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPLOTE.PRC_DATOUBICENTRMUNI", new object[7]);

            db.SetParameterValue(dbCommand, "PVCCODDEPARTAMENTO", "15");
            db.SetParameterValue(dbCommand, "PVCCODPROVINCIA", "01");
            db.SetParameterValue(dbCommand, "PVCCODDISTRITO", codDist);
            db.SetParameterValue(dbCommand, "PVCCODSECTOR", codSect);
            db.SetParameterValue(dbCommand, "PVCCODMANZANA", codManz);
            db.SetParameterValue(dbCommand, "PVCCODLOTE", codLote);

            try
            {
                dtsubUbicEntrMuni = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtsubUbicEntrMuni;
        }


        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (20/07/2018)
        //Utilizado por	: Reports.aspx
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE DE LOTE (Datos Norma Urbana)
        /// </summary>
        public DataSet DatoNormUrba(DataSet dtsubAltVias, String codDist, String codSect, String codManz, String codLote)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPLOTE.PRC_DATONORMURBA_TMP", new object[7]);

            db.SetParameterValue(dbCommand, "PVCCODDEPARTAMENTO", "15");
            db.SetParameterValue(dbCommand, "PVCCODPROVINCIA", "01");
            db.SetParameterValue(dbCommand, "PVCCODDISTRITO", codDist);
            db.SetParameterValue(dbCommand, "PVCCODSECTOR", codSect);
            db.SetParameterValue(dbCommand, "PVCCODMANZANA", codManz);
            db.SetParameterValue(dbCommand, "PVCCODLOTE", codLote);

            try
            {
                dtsubAltVias = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtsubAltVias;
        }

        public DataSet DatoNormUrba_est(DataSet dtsubAltVias, String codDist, String codSect, String codManz, String codLote)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPLOTE.PRC_DATONORMURBA", new object[7]);

            db.SetParameterValue(dbCommand, "PVCCODDEPARTAMENTO", "15");
            db.SetParameterValue(dbCommand, "PVCCODPROVINCIA", "01");
            db.SetParameterValue(dbCommand, "PVCCODDISTRITO", codDist);
            db.SetParameterValue(dbCommand, "PVCCODSECTOR", codSect);
            db.SetParameterValue(dbCommand, "PVCCODMANZANA", codManz);
            db.SetParameterValue(dbCommand, "PVCCODLOTE", codLote);

            try
            {
                dtsubAltVias = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtsubAltVias;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (20/07/2018)
        //Utilizado por	: Reports.aspx
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE DE LOTE (Datos del Predio)
        /// </summary>
        public DataSet DatosPredio(DataSet dtsubDatPred, String codDist, String codSect, String codManz, String codLote)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPLOTE.PRC_DATOLINDERO_TMP", new object[7]);

            db.SetParameterValue(dbCommand, "PVCCODDEPARTAMENTO", "15");
            db.SetParameterValue(dbCommand, "PVCCODPROVINCIA", "01");
            db.SetParameterValue(dbCommand, "PVCCODDISTRITO", codDist);
            db.SetParameterValue(dbCommand, "PVCCODSECTOR", codSect);
            db.SetParameterValue(dbCommand, "PVCCODMANZANA", codManz);
            db.SetParameterValue(dbCommand, "PVCCODLOTE", codLote);

            try
            {
                dtsubDatPred = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtsubDatPred;
        }

        public DataSet DatosPredio_est(DataSet dtsubDatPred, String codDist, String codSect, String codManz, String codLote)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPLOTE.PRC_DATOLINDERO", new object[7]);

            db.SetParameterValue(dbCommand, "PVCCODDEPARTAMENTO", "15");
            db.SetParameterValue(dbCommand, "PVCCODPROVINCIA", "01");
            db.SetParameterValue(dbCommand, "PVCCODDISTRITO", codDist);
            db.SetParameterValue(dbCommand, "PVCCODSECTOR", codSect);
            db.SetParameterValue(dbCommand, "PVCCODMANZANA", codManz);
            db.SetParameterValue(dbCommand, "PVCCODLOTE", codLote);

            try
            {
                dtsubDatPred = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtsubDatPred;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (20/07/2018)
        //Utilizado por	: Reports.aspx
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE DE LOTE (Retiro Municipal)
        /// </summary>
        public DataSet RetiroMunicipal(DataSet dtsubRetiro, String codDist, String codSect, String codManz, String codLote)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPLOTE.PRC_DATORETIMUNI_TMP", new object[7]);

            db.SetParameterValue(dbCommand, "PVCCODDEPARTAMENTO", "15");
            db.SetParameterValue(dbCommand, "PVCCODPROVINCIA", "01");
            db.SetParameterValue(dbCommand, "PVCCODDISTRITO", codDist);
            db.SetParameterValue(dbCommand, "PVCCODSECTOR", codSect);
            db.SetParameterValue(dbCommand, "PVCCODMANZANA", codManz);
            db.SetParameterValue(dbCommand, "PVCCODLOTE", codLote);

            try
            {
                dtsubRetiro = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtsubRetiro;
        }

        public DataSet RetiroMunicipal_est(DataSet dtsubRetiro, String codDist, String codSect, String codManz, String codLote)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPLOTE.PRC_DATORETIMUNI", new object[7]);

            db.SetParameterValue(dbCommand, "PVCCODDEPARTAMENTO", "15");
            db.SetParameterValue(dbCommand, "PVCCODPROVINCIA", "01");
            db.SetParameterValue(dbCommand, "PVCCODDISTRITO", codDist);
            db.SetParameterValue(dbCommand, "PVCCODSECTOR", codSect);
            db.SetParameterValue(dbCommand, "PVCCODMANZANA", codManz);
            db.SetParameterValue(dbCommand, "PVCCODLOTE", codLote);

            try
            {
                dtsubRetiro = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtsubRetiro;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (20/07/2018)
        //Utilizado por	: Reports.aspx
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE DE LOTE (Documentos RRPP)
        /// </summary>
        public DataSet DocumentosRRPP(DataSet dtsubDocRP, String codDist, String codSect, String codManz, String codLote)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPLOTE.PRC_DATODOCRRPP_TMP", new object[7]);

            db.SetParameterValue(dbCommand, "PVCCODDEPARTAMENTO", "15");
            db.SetParameterValue(dbCommand, "PVCCODPROVINCIA", "01");
            db.SetParameterValue(dbCommand, "PVCCODDISTRITO", codDist);
            db.SetParameterValue(dbCommand, "PVCCODSECTOR", codSect);
            db.SetParameterValue(dbCommand, "PVCCODMANZANA", codManz);
            db.SetParameterValue(dbCommand, "PVCCODLOTE", codLote);

            try
            {
                dtsubDocRP = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtsubDocRP;
        }

        public DataSet DocumentosRRPP_est(DataSet dtsubDocRP, String codDist, String codSect, String codManz, String codLote)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPLOTE.PRC_DATODOCRRPP", new object[7]);

            db.SetParameterValue(dbCommand, "PVCCODDEPARTAMENTO", "15");
            db.SetParameterValue(dbCommand, "PVCCODPROVINCIA", "01");
            db.SetParameterValue(dbCommand, "PVCCODDISTRITO", codDist);
            db.SetParameterValue(dbCommand, "PVCCODSECTOR", codSect);
            db.SetParameterValue(dbCommand, "PVCCODMANZANA", codManz);
            db.SetParameterValue(dbCommand, "PVCCODLOTE", codLote);

            try
            {
                dtsubDocRP = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtsubDocRP;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (20/07/2018)
        //Utilizado por	: Reports.aspx
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE DE LOTE (Obras Privadas)
        /// </summary>
        public DataSet ObrasPrivadas(DataSet dtsubObrasP, String codDist, String codSect, String codManz, String codLote)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPLOTE.PRC_DATODOCOBRASPRIV_TMP", new object[7]);

            db.SetParameterValue(dbCommand, "PVCCODDEPARTAMENTO", "15");
            db.SetParameterValue(dbCommand, "PVCCODPROVINCIA", "01");
            db.SetParameterValue(dbCommand, "PVCCODDISTRITO", codDist);
            db.SetParameterValue(dbCommand, "PVCCODSECTOR", codSect);
            db.SetParameterValue(dbCommand, "PVCCODMANZANA", codManz);
            db.SetParameterValue(dbCommand, "PVCCODLOTE", codLote);

            try
            {
                dtsubObrasP = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtsubObrasP;
        }

        public DataSet ObrasPrivadas_est(DataSet dtsubObrasP, String codDist, String codSect, String codManz, String codLote)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPLOTE.PRC_DATODOCOBRASPRIV", new object[7]);

            db.SetParameterValue(dbCommand, "PVCCODDEPARTAMENTO", "15");
            db.SetParameterValue(dbCommand, "PVCCODPROVINCIA", "01");
            db.SetParameterValue(dbCommand, "PVCCODDISTRITO", codDist);
            db.SetParameterValue(dbCommand, "PVCCODSECTOR", codSect);
            db.SetParameterValue(dbCommand, "PVCCODMANZANA", codManz);
            db.SetParameterValue(dbCommand, "PVCCODLOTE", codLote);

            try
            {
                dtsubObrasP = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtsubObrasP;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (20/07/2018)
        //Utilizado por	: Reports.aspx
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE DE LOTE (Documentos Tramitados)
        /// </summary>
        public DataSet docTramita(DataSet dtsubDocTram, String codDist, String codSect, String codManz, String codLote)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPLOTE.PRC_DATODOCTRAMITADOS_TMP", new object[7]);

            db.SetParameterValue(dbCommand, "PVCCODDEPARTAMENTO", "15");
            db.SetParameterValue(dbCommand, "PVCCODPROVINCIA", "01");
            db.SetParameterValue(dbCommand, "PVCCODDISTRITO", codDist);
            db.SetParameterValue(dbCommand, "PVCCODSECTOR", codSect);
            db.SetParameterValue(dbCommand, "PVCCODMANZANA", codManz);
            db.SetParameterValue(dbCommand, "PVCCODLOTE", codLote);

            try
            {
                dtsubDocTram = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtsubDocTram;
        }

        public DataSet CargarOtrosDocumentosEstatico(DataSet dtsubDocTram, String codDist, String codSect, String codManz, String codLote)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_PROC_LOTEDOCADI.PRC_OTROSDOC", new object[7]);

            db.SetParameterValue(dbCommand, "PVCCODDEPARTAMENTO", "15");
            db.SetParameterValue(dbCommand, "PVCCODPROVINCIA", "01");
            db.SetParameterValue(dbCommand, "PVCCODDISTRITO", codDist);
            db.SetParameterValue(dbCommand, "PVCCODSECTOR", codSect);
            db.SetParameterValue(dbCommand, "PVCCODMANZANA", codManz);
            db.SetParameterValue(dbCommand, "PVCCODLOTE", codLote);

            try
            {
                dtsubDocTram = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtsubDocTram;
        }

        public DataSet CargarOtrosDocumentosTemporales(DataSet dtsubDocTram, String codDist, String codSect, String codManz, String codLote)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_PROC_LOTEDOCADI.PRC_OTROSDOC", new object[7]);

            db.SetParameterValue(dbCommand, "PVCCODDEPARTAMENTO", "15");
            db.SetParameterValue(dbCommand, "PVCCODPROVINCIA", "01");
            db.SetParameterValue(dbCommand, "PVCCODDISTRITO", codDist);
            db.SetParameterValue(dbCommand, "PVCCODSECTOR", codSect);
            db.SetParameterValue(dbCommand, "PVCCODMANZANA", codManz);
            db.SetParameterValue(dbCommand, "PVCCODLOTE", codLote);

            try
            {
                dtsubDocTram = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtsubDocTram;
        }

        public DataSet docTramita_est(DataSet dtsubDocTram, String codDist, String codSect, String codManz, String codLote)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPLOTE.PRC_DATODOCTRAMITADOS", new object[7]);

            db.SetParameterValue(dbCommand, "PVCCODDEPARTAMENTO", "15");
            db.SetParameterValue(dbCommand, "PVCCODPROVINCIA", "01");
            db.SetParameterValue(dbCommand, "PVCCODDISTRITO", codDist);
            db.SetParameterValue(dbCommand, "PVCCODSECTOR", codSect);
            db.SetParameterValue(dbCommand, "PVCCODMANZANA", codManz);
            db.SetParameterValue(dbCommand, "PVCCODLOTE", codLote);

            try
            {
                dtsubDocTram = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtsubDocTram;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (20/07/2018)
        //Utilizado por	: Reports.aspx
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE DE LOTE (Licencia de Funcionamiento)
        /// </summary>
        public DataSet LicenciaFunc(DataSet dtsubLicFunc, String codDist, String codSect, String codManz, String codLote)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPLOTE.PRC_DATODOCLICFUNC_TMP", new object[7]);

            db.SetParameterValue(dbCommand, "PVCCODDEPARTAMENTO", "15");
            db.SetParameterValue(dbCommand, "PVCCODPROVINCIA", "01");
            db.SetParameterValue(dbCommand, "PVCCODDISTRITO", codDist);
            db.SetParameterValue(dbCommand, "PVCCODSECTOR", codSect);
            db.SetParameterValue(dbCommand, "PVCCODMANZANA", codManz);
            db.SetParameterValue(dbCommand, "PVCCODLOTE", codLote);

            try
            {
                dtsubLicFunc = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtsubLicFunc;
        }

        public DataSet LicenciaFunc_est(DataSet dtsubLicFunc, String codDist, String codSect, String codManz, String codLote)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPLOTE.PRC_DATODOCLICFUNC", new object[7]);

            db.SetParameterValue(dbCommand, "PVCCODDEPARTAMENTO", "15");
            db.SetParameterValue(dbCommand, "PVCCODPROVINCIA", "01");
            db.SetParameterValue(dbCommand, "PVCCODDISTRITO", codDist);
            db.SetParameterValue(dbCommand, "PVCCODSECTOR", codSect);
            db.SetParameterValue(dbCommand, "PVCCODMANZANA", codManz);
            db.SetParameterValue(dbCommand, "PVCCODLOTE", codLote);

            try
            {
                dtsubLicFunc = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtsubLicFunc;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (20/07/2018)
        //Utilizado por	: Reports.aspx
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE DE LOTE (Observaciones)
        /// </summary>
        public DataSet Observaciones(DataSet dtsubObs, String codDist, String codSect, String codManz, String codLote)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPLOTE.PRC_DATOOBSERV_TMP", new object[7]);

            db.SetParameterValue(dbCommand, "PVCCODDEPARTAMENTO", "15");
            db.SetParameterValue(dbCommand, "PVCCODPROVINCIA", "01");
            db.SetParameterValue(dbCommand, "PVCCODDISTRITO", codDist);
            db.SetParameterValue(dbCommand, "PVCCODSECTOR", codSect);
            db.SetParameterValue(dbCommand, "PVCCODMANZANA", codManz);
            db.SetParameterValue(dbCommand, "PVCCODLOTE", codLote);

            try
            {
                dtsubObs = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtsubObs;
        }

        public DataSet Observaciones_est(DataSet dtsubObs, String codDist, String codSect, String codManz, String codLote)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REPLOTE.PRC_DATOOBSERV", new object[7]);

            db.SetParameterValue(dbCommand, "PVCCODDEPARTAMENTO", "15");
            db.SetParameterValue(dbCommand, "PVCCODPROVINCIA", "01");
            db.SetParameterValue(dbCommand, "PVCCODDISTRITO", codDist);
            db.SetParameterValue(dbCommand, "PVCCODSECTOR", codSect);
            db.SetParameterValue(dbCommand, "PVCCODMANZANA", codManz);
            db.SetParameterValue(dbCommand, "PVCCODLOTE", codLote);

            try
            {
                dtsubObs = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtsubObs;
        }

       
    }
}
