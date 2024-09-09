using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using MSI.Catastros.Utiles;
using MSI.Catastros.Web.App_Data.Lote;
using MSI.Catastros.Web.App_Data.Unidad;
using MSI.Catastros.Web.App_Data.Manzana;
using MSI.Catastros.Web.App_Data.BienComun;
using MSI.Catastros.Web.App_Data.Reporte;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE = MSI.Catastros.BusinessEntities;
using DA = MSI.Catastros.DataAccess;
using MSI.Catastros.Web.App_Data.Informes;
using MSI.Catastros.Web.App_Data.Cartas;
using MSI.Catastros.Web.App_Data.Certificado;
using MSI.Catastros.Web.App_Data.Urbana;
using MSI.Catastros.Web.App_Data.Foto;
using System.IO;
using System.Configuration;
using MSI.Catastros.Web.Helpers;
using MSI.Catastros.Web.App_Data.Inspeccion;

namespace MSI.Catastros.Web
{
    public partial class Reporst : System.Web.UI.Page
    {
        public string CodigoAreaLogueado = "";
        public string CodigoAreaCatastro = "0013";

        protected void Page_Load(object sender, EventArgs e)
        {
            // if (!IsPostBack)
            //{
            String CodigoDistrito = Request.QueryString["CodigoDistrito"];
            String CodigoSector = Request.QueryString["CodigoSector"];
            String CodigoManzana = Request.QueryString["CodigoManzana"];
            String CodigoLote = Request.QueryString["CodigoLote"];
            String CodigoReporte = Request.QueryString["CodigoReporte"];
            String CodigoUnico = Request.QueryString["CodigoUnico"];
            String codigoInforme = Request.QueryString["codigoInforme"];
            String codigoAnio = Request.QueryString["codigoAnio"];
            String codigoTipoInforme = Request.QueryString["codigoTipoInforme"];
            String CodigoCorrInforme = Request.QueryString["CodigoCorrInforme"];
            String codigoCarta = Request.QueryString["codigoCarta"];
            String CodigoCorrCarta = Request.QueryString["CodigoCorrCarta"];
            String CodigoCertificado = Request.QueryString["CodigoCertificado"];
            String CodigoAnhoCertificado = Request.QueryString["CodigoAnhoCertificado"];
            String CodigoHu = Request.QueryString["CodigoHu"];
            String CodigoEsq = Request.QueryString["CodigoEsq"];
            String Valido = Request.QueryString["Catastro"];
            String administrado = Request.QueryString["administrado"];
            String rutaFile = Request.QueryString["rutaFile"];
            String ListaCodigos = Request.QueryString["ListaCodigos"];
            String CodigoTipoInforme = Request.QueryString["CodigoTipoInforme"];
            String NumeroInforme = Request.QueryString["NumeroInforme"];
            String CorrelativoInforme = Request.QueryString["CorrelativoInforme"];
            String CodigoAnioInforme = Request.QueryString["CodigoAnioInforme"];


            CodigoAreaLogueado = VariablesWeb.CodAreaUsuario;



            string codusuario = Convert.ToString(User);
            if (true)
            {
                if (CodigoReporte != null)
                {
                    if (CodigoReporte.Equals("01"))
                    {
                        CargarReporteLote(CodigoDistrito, CodigoSector, CodigoManzana, CodigoLote, CodigoEsq, rutaFile);
                    }
                    if (CodigoReporte.Equals("02"))
                    {
                        CargarReporteUnidad(CodigoUnico, CodigoEsq, Valido, administrado, rutaFile);
                    }
                    if (CodigoReporte.Equals("10"))
                    {
                        CargarReporteMultiple(ListaCodigos, CodigoEsq, administrado);
                    }

                    if (CodigoReporte.Equals("03"))
                    {
                        CargarReporteManzana(CodigoDistrito, CodigoSector, CodigoManzana);
                    }
                    if (CodigoReporte.Equals("04"))
                    {
                        CargarReporteBienComun(CodigoUnico, CodigoEsq, Valido, administrado, rutaFile);
                    }
                    if (CodigoReporte.Equals("05"))
                    {
                        CargarReporteHabUrbana(CodigoHu);
                    }
                    if (CodigoReporte.Equals("001"))
                    {
                        CargarUnidadxInspeccion();
                    }
                    if (CodigoReporte.Equals("002"))
                    {
                        CargarUnidadxSector();
                    }
                    if (CodigoReporte.Equals("003"))
                    {
                        CargarLotexSector();
                    }
                    if (CodigoReporte.Equals("004"))
                    {
                        CargarSectorLoteUso();
                    }
                    if (CodigoReporte.Equals("005"))
                    {
                        CargarLoteSectorManzana();
                    }
                    if (CodigoReporte.Equals("010001"))
                    {
                        CargarReporteInformeVerificacion(codigoInforme, codigoAnio, codigoTipoInforme, CodigoCorrInforme);
                    }
                    if (CodigoReporte.Equals("010002"))
                    {
                        CargarReporteInformeTecnico(codigoInforme, codigoAnio, codigoTipoInforme, CodigoCorrInforme);
                    }
                    if (CodigoReporte.Equals("010003"))
                    {
                        CargarReporteInformeNumeracion(codigoInforme, codigoAnio, codigoTipoInforme, CodigoCorrInforme);
                    }
                    if (CodigoReporte.Equals("CITA"))
                    {
                        CargarReporteCartaCitacion(codigoCarta, codigoTipoInforme, codigoAnio, CodigoCorrCarta, rutaFile);
                    }
                    if (CodigoReporte.Equals("CONV"))
                    {
                        CargarReporteCartaConstancia(codigoCarta, codigoTipoInforme, codigoAnio, CodigoCorrCarta, rutaFile);
                    }
                    if (CodigoReporte.Equals("CAPI"))
                    {
                        CargarReporteCartaGeneral(codigoCarta, codigoTipoInforme, codigoAnio, CodigoCorrCarta, rutaFile);
                    }
                    if (CodigoReporte.Equals("HINF"))
                    {
                        CargarReporteHojaInfo(CodigoCertificado, CodigoAnhoCertificado, CodigoReporte, rutaFile);
                    }
                    if (CodigoReporte.Equals("CEJU"))
                    {
                        CargarReporteJurisdiccion(CodigoCertificado, CodigoAnhoCertificado, CodigoReporte, rutaFile);
                    }
                    if (CodigoReporte.Equals("CENO"))
                    {
                        CargarReporteNomenclatura(CodigoCertificado, CodigoAnhoCertificado, CodigoReporte, rutaFile);
                    }
                    if (CodigoReporte.Equals("CNMU"))
                    {
                        CargarResolucionNumeracion(CodigoCertificado, CodigoAnhoCertificado, CodigoReporte, rutaFile);
                    }
                    if (CodigoReporte.Equals("RNUM"))
                    {
                        CargarCertificadoNumeracion(CodigoCertificado, CodigoAnhoCertificado, CodigoReporte, rutaFile);
                    }
                    if (CodigoReporte.Equals("CEAC"))
                    {
                        CargarReporteCertAcumul(CodigoCertificado, CodigoAnhoCertificado, CodigoReporte, rutaFile);
                    }
                    if (CodigoReporte.Equals("ESTADISTICO"))
                    {
                        CargarReporteEstadisticosUnidadPorUso(CodigoReporte, codigoAnio, codigoTipoInforme);
                    }
                    if (CodigoReporte.Equals("INFV"))
                    {
                        CargarReporteInformeVerificacionCatastral(CodigoReporte, CodigoTipoInforme, NumeroInforme, CorrelativoInforme, CodigoAnioInforme);
                    }
                    if (CodigoReporte.Equals("INS"))
                    {
                        CargarReporteProgramacionInspeccionCatastral(CodigoReporte, NumeroInforme);
                    }

                }

            }
            //}
            //http://localhost:6456/Reportes/Reports.aspx.cs

        }



        private ReportDocument rptReporte = new ReportDocument();
        private ReportDocument rptReporteGlosario = new ReportDocument();
        protected void Page_UnLoad(object sender, EventArgs e)
        {
            try
            {
                CloseReports(rptReporte);
                rptReporte.Close();
                rptReporte.Dispose();
            }
            catch (Exception ex)
            {

            }

        }
        private void CloseReports(ReportDocument reportDocument)
        {
            Sections sections = reportDocument.ReportDefinition.Sections;
            foreach (Section section in sections)
            {
                ReportObjects reportObjects = section.ReportObjects;
                foreach (ReportObject reportObject in reportObjects)
                {
                    if (reportObject.Kind == ReportObjectKind.SubreportObject)
                    {
                        SubreportObject subreportObject = (SubreportObject)reportObject;
                        ReportDocument subReportDocument = subreportObject.OpenSubreport(subreportObject.SubreportName);
                        subReportDocument.Close();
                    }
                }
            }
            reportDocument.Close();
        }
        public void CargarReportes(string CodigoDistrito, string CodigoSector, string CodigoManzana, string CodigoLote)
        {
            rptReporte = new ReportDocument();
            string reportPath;
            reportPath = Server.MapPath("fichaLoteCatas.rpt");
            rptReporte.Load(reportPath);
            //rptReporte.SetDataSource(new DataTable());//el data source
            rptReporte.SetParameterValue("PVCCODDEPARTAMENTO", Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'));
            rptReporte.SetParameterValue("PVCCODPROVINCIA", Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'));
            rptReporte.SetParameterValue("PVCCODDISTRITO", EnumUbigeoSI.Distrito);
            rptReporte.SetParameterValue("PVCCODSECTOR", CodigoDistrito);
            rptReporte.SetParameterValue("PVCCODMANZANA", CodigoManzana);
            rptReporte.SetParameterValue("PVCCODLOTE", CodigoLote);

            crvReportes.DisplayGroupTree = false;
            crvReportes.HasViewList = false;
            crvReportes.HasSearchButton = true;
            crvReportes.HasExportButton = true;
            crvReportes.HasToggleGroupTreeButton = false;
            crvReportes.HasPrintButton = true;
            crvReportes.HasGotoPageButton = true;
            crvReportes.ToolPanelView = ToolPanelViewType.None;
            crvReportes.ReportSource = rptReporte;
            crvReportes.DataBind();
            //http://localhost:6456/reportes/reports.aspx?CodigoDistrito=1&CodigoSector=1&CodigoManzana=1&CodigoLote=1
            /*
             descarga
             */

            //System.IO.Stream oStream = null;
            //try
            //{
            //    byte[] byteArray = null;
            //    oStream = rptReporte.ExportToStream(ExportFormatType.PortableDocFormat);
            //    byteArray = new byte[oStream.Length - 1];// {(oStream.Length - 1)};
            //    oStream.Read(byteArray, 0, Convert.ToInt32((oStream.Length - 1)));
            //    Response.Clear();
            //    Response.Buffer = true;
            //    Response.ClearContent();
            //    Response.ClearHeaders();
            //    Response.ContentType = "application/pdf";
            //    Response.AddHeader("Content-Disposition", ("attachment;filename=" + "NOMBRE DE ARCHIVO.pdf"));//PDF WORD EXCEL 
            //    Response.BinaryWrite(byteArray);
            //    // Response.End()
            //    Response.Flush();
            //    Response.Close();
            //}
            //catch (Exception ex)
            //{
            //}
            //finally
            //{
            //    rptReporte.Close();
            //    rptReporte.Dispose();
            //    oStream.Flush();
            //    oStream.Close();
            //    oStream.Dispose();
            //    Page.Dispose();
            //}

        }

        public void CargarReportes2(string CodigoDistrito, string CodigoSector, string CodigoManzana, string CodigoLote)
        {
            rptReporte = new ReportDocument();
            string reportPath;
            //reportPath = Server.MapPath("sublotecatas/test2.rpt");
            reportPath = Server.MapPath("sublotecatas/subUbicEntrMuni.rpt");

            DA.SIC_REPORTE_LOTE rep = new DA.SIC_REPORTE_LOTE();

            DataSet dtsubUbicEntrMuni = new DataSet();
            dtsubUbicEntrMuni = new direcmuni();

            dtsubUbicEntrMuni = rep.DatosUbicCentrMuni(dtsubUbicEntrMuni, CodigoDistrito, CodigoSector, CodigoManzana, CodigoLote);

            dtsubUbicEntrMuni.Tables[0].TableName = "Direcmuni";

            rptReporte.Load(reportPath);
            //rptReporte.SetDataSource(dt.Tables[0]);//el data source
            rptReporte.SetDataSource(dtsubUbicEntrMuni.Tables[0]);//el data source

            crvReportes.DisplayGroupTree = false;
            crvReportes.HasViewList = false;
            crvReportes.HasSearchButton = true;
            crvReportes.HasExportButton = true;
            crvReportes.HasToggleGroupTreeButton = false;
            crvReportes.HasPrintButton = true;
            crvReportes.HasGotoPageButton = true;
            crvReportes.ToolPanelView = ToolPanelViewType.None;
            crvReportes.ReportSource = rptReporte;
            crvReportes.DataBind();
            //http://localhost:6456/reportes/reports.aspx?CodigoDistrito=1&CodigoSector=1&CodigoManzana=1&CodigoLote=1

        }
        private void CargarReporteInformeVerificacionCatastral(string codigoReporte, string codigoTipoInforme, string numeroInforme, string correlativoInforme, string codigoAnioInforme)
        {
            rptReporte = new ReportDocument();
            string reportPath;
            //Reporte Principal
            reportPath = Server.MapPath("rptInformeVerificacionCatastral.rpt");

            DA.SIC_INFORME rep = new DA.SIC_INFORME();
            DataSet dtInformeVerificacionCatastral = new DataSet();
            dtInformeVerificacionCatastral = new dsInformeVerificacionTecnica();
            dtInformeVerificacionCatastral = rep.BuscarInformeVerificacionCatastral(dtInformeVerificacionCatastral, codigoTipoInforme, numeroInforme, correlativoInforme, codigoAnioInforme);
            dtInformeVerificacionCatastral.Tables[0].TableName = "DT_INFORME_VERIFICACION";


            rptReporte.Load(reportPath);
            rptReporte.SetDataSource(dtInformeVerificacionCatastral.Tables[0]);




            DataSet dsUnidadesCatastrales = new DataSet();
            dsUnidadesCatastrales = new dsInforme_UnidadesCatastrales();
            dsUnidadesCatastrales = rep.BuscarUnidadesInformeVerificacionCatastrak(dsUnidadesCatastrales, codigoTipoInforme, numeroInforme, correlativoInforme, codigoAnioInforme);
            dsUnidadesCatastrales.Tables[0].TableName = "DS_UNIDADES_CATASTRALES";
            rptReporte.Subreports["rptUnidadesCatastrales.rpt"].SetDataSource(dsUnidadesCatastrales.Tables[0]);


            DataSet dsUbicacionUnidades = new DataSet();
            dsUbicacionUnidades = new dsInforme_UnidadesCatastrales();
            dsUbicacionUnidades = rep.BuscarDireccionInformeVerificacionCatastral(dsUbicacionUnidades, codigoTipoInforme, numeroInforme, correlativoInforme, codigoAnioInforme);
            dsUbicacionUnidades.Tables[0].TableName = "DS_UNIDADES_CATASTRALES";
            rptReporte.Subreports["rptUbicacionUnidades.rpt"].SetDataSource(dsUbicacionUnidades.Tables[0]);



            rptReporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "InformeVerificacionCatastral_" +
               codigoTipoInforme + "_" + numeroInforme);


            crvReportes.DisplayGroupTree = false;
            crvReportes.HasViewList = false;
            crvReportes.HasSearchButton = true;
            crvReportes.HasExportButton = true;
            crvReportes.HasToggleGroupTreeButton = false;
            crvReportes.HasPrintButton = true;
            crvReportes.HasGotoPageButton = true;
            crvReportes.ToolPanelView = ToolPanelViewType.None;
            crvReportes.ReportSource = rptReporte;
            crvReportes.DataBind();


        }
        private void CargarReporteProgramacionInspeccionCatastral(string codigoReporte, string numeroInforme)
        {
            rptReporte = new ReportDocument();
            string reportPath;
            //Reporte Principal
            reportPath = Server.MapPath("rptProgramacionInspeccionCatastral.rpt");

            DA.SIC_UNIDADINSPECCION rep = new DA.SIC_UNIDADINSPECCION();
            DataSet dtProgramacionInspeccion = new DataSet();
            dtProgramacionInspeccion = new dsProgramacionInspeccionCatastral();
            dtProgramacionInspeccion = rep.BuscarInspeccion(dtProgramacionInspeccion, numeroInforme);
            dtProgramacionInspeccion.Tables[0].TableName = "PROGRAMACION_INSPECCION";


            rptReporte.Load(reportPath);
            rptReporte.SetDataSource(dtProgramacionInspeccion.Tables[0]);




            //DataSet dsUnidadesCatastrales = new DataSet();
            //dsUnidadesCatastrales = new dsTipoInspeccion();
            //dsUnidadesCatastrales = rep.BuscarTipoInspeccion(dsUnidadesCatastrales, numeroInforme);
            //dsUnidadesCatastrales.Tables[0].TableName = "TIPO_INSPECCION";
            //rptReporte.Subreports["rptTipoInspeccion.rpt"].SetDataSource(dsUnidadesCatastrales.Tables[0]);


            DataSet dsUbicacionUnidades = new DataSet();
            dsUbicacionUnidades = new dsInforme_UnidadesCatastrales();
            dsUbicacionUnidades = rep.BuscarDireccionInspeccion(dsUbicacionUnidades, numeroInforme);
            dsUbicacionUnidades.Tables[0].TableName = "DS_UNIDADES_CATASTRALES";
            rptReporte.Subreports["rptUbicacionUnidades.rpt"].SetDataSource(dsUbicacionUnidades.Tables[0]);



            rptReporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "InformeVerificacionCatastral_" +
               numeroInforme + "_" + numeroInforme);


            crvReportes.DisplayGroupTree = false;
            crvReportes.HasViewList = false;
            crvReportes.HasSearchButton = true;
            crvReportes.HasExportButton = true;
            crvReportes.HasToggleGroupTreeButton = false;
            crvReportes.HasPrintButton = true;
            crvReportes.HasGotoPageButton = true;
            crvReportes.ToolPanelView = ToolPanelViewType.None;
            crvReportes.ReportSource = rptReporte;
            crvReportes.DataBind();
        }
        public ReportDocument CargarReporteLote(string CodigoDistrito, string CodigoSector, string CodigoManzana, string CodigoLote, string CodigoEsq, string rutaFile = "", bool multiple = false)
        {
            rptReporte = new ReportDocument();
            string reportPath;
            //Reporte Principal
            string TipoReporte;

            if (CodigoAreaLogueado == "" || CodigoAreaLogueado == null)
            {
                CodigoAreaLogueado = "OTRO_USUARIO";
            }

            reportPath = Server.MapPath("fichaLoteCatas3.rpt");


            DA.SIC_REPORTE_LOTE rep = new DA.SIC_REPORTE_LOTE();

            DataSet dtGen = new DataSet();
            dtGen = new FichaLoteCatas2();

            if (CodigoEsq.Equals("01"))
            {
                dtGen = rep.DatosGenerico(dtGen, CodigoDistrito, CodigoSector, CodigoManzana, CodigoLote);
                TipoReporte = "Temporal";

            }
            else
            {
                dtGen = rep.DatosGenerico_est(dtGen, CodigoDistrito, CodigoSector, CodigoManzana, CodigoLote);
                TipoReporte = "Estatico";
            }
            dtGen.Tables[0].TableName = "Lote";

            String Distrito = dtGen.Tables[0].Rows[0][2].ToString();
            String Sector = dtGen.Tables[0].Rows[0][3].ToString();
            String Manzana = dtGen.Tables[0].Rows[0][4].ToString();
            String Lote = dtGen.Tables[0].Rows[0][5].ToString();



            string CODCATAS = Distrito + Sector + Manzana + Lote;

            DataSet dtFoto = new DataSet();
            dtFoto = new FOTO();
            dtFoto = rep.RecuperarFoto(dtFoto, CODCATAS);
            string ft = "";
            try
            {
                ft = dtFoto.Tables[0].Rows[0][7].ToString();
                ft = @ConfigurationManager.AppSettings["RUTA_FOTOS"] + ft.Substring(2);
                dtGen.Tables[0].Rows[0][23] = ft;
            }
            catch (Exception ex)
            {
                ft = "";
            }



            rptReporte.Load(reportPath);
            rptReporte.SetDataSource(dtGen.Tables[0]);//el data source

            // Subreporte direccion
            DataSet dtsubUbicEntrMuni = new DataSet();
            dtsubUbicEntrMuni = new direcmuni();
            if (CodigoEsq.Equals("01"))
            {
                dtsubUbicEntrMuni = rep.DatosUbicCentrMuni(dtsubUbicEntrMuni, CodigoDistrito, CodigoSector, CodigoManzana, CodigoLote);
            }
            else
            {
                dtsubUbicEntrMuni = rep.DatosUbicCentrMuni_est(dtsubUbicEntrMuni, CodigoDistrito, CodigoSector, CodigoManzana, CodigoLote);
            }
            dtsubUbicEntrMuni.Tables[0].TableName = "Direcmuni";

            rptReporte.Subreports["subUbicEntrMuni.rpt"].SetDataSource(dtsubUbicEntrMuni.Tables[0]);

            // Zonificacion Lote
            DataSet dtsubZonifLote = new DataSet();
            dtsubZonifLote = new ZONIFLOTE();

            if (CodigoEsq.Equals("01"))
            {
                dtsubZonifLote = rep.DatosZonifLote(dtsubZonifLote, CodigoDistrito, CodigoSector, CodigoManzana, CodigoLote);
            }
            else
            {
                dtsubZonifLote = rep.DatosZonifLote_est(dtsubZonifLote, CodigoDistrito, CodigoSector, CodigoManzana, CodigoLote);
            }
            dtsubZonifLote.Tables[0].TableName = "ZONIFICACION";

            rptReporte.Subreports["subZonif.rpt"].SetDataSource(dtsubZonifLote.Tables[0]);

            // Normatividad Urbana
            DataSet dtsubAltVias = new DataSet();
            dtsubAltVias = new alturavias();

            if (CodigoEsq.Equals("01"))
            {
                dtsubAltVias = rep.DatoNormUrba(dtsubAltVias, CodigoDistrito, CodigoSector, CodigoManzana, CodigoLote);
            }
            else
            {
                dtsubAltVias = rep.DatoNormUrba_est(dtsubAltVias, CodigoDistrito, CodigoSector, CodigoManzana, CodigoLote);
            }
            dtsubAltVias.Tables[0].TableName = "Alturavias";

            rptReporte.Subreports["subAltuNorm.rpt"].SetDataSource(dtsubAltVias.Tables[0]);

            // Datos del Predio
            DataSet dtsubDatPred = new DataSet();
            dtsubDatPred = new lindero2();

            if (CodigoEsq.Equals("01"))
            {
                dtsubDatPred = rep.DatosPredio(dtsubDatPred, CodigoDistrito, CodigoSector, CodigoManzana, CodigoLote);
            }
            else
            {
                dtsubDatPred = rep.DatosPredio_est(dtsubDatPred, CodigoDistrito, CodigoSector, CodigoManzana, CodigoLote);
            }
            dtsubDatPred.Tables[0].TableName = "Lindero";

            var tableLindero = dtsubDatPred.Tables[0];
            string correlativoLado = "";
            int contF = 0, contI = 0, contD = 0, contA = 0;
            foreach (DataRow dr in dtsubDatPred.Tables[0].Rows)
            {
                var lado = dr["LADO"].ToString();
                switch (lado)
                {
                    case "FRENTE": contF++; correlativoLado = contF.ToString().PadLeft(4, '0'); break;
                    case "IZQUIERDA": contI++; correlativoLado = contI.ToString().PadLeft(4, '0'); break;
                    case "FONDO": contA++; correlativoLado = contA.ToString().PadLeft(4, '0'); break;
                    case "DERECHA": contD++; correlativoLado = contD.ToString().PadLeft(4, '0'); break;
                };
                if (dr.Table.Columns.Contains("ITEM"))
                {
                    dr["ITEM"] = correlativoLado;
                }
                else
                {
                    dr.Table.Columns.Add(new DataColumn("ITEM", typeof(string)));
                    dr["ITEM"] = correlativoLado;
                }

            }
            rptReporte.Subreports["subDatoPred.rpt"].SetDataSource(dtsubDatPred.Tables[0]);

            // Retiro Municipal
            DataSet dtsubRetiro = new DataSet();
            dtsubRetiro = new retiromuni();

            if (CodigoEsq.Equals("01"))
            {
                dtsubRetiro = rep.RetiroMunicipal(dtsubRetiro, CodigoDistrito, CodigoSector, CodigoManzana, CodigoLote);
            }
            else
            {
                dtsubRetiro = rep.RetiroMunicipal_est(dtsubRetiro, CodigoDistrito, CodigoSector, CodigoManzana, CodigoLote);
            }
            dtsubRetiro.Tables[0].TableName = "Retiromuni";

            rptReporte.Subreports["subRetiMuni.rpt"].SetDataSource(dtsubRetiro.Tables[0]);

            // Documentos RRPP
            DataSet dtsubDocRP = new DataSet();
            dtsubDocRP = new DOCRRPPLOTE();

            if (CodigoEsq.Equals("01"))
            {
                dtsubDocRP = rep.DocumentosRRPP(dtsubDocRP, CodigoDistrito, CodigoSector, CodigoManzana, CodigoLote);
            }
            else
            {
                dtsubDocRP = rep.DocumentosRRPP_est(dtsubDocRP, CodigoDistrito, CodigoSector, CodigoManzana, CodigoLote);
            }
            dtsubDocRP.Tables[0].TableName = "Docrrpp";

            rptReporte.Subreports["subDocuInsc.rpt"].SetDataSource(dtsubDocRP.Tables[0]);

            //Documentos Tramitados 
            DataSet dtsubTramita = new DataSet();
            dtsubTramita = new DOCTRAMITADOSLOTE();

            if (CodigoEsq.Equals("01"))
            {
                dtsubTramita = rep.docTramita(dtsubTramita, CodigoDistrito, CodigoSector, CodigoManzana, CodigoLote);
            }
            else
            {
                dtsubTramita = rep.docTramita_est(dtsubTramita, CodigoDistrito, CodigoSector, CodigoManzana, CodigoLote);
            }
            dtsubTramita.Tables[0].TableName = "Doctramitados";

            rptReporte.Subreports["subDocuTram.rpt"].SetDataSource(dtsubTramita.Tables[0]);


            //OTROS DOCUMENTOS
            DataSet dtOtrosDocumentos = new DataSet();
            dtOtrosDocumentos = new DOCTRAMITADOSLOTE();

            if (CodigoEsq.Equals("01"))
            {
                dtOtrosDocumentos = rep.CargarOtrosDocumentosTemporales(dtOtrosDocumentos, CodigoDistrito, CodigoSector, CodigoManzana, CodigoLote);
            }
            else
            {
                dtOtrosDocumentos = rep.CargarOtrosDocumentosEstatico(dtOtrosDocumentos, CodigoDistrito, CodigoSector, CodigoManzana, CodigoLote);
            }
            dtOtrosDocumentos.Tables[0].TableName = "SIC_LOTEOTRODOC";

            rptReporte.Subreports["rptLoteOtrosDocumentos.rpt"].SetDataSource(dtOtrosDocumentos.Tables[0]);





            // Obras Privadas
            DataSet dtsubObrasP = new DataSet();
            dtsubObrasP = new obrasprivadas();

            if (CodigoEsq.Equals("01"))
            {
                dtsubObrasP = rep.ObrasPrivadas(dtsubObrasP, CodigoDistrito, CodigoSector, CodigoManzana, CodigoLote);
            }
            else
            {
                dtsubObrasP = rep.ObrasPrivadas_est(dtsubObrasP, CodigoDistrito, CodigoSector, CodigoManzana, CodigoLote);
            }
            dtsubObrasP.Tables[0].TableName = "Obrasprivadas";

            rptReporte.Subreports["subObraPriv.rpt"].SetDataSource(dtsubObrasP.Tables[0]);

            // Licencias Func
            DataSet dtsubLicFunc = new DataSet();
            dtsubLicFunc = new licenciafunc();

            if (CodigoEsq.Equals("01"))
            {
                dtsubLicFunc = rep.LicenciaFunc(dtsubLicFunc, CodigoDistrito, CodigoSector, CodigoManzana, CodigoLote);
            }
            else
            {
                dtsubLicFunc = rep.LicenciaFunc_est(dtsubLicFunc, CodigoDistrito, CodigoSector, CodigoManzana, CodigoLote);
            }
            dtsubLicFunc.Tables[0].TableName = "Licenciafunc";

            rptReporte.Subreports["subLiceFunc.rpt"].SetDataSource(dtsubLicFunc.Tables[0]);

            // Observaciones
            DataSet dtsubObs = new DataSet();
            dtsubObs = new observaciones();

            if (CodigoEsq.Equals("01"))
            {
                dtsubObs = rep.Observaciones(dtsubObs, CodigoDistrito, CodigoSector, CodigoManzana, CodigoLote);
            }
            else
            {
                dtsubObs = rep.Observaciones_est(dtsubObs, CodigoDistrito, CodigoSector, CodigoManzana, CodigoLote);
            }
            dtsubObs.Tables[0].TableName = "Observaciones";

            rptReporte.Subreports["subObseGene.rpt"].SetDataSource(dtsubObs.Tables[0]);

            string machineName = DA.NetworkLocal.GetLocalMachineName();
            //string machineName = System.Environment.MachineName;
            rptReporte.SetParameterValue("pvcPCUSER", machineName + ((VariablesWeb.IdUsuarioIntento != "") ? " - " + VariablesWeb.IdUsuarioIntento : ""));
            rptReporte.SetParameterValue("pvcAREA", CodigoAreaLogueado);
            rptReporte.SetParameterValue("pvcTIPOREPORTE", TipoReporte);

            if (rutaFile != null)
            {
                rptReporte.ExportToDisk(ExportFormatType.PortableDocFormat, rutaFile + ".pdf");
                return new ReportDocument();
            }
            if (multiple == false)
            {
                rptReporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "FichaLote_" + CodigoDistrito + CodigoSector + CodigoManzana + CodigoLote);
            }

            return rptReporte;

            crvReportes.DisplayGroupTree = false;
            crvReportes.HasViewList = false;
            crvReportes.HasSearchButton = true;
            crvReportes.HasExportButton = true;
            crvReportes.HasToggleGroupTreeButton = false;
            crvReportes.HasPrintButton = true;
            crvReportes.HasGotoPageButton = true;
            crvReportes.ToolPanelView = ToolPanelViewType.None;
            crvReportes.ReportSource = rptReporte;
            crvReportes.DataBind();
            //http://localhost:6456/reportes/reports.aspx?CodigoDistrito=1&CodigoSector=1&CodigoManzana=1&CodigoLote=1

        }
        public void CargarReporteMultiple(string ListaCodigos, string CodigoEsq, string administrado)
        {
            var oStreamReportes = new List<MemoryStream>();
            string[] Codigos;
            MemoryStream reportMul;
            if (CodigoEsq == "03")
            {
                Codigos = ListaCodigos.Split(',');
                for (int i = 0; i < Codigos.Length; i++)
                {
                    rptReporte = CargarReporteLote("31", Codigos[i].Substring(0, 2), Codigos[i].Substring(2, 3), Codigos[i].Substring(5, 3), "02", null, true);
                    reportMul = rptReporte.ExportToPdfMemoryStream();
                    rptReporte.Close(); rptReporte.Dispose();
                    oStreamReportes.Add(reportMul);
                }
            }
            else
            {
                Codigos = ListaCodigos.Split(',');
                int sep = 0;

                for (int i = 0; i < Codigos.Length; i++)
                {
                    sep = Codigos[i].IndexOf("|");
                    string coduni = Codigos[i].Substring(0, sep);

                    if (Codigos[i].Substring(sep + 1) == "XXX")
                    {
                        rptReporte = CargarReporteBienComun(coduni, "02", "02", administrado, null, true);
                    }
                    else
                    {
                        rptReporte = CargarReporteUnidad(coduni, "02", "02", administrado, null, true);

                    }
                    reportMul = rptReporte.ExportToPdfMemoryStream();
                    rptReporte.Close(); rptReporte.Dispose();
                    oStreamReportes.Add(reportMul);

                }
            }
            var pdfReport = MailHelpers.CombinarArchivosPDF(oStreamReportes);
            crvReportes.ReportSource = pdfReport;
            crvReportes.DataBind();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.BinaryWrite(pdfReport);
            Response.Flush();
            Response.Close();
        }

        public ReportDocument CargarReporteUnidad(string codunico, string CodigoEsq, string validoReporte, string administrado, string rutaFile = "", bool multiple = false)
        {

            rptReporte = new ReportDocument();
            string reportPath;
            //Reporte Principal

            string TipoReporte;

            if (CodigoAreaLogueado == "" || CodigoAreaLogueado == null)
            {
                CodigoAreaLogueado = "OTRO_USUARIO";
            }
            reportPath = Server.MapPath("fichaIndividual2.rpt");

            DA.SIC_REPORTE_UNIDAD rep = new DA.SIC_REPORTE_UNIDAD();

            DataSet dtGen = new DataSet();
            dtGen = new FICHAUNIDAD();

            if (CodigoEsq.Contains("01"))
            {
                dtGen = rep.DatosGenerico(dtGen, codunico);
                TipoReporte = "Temporal";
            }
            else
            {
                dtGen = rep.DatosGenerico_est(dtGen, codunico);
                TipoReporte = "Estatico";
            }
            dtGen.Tables[0].TableName = "DATOSGEN";

            String Distrito = dtGen.Tables[0].Rows[0][2].ToString();
            String Sector = dtGen.Tables[0].Rows[0][3].ToString();
            String Manzana = dtGen.Tables[0].Rows[0][4].ToString();
            String Lote = dtGen.Tables[0].Rows[0][5].ToString();
            String Edificacion = dtGen.Tables[0].Rows[0][6].ToString();
            String NroEdificaciones = dtGen.Tables[0].Rows[0][38].ToString();

            string CODCATAS = Distrito + Sector + Manzana + Lote;
            string CODEDIF = Distrito + Sector + Manzana + Lote + Edificacion;

            if (NroEdificaciones == "1")
            {

                DataSet dtFoto = new DataSet();
                dtFoto = new FOTO();
                dtFoto = rep.RecuperarFoto(dtFoto, CODCATAS);

                string ft = "";
                try
                {
                    ft = dtFoto.Tables[0].Rows[0][7].ToString();
                    ft = @ConfigurationManager.AppSettings["RUTA_FOTOS"] + ft.Substring(2);
                    dtGen.Tables[0].Rows[0][37] = ft;
                }
                catch (Exception ex)
                {
                    ft = "";
                }
            }
            else
            {
                DataSet dtFoto = new DataSet();
                dtFoto = new FOTO();
                dtFoto = rep.RecuperarFotoEdificacion(dtFoto, CODCATAS, CODEDIF);

                string ft = "";



                if (dtFoto.Tables[0].Rows.Count > 0)
                {
                    ft = dtFoto.Tables[0].Rows[0][7].ToString();
                    ft = @ConfigurationManager.AppSettings["RUTA_FOTOS"] + ft.Substring(2);
                    dtGen.Tables[0].Rows[0][37] = ft;
                }
                else
                {
                    DataSet dtFoto2 = new DataSet();
                    dtFoto2 = new FOTO();
                    dtFoto2 = rep.RecuperarFoto(dtFoto2, CODCATAS);

                    string ftt = "";
                    try
                    {
                        ftt = dtFoto2.Tables[0].Rows[0][7].ToString();
                        ftt = @ConfigurationManager.AppSettings["RUTA_FOTOS"] + ftt.Substring(2);
                        dtGen.Tables[0].Rows[0][37] = ftt;
                    }
                    catch (Exception ex)
                    {
                        ftt = "";
                    }
                }

            }

            rptReporte.Load(reportPath);
            rptReporte.SetDataSource(dtGen.Tables[0]);//el data source

            // Subreporte Numeracion Municipal
            DataSet dtNumMun = new DataSet();
            dtNumMun = new NUMMUNICIP();

            if (CodigoEsq.Equals("01"))
            {
                dtNumMun = rep.DatosNumMun(dtNumMun, codunico, "010001");
            }
            else
            {
                dtNumMun = rep.DatosNumMun_est(dtNumMun, codunico, "010001");
            }
            dtNumMun.Tables[0].TableName = "MUNICIPAL";

            rptReporte.Subreports["subNumeMuni.rpt"].SetDataSource(dtNumMun.Tables[0]);

            // Subreporte Numeracion Interior Asignada
            DataSet dtIntAsig = new DataSet();
            dtIntAsig = new NUMINTASIG();

            if (CodigoEsq.Equals("01"))
            {
                dtIntAsig = rep.DatosIntAsig(dtIntAsig, codunico);
            }
            else
            {
                dtIntAsig = rep.DatosIntAsig_est(dtIntAsig, codunico);
            }
            dtIntAsig.Tables[0].TableName = "NUMINTASIG";

            rptReporte.Subreports["numintmunasig.rpt"].SetDataSource(dtIntAsig.Tables[0]);

            // Subreporte Numeracion Interior Temporal
            DataSet dtIntTemp = new DataSet();
            dtIntTemp = new NUMINTTEMP();

            if (CodigoEsq.Equals("01"))
            {
                dtIntTemp = rep.DatosIntTemp(dtIntTemp, codunico);
            }
            else
            {
                dtIntTemp = rep.DatosIntTemp_est(dtIntTemp, codunico);
            }
            dtIntTemp.Tables[0].TableName = "NUMINTTEMP";

            rptReporte.Subreports["numinttemp.rpt"].SetDataSource(dtIntTemp.Tables[0]);

            // Subreporte Numeracion de Campo
            DataSet dtNumCampo = new DataSet();
            dtNumCampo = new NUMCAMPO();

            if (CodigoEsq.Equals("01"))
            {
                dtNumCampo = rep.DatoNumCampo(dtNumCampo, codunico, "010002");
            }
            else
            {
                dtNumCampo = rep.DatoNumCampo_est(dtNumCampo, codunico, "010002");
            }
            dtNumCampo.Tables[0].TableName = "CAMPO";

            rptReporte.Subreports["subNumCampo.rpt"].SetDataSource(dtNumCampo.Tables[0]);

            // Construcciones
            DataSet dtconst = new DataSet();
            dtconst = new UNIDADCONST();

            if (CodigoEsq.Equals("01"))
            {
                dtconst = rep.Construcc(dtconst, codunico);
            }
            else
            {
                dtconst = rep.Construcc_est(dtconst, codunico);
            }
            dtconst.Tables[0].TableName = "CONSTRUCCION";

            rptReporte.Subreports["subLineCons.rpt"].SetDataSource(dtconst.Tables[0]);

            // Quinta Linderos
            DataSet dtqLin = new DataSet();
            dtqLin = new QUINTALINDERO();

            if (CodigoEsq.Equals("01"))
            {
                dtqLin = rep.DatosQuintaLind(dtqLin, codunico);
            }
            else
            {
                dtqLin = rep.DatosQuintaLind_est(dtqLin, codunico);
            }
            dtqLin.Tables[0].TableName = "QUINTALINDERO";

            rptReporte.Subreports["unidadlinderos.rpt"].SetDataSource(dtqLin.Tables[0]);

            // Otras Instalaciones
            DataSet dtOtraInst = new DataSet();
            dtOtraInst = new OTRASINSTALACIONES();

            if (CodigoEsq.Equals("01"))
            {
                dtOtraInst = rep.OtrasInstalac(dtOtraInst, codunico);
            }
            else
            {
                dtOtraInst = rep.OtrasInstalac_est(dtOtraInst, codunico);
            }
            dtOtraInst.Tables[0].TableName = "INSTALACIONES";

            rptReporte.Subreports["subOtraInst.rpt"].SetDataSource(dtOtraInst.Tables[0]);

            // Titular Catastral
            DataSet dtTitCatas = new DataSet();
            dtTitCatas = new TITULAR();

            if (CodigoEsq.Equals("01"))
            {
                dtTitCatas = rep.TitularCatas(dtTitCatas, codunico);
            }
            else
            {
                dtTitCatas = rep.TitularCatas_est(dtTitCatas, codunico);
            }
            dtTitCatas.Tables[0].TableName = "TITULAR";

            rptReporte.Subreports["subInfoTitu.rpt"].SetDataSource(dtTitCatas.Tables[0]);

            // Documentos RRPP
            DataSet dtsubDocRP = new DataSet();
            dtsubDocRP = new DOCRRPPUNIDAD();

            if (CodigoEsq.Equals("01"))
            {
                dtsubDocRP = rep.DocumentosRRPP(dtsubDocRP, codunico);
            }
            else
            {
                dtsubDocRP = rep.DocumentosRRPP_est(dtsubDocRP, codunico);
            }
            dtsubDocRP.Tables[0].TableName = "INSCRIPCIONRRPP";

            rptReporte.Subreports["subInscRegi.rpt"].SetDataSource(dtsubDocRP.Tables[0]);

            // Documentos Tramitados 
            DataSet dtsubTramita = new DataSet();
            dtsubTramita = new DOCTRAMITADOS();

            if (CodigoEsq.Equals("01"))
            {
                dtsubTramita = rep.DocumentosTramita(dtsubTramita, codunico);
            }
            else
            {
                dtsubTramita = rep.DocumentosTramita_est(dtsubTramita, codunico);
            }
            dtsubTramita.Tables[0].TableName = "DOCTRAMITADOS";

            rptReporte.Subreports["subDocuTramit.rpt"].SetDataSource(dtsubTramita.Tables[0]);

            // Obras Privadas
            DataSet dtsubObrasP = new DataSet();
            dtsubObrasP = new DOCOBRASPRIV();

            if (CodigoEsq.Equals("01"))
            {
                dtsubObrasP = rep.ObrasPrivadas(dtsubObrasP, codunico);
            }
            else
            {
                dtsubObrasP = rep.ObrasPrivadas_est(dtsubObrasP, codunico);
            }
            dtsubObrasP.Tables[0].TableName = "OBRASPRIVADAS";

            rptReporte.Subreports["subObraPrivadas.rpt"].SetDataSource(dtsubObrasP.Tables[0]);

            // Licencias Func
            DataSet dtsubLicFunc = new DataSet();
            dtsubLicFunc = new DOCLICFUNC();

            if (CodigoEsq.Equals("01"))
            {
                dtsubLicFunc = rep.LicenciaFunc(dtsubLicFunc, codunico);
            }
            else
            {
                dtsubLicFunc = rep.LicenciaFunc_est(dtsubLicFunc, codunico);
            }
            dtsubLicFunc.Tables[0].TableName = "LICENCIA";

            rptReporte.Subreports["subLiceFunciona.rpt"].SetDataSource(dtsubLicFunc.Tables[0]);

            // Actividad Economica
            DataSet dtActEconom = new DataSet();
            dtActEconom = new ACTIVIDECONO();

            if (CodigoEsq.Equals("01"))
            {
                dtActEconom = rep.ActividadEcono(dtActEconom, codunico);
            }
            else
            {
                dtActEconom = rep.ActividadEcono_est(dtActEconom, codunico);
            }
            dtActEconom.Tables[0].TableName = "ACTECONOMICA";

            rptReporte.Subreports["subActivEcono.rpt"].SetDataSource(dtActEconom.Tables[0]);

            // Observaciones Gen
            DataSet dtsubObsGen = new DataSet();
            dtsubObsGen = new OBSERVGEN();

            if (CodigoEsq.Equals("01"))
            {
                dtsubObsGen = rep.ObservacionesGen(dtsubObsGen, codunico, "010001");
            }
            else
            {
                dtsubObsGen = rep.ObservacionesGen_est(dtsubObsGen, codunico, "010001");
            }
            dtsubObsGen.Tables[0].TableName = "OBSERVGEN";

            rptReporte.Subreports["subObseGeneral.rpt"].SetDataSource(dtsubObsGen.Tables[0]);

            // Observaciones Cargas
            DataSet dtsubObsCarg = new DataSet();
            dtsubObsCarg = new OBSERVCARGINSC();

            if (CodigoEsq.Equals("01"))
            {
                dtsubObsCarg = rep.ObservacionesCargas(dtsubObsCarg, codunico, "010002");
            }
            else
            {
                dtsubObsCarg = rep.ObservacionesCargas_est(dtsubObsCarg, codunico, "010002");
            }
            dtsubObsCarg.Tables[0].TableName = "OBSERVCARG";

            rptReporte.Subreports["subObseInsc.rpt"].SetDataSource(dtsubObsCarg.Tables[0]);

            // Observaciones Respecto a Cargas
            DataSet dtsubObsRespect = new DataSet();
            dtsubObsRespect = new OBSERVRESPECTCARG();

            if (CodigoEsq.Equals("01"))
            {
                dtsubObsRespect = rep.ObservacionesRespecto(dtsubObsRespect, codunico, "010003");
            }
            else
            {
                dtsubObsRespect = rep.ObservacionesRespecto_est(dtsubObsRespect, codunico, "010003");
            }
            dtsubObsRespect.Tables[0].TableName = "OBSERVRESPECT";

            rptReporte.Subreports["subObseResp.rpt"].SetDataSource(dtsubObsRespect.Tables[0]);

            string machineName = DA.NetworkLocal.GetLocalMachineName();
            //string machineName = System.Environment.MachineName;
            rptReporte.SetParameterValue("pvcPCUSER", machineName + ((VariablesWeb.IdUsuarioIntento != "") ? " - " + VariablesWeb.IdUsuarioIntento : ""));
            rptReporte.SetParameterValue("pvcAREAUSER", CodigoAreaLogueado);
            if (administrado == null) administrado = " - ";
            rptReporte.SetParameterValue("pvcADMINISTRADO", administrado);
            rptReporte.SetParameterValue("pvcTIPOREPORTE", TipoReporte);


            if (rutaFile != null)
            {
                rptReporte.ExportToDisk(ExportFormatType.PortableDocFormat, rutaFile + ".pdf");
                return new ReportDocument();
            }

            if (multiple == false)
            {
                rptReporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "FichaUnidad_" + codunico);
            }
            return rptReporte;


            crvReportes.DisplayGroupTree = false;
            crvReportes.HasViewList = false;
            crvReportes.HasSearchButton = true;
            crvReportes.HasExportButton = true;
            crvReportes.HasToggleGroupTreeButton = false;
            crvReportes.HasPrintButton = true;
            crvReportes.HasGotoPageButton = true;
            crvReportes.ToolPanelView = ToolPanelViewType.None;
            crvReportes.ReportSource = rptReporte;
            //crvReportes.DataBind();
            //http://localhost:6456/reportes/reports.aspx?CodigoDistrito=1&CodigoSector=1&CodigoManzana=1&CodigoLote=1

        }

        public ReportDocument CargarReporteBienComun(string codunico, string CodigoEsq, string validoReporte, string administrado, string rutaFile = "", bool multiple = false)
        {
            rptReporte = new ReportDocument();
            string reportPath;
            //Reporte Principal
            string TipoReporte;

            if (CodigoAreaLogueado == "" || CodigoAreaLogueado == null)
            {
                CodigoAreaLogueado = "OTRO_USUARIO";
            }

            reportPath = Server.MapPath("fichaBienComun.rpt");



            DA.SIC_REPORTE_UNIDAD rep = new DA.SIC_REPORTE_UNIDAD();

            DataSet dtGen = new DataSet();
            dtGen = new FICHAUNIDAD();

            if (CodigoEsq.Contains("01"))
            {
                dtGen = rep.DatosGenerico(dtGen, codunico);
                TipoReporte = "Temporal";
            }
            else
            {
                dtGen = rep.DatosGenerico_est(dtGen, codunico);
                TipoReporte = "Estatico";
            }
            dtGen.Tables[0].TableName = "DATOSGEN";

            String Distrito = dtGen.Tables[0].Rows[0][2].ToString();
            String Sector = dtGen.Tables[0].Rows[0][3].ToString();
            String Manzana = dtGen.Tables[0].Rows[0][4].ToString();
            String Lote = dtGen.Tables[0].Rows[0][5].ToString();

            string CODCATAS = Distrito + Sector + Manzana + Lote;

            DataSet dtFoto = new DataSet();
            dtFoto = new FOTO();
            dtFoto = rep.RecuperarFoto(dtFoto, CODCATAS);

            string ft = "";
            try
            {
                ft = dtFoto.Tables[0].Rows[0][7].ToString();
                ft = @ConfigurationManager.AppSettings["RUTA_FOTOS"] + ft.Substring(2);
                dtGen.Tables[0].Rows[0][37] = ft;
            }
            catch (Exception ex)
            {
                ft = "";
            }

            rptReporte.Load(reportPath);
            rptReporte.SetDataSource(dtGen.Tables[0]);//el data source

            // Subreporte Numeracion Municipal
            DataSet dtNumMun = new DataSet();
            dtNumMun = new NUMMUNICIP();

            if (CodigoEsq.Equals("01"))
            {
                dtNumMun = rep.DatosNumMun(dtNumMun, codunico, "010001");
            }
            else
            {
                dtNumMun = rep.DatosNumMun_est(dtNumMun, codunico, "010001");
            }
            dtNumMun.Tables[0].TableName = "MUNICIPAL";

            rptReporte.Subreports["subNumeMuni.rpt"].SetDataSource(dtNumMun.Tables[0]);

            // Subreporte Numeracion de Campo
            DataSet dtNumCampo = new DataSet();
            dtNumCampo = new NUMCAMPO();

            if (CodigoEsq.Equals("01"))
            {
                dtNumCampo = rep.DatoNumCampo(dtNumCampo, codunico, "010002");
            }
            else
            {
                dtNumCampo = rep.DatoNumCampo_est(dtNumCampo, codunico, "010002");
            }
            dtNumCampo.Tables[0].TableName = "CAMPO";

            rptReporte.Subreports["subNumCampo.rpt"].SetDataSource(dtNumCampo.Tables[0]);

            // Construcciones
            DataSet dtconst = new DataSet();
            dtconst = new UNIDADCONST();

            if (CodigoEsq.Equals("01"))
            {
                dtconst = rep.Construcc(dtconst, codunico);
            }
            else
            {
                dtconst = rep.Construcc_est(dtconst, codunico);
            }
            dtconst.Tables[0].TableName = "CONSTRUCCION";

            rptReporte.Subreports["subLineCons.rpt"].SetDataSource(dtconst.Tables[0]);

            // Otras Instalaciones
            DataSet dtOtraInst = new DataSet();
            dtOtraInst = new OTRASINSTALACIONES();

            if (CodigoEsq.Equals("01"))
            {
                dtOtraInst = rep.OtrasInstalac(dtOtraInst, codunico);
            }
            else
            {
                dtOtraInst = rep.OtrasInstalac_est(dtOtraInst, codunico);
            }
            dtOtraInst.Tables[0].TableName = "INSTALACIONES";

            rptReporte.Subreports["subOtraInst.rpt"].SetDataSource(dtOtraInst.Tables[0]);

            // DATOS LINDEROS
            DataSet dtLinderos = new DataSet();
            dtLinderos = new BCLINDEROS();

            if (CodigoEsq.Equals("01"))
            {
                dtLinderos = rep.DatosLinderos(dtLinderos, codunico);
            }
            else
            {
                dtLinderos = rep.DatosLinderos_est(dtLinderos, codunico);
            }
            dtLinderos.Tables[0].TableName = "BCLINDEROS";

            rptReporte.Subreports["unidadlinderos.rpt"].SetDataSource(dtLinderos.Tables[0]);

            // Documentos RRPP
            DataSet dtsubDocRP = new DataSet();
            dtsubDocRP = new DOCRRPPUNIDAD();

            if (CodigoEsq.Equals("01"))
            {
                dtsubDocRP = rep.DocumentosRRPP(dtsubDocRP, codunico);
            }
            else
            {
                dtsubDocRP = rep.DocumentosRRPP_est(dtsubDocRP, codunico);
            }
            dtsubDocRP.Tables[0].TableName = "INSCRIPCIONRRPP";

            rptReporte.Subreports["subInscRegi.rpt"].SetDataSource(dtsubDocRP.Tables[0]);

            // Documentos Tramitados 
            DataSet dtsubTramita = new DataSet();
            dtsubTramita = new DOCTRAMITADOS();

            if (CodigoEsq.Equals("01"))
            {
                dtsubTramita = rep.DocumentosTramita(dtsubTramita, codunico);
            }
            else
            {
                dtsubTramita = rep.DocumentosTramita_est(dtsubTramita, codunico);
            }
            dtsubTramita.Tables[0].TableName = "DOCTRAMITADOS";

            rptReporte.Subreports["subDocuTramit.rpt"].SetDataSource(dtsubTramita.Tables[0]);

            // Obras Privadas
            DataSet dtsubObrasP = new DataSet();
            dtsubObrasP = new DOCOBRASPRIV();

            if (CodigoEsq.Equals("01"))
            {
                dtsubObrasP = rep.ObrasPrivadas(dtsubObrasP, codunico);
            }
            else
            {
                dtsubObrasP = rep.ObrasPrivadas_est(dtsubObrasP, codunico);
            }
            dtsubObrasP.Tables[0].TableName = "OBRASPRIVADAS";

            rptReporte.Subreports["subObraPrivadas.rpt"].SetDataSource(dtsubObrasP.Tables[0]);

            // Licencias Func
            DataSet dtsubLicFunc = new DataSet();
            dtsubLicFunc = new DOCLICFUNC();

            if (CodigoEsq.Equals("01"))
            {
                dtsubLicFunc = rep.LicenciaFunc(dtsubLicFunc, codunico);
            }
            else
            {
                dtsubLicFunc = rep.LicenciaFunc_est(dtsubLicFunc, codunico);
            }
            dtsubLicFunc.Tables[0].TableName = "LICENCIA";

            rptReporte.Subreports["subLiceFunciona.rpt"].SetDataSource(dtsubLicFunc.Tables[0]);

            // Actividad Economica
            DataSet dtActEconom = new DataSet();
            dtActEconom = new ACTIVIDECONO();

            if (CodigoEsq.Equals("01"))
            {
                dtActEconom = rep.ActividadEcono(dtActEconom, codunico);
            }
            else
            {
                dtActEconom = rep.ActividadEcono_est(dtActEconom, codunico);
            }
            dtActEconom.Tables[0].TableName = "ACTECONOMICA";

            rptReporte.Subreports["subActivEcono.rpt"].SetDataSource(dtActEconom.Tables[0]);

            // Observaciones Gen
            DataSet dtsubObsGen = new DataSet();
            dtsubObsGen = new OBSERVGEN();

            if (CodigoEsq.Equals("01"))
            {
                dtsubObsGen = rep.ObservacionesGen(dtsubObsGen, codunico, "010001");
            }
            else
            {
                dtsubObsGen = rep.ObservacionesGen_est(dtsubObsGen, codunico, "010001");
            }
            dtsubObsGen.Tables[0].TableName = "OBSERVGEN";

            rptReporte.Subreports["subObseGeneral.rpt"].SetDataSource(dtsubObsGen.Tables[0]);

            // Observaciones Cargas
            DataSet dtsubObsCarg = new DataSet();
            dtsubObsCarg = new OBSERVCARGINSC();

            if (CodigoEsq.Equals("01"))
            {
                dtsubObsCarg = rep.ObservacionesCargas(dtsubObsCarg, codunico, "010002");
            }
            else
            {
                dtsubObsCarg = rep.ObservacionesCargas_est(dtsubObsCarg, codunico, "010002");
            }
            dtsubObsCarg.Tables[0].TableName = "OBSERVCARG";

            rptReporte.Subreports["subObseInsc.rpt"].SetDataSource(dtsubObsCarg.Tables[0]);

            // Observaciones Respecto a Cargas
            DataSet dtsubObsRespect = new DataSet();
            dtsubObsRespect = new OBSERVRESPECTCARG();

            if (CodigoEsq.Equals("01"))
            {
                dtsubObsRespect = rep.ObservacionesRespecto(dtsubObsRespect, codunico, "010003");
            }
            else
            {
                dtsubObsRespect = rep.ObservacionesRespecto_est(dtsubObsRespect, codunico, "010003");
            }
            dtsubObsRespect.Tables[0].TableName = "OBSERVRESPECT";

            rptReporte.Subreports["subObseResp.rpt"].SetDataSource(dtsubObsRespect.Tables[0]);

            // Recapitulacion de Bienes Comunes
            DataSet dtsubRecapBC = new DataSet();
            dtsubRecapBC = new RECAPBC();

            if (CodigoEsq.Equals("01"))
            {
                dtsubRecapBC = rep.DatosRecapBC(dtsubRecapBC, codunico);
                //dtsubRecapBC = rep.DatosRecapBC_est(dtsubRecapBC, codunico);
            }
            else
            {
                dtsubRecapBC = rep.DatosRecapBC_est(dtsubRecapBC, codunico);
            }


            dtsubRecapBC.Tables[0].TableName = "RECAPBC";

            rptReporte.Subreports["recapbiencom.rpt"].SetDataSource(dtsubRecapBC.Tables[0]);

            string machineName = DA.NetworkLocal.GetLocalMachineName();
            //string machineName = System.Environment.MachineName;
            rptReporte.SetParameterValue("pvcPCUSER", machineName + ((VariablesWeb.IdUsuarioIntento != "") ? " - " + VariablesWeb.IdUsuarioIntento : ""));
            rptReporte.SetParameterValue("pvcAREAUSER", CodigoAreaLogueado);
            if (administrado == null) administrado = " - ";
            rptReporte.SetParameterValue("pvcADMINISTRADO", administrado);
            rptReporte.SetParameterValue("pvcTIPOREPORTE", TipoReporte);

            if (rutaFile != null)
            {
                rptReporte.ExportToDisk(ExportFormatType.PortableDocFormat, rutaFile + ".pdf");
                return new ReportDocument();
            }

            if (multiple == false)
            {
                rptReporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "FichaBienComun_" + codunico);
            }
            return rptReporte;

            crvReportes.DisplayGroupTree = false;
            crvReportes.HasViewList = false;
            crvReportes.HasSearchButton = true;
            crvReportes.HasExportButton = true;
            crvReportes.HasToggleGroupTreeButton = false;
            crvReportes.HasPrintButton = true;
            crvReportes.HasGotoPageButton = true;
            crvReportes.ToolPanelView = ToolPanelViewType.None;
            crvReportes.ReportSource = rptReporte;
            crvReportes.DataBind();
            //http://localhost:6456/reportes/reports.aspx?CodigoDistrito=1&CodigoSector=1&CodigoManzana=1&CodigoLote=1

        }

        public void CargarReporteManzana(string CodigoDistrito, string CodigoSector, string CodigoManzana)
        {
            rptReporte = new ReportDocument();
            string reportPath;
            //Reporte Principal
            reportPath = Server.MapPath("fichaManzaCatas.rpt");

            DA.SIC_REPORTE_MANZANA rep = new DA.SIC_REPORTE_MANZANA();

            DataSet dtDatosGen = new DataSet();
            dtDatosGen = new FICHAMANZANA();

            dtDatosGen = rep.DatosGenerico(dtDatosGen, CodigoDistrito, CodigoSector, CodigoManzana);
            dtDatosGen.Tables[0].TableName = "DATOSGEN";

            // string carpeta = string.Format("\\{0}\\{1}\\{2}\\{3}\\", "DOCUMENTOS", "INTERIOR", CodigoSector, CodigoManzana);
            String rutadd = @ConfigurationManager.AppSettings["RUTA_FILSERVER"];

            String RUTIMG = dtDatosGen.Tables[0].Rows[0][10].ToString();

            dtDatosGen.Tables[0].Rows[0][10] = rutadd + RUTIMG;

            rptReporte.Load(reportPath);
            rptReporte.SetDataSource(dtDatosGen.Tables[0]);//el data source

            // Subreporte Ubicacion MZ
            DataSet dtUbicMz = new DataSet();
            dtUbicMz = new UBICACIONMZ();

            dtUbicMz = rep.DatosUbicMz(dtUbicMz, CodigoDistrito, CodigoSector, CodigoManzana);
            dtUbicMz.Tables[0].TableName = "UBICACION";

            rptReporte.Subreports["ubicmz.rpt"].SetDataSource(dtUbicMz.Tables[0]);

            // Subreporte Linderos MZ
            DataSet dtsubLinderos = new DataSet();
            dtsubLinderos = new LINDEROSMANZANA();

            dtsubLinderos = rep.DatosLindMz(dtsubLinderos, CodigoDistrito, CodigoSector, CodigoManzana);
            dtsubLinderos.Tables[0].TableName = "LINDEROS";

            rptReporte.Subreports["linderosmz.rpt"].SetDataSource(dtsubLinderos.Tables[0]);

            // Subreporte Lotes Total
            DataSet dtsubLotTot = new DataSet();
            dtsubLotTot = new TOTALLOTE();

            dtsubLotTot = rep.DatosLotTot(dtsubLotTot, CodigoDistrito, CodigoSector, CodigoManzana);
            dtsubLotTot.Tables[0].TableName = "TOTALLOTE";

            rptReporte.Subreports["lottotal.rpt"].SetDataSource(dtsubLotTot.Tables[0]);

            string machineName = DA.NetworkLocal.GetLocalMachineName();
            //string machineName = System.Environment.MachineName;
            rptReporte.SetParameterValue("pvcPCUSER", machineName + ((VariablesWeb.IdUsuarioIntento != "") ? " - " + VariablesWeb.IdUsuarioIntento : ""));

            rptReporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "FichaManzana_" +
               CodigoDistrito + CodigoSector + CodigoManzana);

            crvReportes.DisplayGroupTree = false;
            crvReportes.HasViewList = false;
            crvReportes.HasSearchButton = true;
            crvReportes.HasExportButton = true;
            crvReportes.HasToggleGroupTreeButton = false;
            crvReportes.HasPrintButton = true;
            crvReportes.HasGotoPageButton = true;
            crvReportes.ToolPanelView = ToolPanelViewType.None;
            crvReportes.ReportSource = rptReporte;
            crvReportes.DataBind();
            //http://localhost:6456/reportes/reports.aspx?CodigoDistrito=1&CodigoSector=1&CodigoManzana=1&CodigoLote=1
        }

        public void CargarReporteHabUrbana(string CodigoHu)
        {
            rptReporte = new ReportDocument();
            string reportPath;
            //Reporte Principal
            reportPath = Server.MapPath("fichaUrba.rpt");

            DA.SIC_REPORTEURBA rep = new DA.SIC_REPORTEURBA();

            DataSet dtDatosGen = new DataSet();
            dtDatosGen = new FICHAURBANA();

            dtDatosGen = rep.DatosGenerico(dtDatosGen, CodigoHu);
            dtDatosGen.Tables[0].TableName = "FICHAURBANA";

            String rutadd = @ConfigurationManager.AppSettings["RUTA_FILSERVER"];

            String RUTIMG = dtDatosGen.Tables[0].Rows[0][7].ToString();

            dtDatosGen.Tables[0].Rows[0][7] = rutadd + RUTIMG;

            rptReporte.Load(reportPath);
            rptReporte.SetDataSource(dtDatosGen.Tables[0]);//el data source

            // Subreporte Manzana Urbana
            DataSet dtMzUrb = new DataSet();
            dtMzUrb = new MANZAURBANA();

            dtMzUrb = rep.DatosManza(dtMzUrb, CodigoHu);
            dtMzUrb.Tables[0].TableName = "MANZAURBANA";

            rptReporte.Subreports["manzaUrba.rpt"].SetDataSource(dtMzUrb.Tables[0]);

            // Subreporte Observacion
            DataSet dtsubObs = new DataSet();
            dtsubObs = new OBSURBANA();

            dtsubObs = rep.DatosObs(dtsubObs, CodigoHu);
            dtsubObs.Tables[0].TableName = "OBSURBANA";

            rptReporte.Subreports["obsUrba.rpt"].SetDataSource(dtsubObs.Tables[0]);

            string machineName = DA.NetworkLocal.GetLocalMachineName();
            //string machineName = System.Environment.MachineName;
            rptReporte.SetParameterValue("pvcPCUSER", machineName + ((VariablesWeb.IdUsuarioIntento != "") ? " - " + VariablesWeb.IdUsuarioIntento : ""));

            rptReporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "FichaUrbanizacion_" +
                CodigoHu);

            crvReportes.DisplayGroupTree = false;
            crvReportes.HasViewList = false;
            crvReportes.HasSearchButton = true;
            crvReportes.HasExportButton = true;
            crvReportes.HasToggleGroupTreeButton = false;
            crvReportes.HasPrintButton = true;
            crvReportes.HasGotoPageButton = true;
            crvReportes.ToolPanelView = ToolPanelViewType.None;
            crvReportes.ReportSource = rptReporte;
            crvReportes.DataBind();
            //http://localhost:6456/reportes/reports.aspx?CodigoDistrito=1&CodigoSector=1&CodigoManzana=1&CodigoLote=1
        }

        public void CargarUnidadxInspeccion()
        {
            rptReporte = new ReportDocument();
            string reportPath;
            //Reporte Principal
            reportPath = Server.MapPath("unidadxInscripcion.rpt");
            DA.SIC_REPORTE rep = new DA.SIC_REPORTE();

            rptReporte.Load(reportPath);
            //rptReporte.SetDataSource(dtDatosGen.Tables[0]);//el data source

            //Subreporte Manzana Urbana
            DataSet dtInscrip = new DataSet();
            dtInscrip = new UnidadxInscripion();

            dtInscrip = rep.UnidadxInscripcion(dtInscrip);
            dtInscrip.Tables[0].TableName = "DatosUnidadxInscripcion";

            rptReporte.Subreports["DetalleInscripcion.rpt"].SetDataSource(dtInscrip.Tables[0]);

            // Subreporte Observacion
            //DataSet dtsubObs = new DataSet();
            //dtsubObs = new OBSURBANA();

            //dtsubObs = rep.DatosObs(dtsubObs, CodigoHu);
            //dtsubObs.Tables[0].TableName = "OBSURBANA";

            //rptReporte.Subreports["obsUrba.rpt"].SetDataSource(dtsubObs.Tables[0]);

            rptReporte.ExportToHttpResponse(ExportFormatType.Excel, Response, false, "ReporteInscripcionCatastral");

            crvReportes.DisplayGroupTree = false;
            crvReportes.HasViewList = false;
            crvReportes.HasSearchButton = true;
            crvReportes.HasExportButton = true;
            crvReportes.HasToggleGroupTreeButton = false;
            crvReportes.HasPrintButton = true;
            crvReportes.HasGotoPageButton = true;
            crvReportes.ToolPanelView = ToolPanelViewType.None;
            crvReportes.ReportSource = rptReporte;
            crvReportes.DataBind();
            //http://localhost:6456/reportes/reports.aspx?CodigoReporte=06
        }

        public void CargarUnidadxSector()
        {
            rptReporte = new ReportDocument();
            string reportPath;
            //Reporte Principal
            reportPath = Server.MapPath("unidadxSector.rpt");
            DA.SIC_REPORTE rep = new DA.SIC_REPORTE();

            rptReporte.Load(reportPath);
            //rptReporte.SetDataSource(dtDatosGen.Tables[0]);//el data source

            //Subreporte Manzana Urbana
            DataSet dtSector = new DataSet();
            dtSector = new unidadxSector();

            dtSector = rep.UnidadxSector(dtSector);
            dtSector.Tables[0].TableName = "DatosUnidadxSector";

            rptReporte.Subreports["AcumulacionSector.rpt"].SetDataSource(dtSector.Tables[0]);

            // Subreporte Observacion
            //DataSet dtsubObs = new DataSet();
            //dtsubObs = new OBSURBANA();

            //dtsubObs = rep.DatosObs(dtsubObs, CodigoHu);
            //dtsubObs.Tables[0].TableName = "OBSURBANA";

            //rptReporte.Subreports["obsUrba.rpt"].SetDataSource(dtsubObs.Tables[0]);

            rptReporte.ExportToHttpResponse(ExportFormatType.Excel, Response, false, "ReporteInscripcionCatastral");

            crvReportes.DisplayGroupTree = false;
            crvReportes.HasViewList = false;
            crvReportes.HasSearchButton = true;
            crvReportes.HasExportButton = true;
            crvReportes.HasToggleGroupTreeButton = false;
            crvReportes.HasPrintButton = true;
            crvReportes.HasGotoPageButton = true;
            crvReportes.ToolPanelView = ToolPanelViewType.None;
            crvReportes.ReportSource = rptReporte;
            crvReportes.DataBind();
            //http://localhost:6456/reportes/reports.aspx?CodigoReporte=06
        }


        public void CargarLotexSector()
        {
            rptReporte = new ReportDocument();
            string reportPath;
            //Reporte Principal
            reportPath = Server.MapPath("lotexSector.rpt");
            DA.SIC_REPORTE rep = new DA.SIC_REPORTE();

            rptReporte.Load(reportPath);
            //rptReporte.SetDataSource(dtDatosGen.Tables[0]);//el data source

            //Subreporte Manzana Urbana
            DataSet dtSector = new DataSet();
            dtSector = new LotexSector();

            dtSector = rep.LotexSector(dtSector);
            dtSector.Tables[0].TableName = "DatosLotexSector";

            rptReporte.Subreports["AcumulacionSectorLote.rpt"].SetDataSource(dtSector.Tables[0]);

            // Subreporte Observacion
            //DataSet dtsubObs = new DataSet();
            //dtsubObs = new OBSURBANA();

            //dtsubObs = rep.DatosObs(dtsubObs, CodigoHu);
            //dtsubObs.Tables[0].TableName = "OBSURBANA";

            //rptReporte.Subreports["obsUrba.rpt"].SetDataSource(dtsubObs.Tables[0]);

            rptReporte.ExportToHttpResponse(ExportFormatType.Excel, Response, false, "ReporteSectorPorLote");

            crvReportes.DisplayGroupTree = false;
            crvReportes.HasViewList = false;
            crvReportes.HasSearchButton = true;
            crvReportes.HasExportButton = true;
            crvReportes.HasToggleGroupTreeButton = false;
            crvReportes.HasPrintButton = true;
            crvReportes.HasGotoPageButton = true;
            crvReportes.ToolPanelView = ToolPanelViewType.None;
            crvReportes.ReportSource = rptReporte;
            crvReportes.DataBind();
            //http://localhost:6456/reportes/reports.aspx?CodigoReporte=06
        }

        public void CargarSectorLoteUso()
        {
            rptReporte = new ReportDocument();
            string reportPath;
            reportPath = Server.MapPath("loteDetalleUso.rpt");
            DA.SIC_REPORTE rep = new DA.SIC_REPORTE();

            DataSet dtDatosGen = new DataSet();
            dtDatosGen = new LoteDetalleUso();

            dtDatosGen = rep.LoteDetalleUsoPredio(dtDatosGen);
            dtDatosGen.Tables[0].TableName = "DatosDetalleUso";

            rptReporte.Load(reportPath);
            rptReporte.SetDataSource(dtDatosGen.Tables[0]);//el data source

            //Subreporte Manzana Urbana
            //DataSet dtSector = new DataSet();
            //dtSector = new LotexSector();

            //dtSector = rep.LotexSector(dtSector);
            //dtSector.Tables[0].TableName = "DatosLotexSector";

            //rptReporte.Subreports["AcumulacionSectorLote.rpt"].SetDataSource(dtSector.Tables[0]);

            // Subreporte Observacion
            //DataSet dtsubObs = new DataSet();
            //dtsubObs = new OBSURBANA();

            //dtsubObs = rep.DatosObs(dtsubObs, CodigoHu);
            //dtsubObs.Tables[0].TableName = "OBSURBANA";

            //rptReporte.Subreports["obsUrba.rpt"].SetDataSource(dtsubObs.Tables[0]);

            rptReporte.ExportToHttpResponse(ExportFormatType.ExcelRecord, Response, false, "ReporteSectorDetalleUso");

            crvReportes.DisplayGroupTree = false;
            crvReportes.HasViewList = false;
            crvReportes.HasSearchButton = true;
            crvReportes.HasExportButton = true;
            crvReportes.HasToggleGroupTreeButton = false;
            crvReportes.HasPrintButton = true;
            crvReportes.HasGotoPageButton = true;
            crvReportes.ToolPanelView = ToolPanelViewType.None;
            crvReportes.ReportSource = rptReporte;
            crvReportes.DataBind();
            //http://localhost:6456/reportes/reports.aspx?CodigoReporte=06
        }

        public void CargarLoteSectorManzana()
        {
            rptReporte = new ReportDocument();
            string reportPath;
            //Reporte Principal
            reportPath = Server.MapPath("loteSectorManzana.rpt");
            DA.SIC_REPORTE rep = new DA.SIC_REPORTE();

            DataSet dtDatosGen = new DataSet();
            dtDatosGen = new LoteSectorManzana();

            dtDatosGen = rep.LoteSectorManzana(dtDatosGen);
            dtDatosGen.Tables[0].TableName = "DatosLotesSectorManzana";

            rptReporte.Load(reportPath);
            rptReporte.SetDataSource(dtDatosGen.Tables[0]);//el data source

            //Subreporte Manzana Urbana
            //DataSet dtSector = new DataSet();
            //dtSector = new LotexSector();

            //dtSector = rep.LotexSector(dtSector);
            //dtSector.Tables[0].TableName = "DatosLotexSector";

            //rptReporte.Subreports["AcumulacionSectorLote.rpt"].SetDataSource(dtSector.Tables[0]);

            // Subreporte Observacion
            //DataSet dtsubObs = new DataSet();
            //dtsubObs = new OBSURBANA();

            //dtsubObs = rep.DatosObs(dtsubObs, CodigoHu);
            //dtsubObs.Tables[0].TableName = "OBSURBANA";

            //rptReporte.Subreports["obsUrba.rpt"].SetDataSource(dtsubObs.Tables[0]);

            rptReporte.ExportToHttpResponse(ExportFormatType.ExcelRecord, Response, false, "ReporteSectorDetalleUso");

            crvReportes.DisplayGroupTree = false;
            crvReportes.HasViewList = false;
            crvReportes.HasSearchButton = true;
            crvReportes.HasExportButton = true;
            crvReportes.HasToggleGroupTreeButton = false;
            crvReportes.HasPrintButton = true;
            crvReportes.HasGotoPageButton = true;
            crvReportes.ToolPanelView = ToolPanelViewType.None;
            crvReportes.ReportSource = rptReporte;
            crvReportes.DataBind();
            //http://localhost:6456/reportes/reports.aspx?CodigoReporte=06
        }

        public void CargarReporteHojaInfo(string CodigoCertificado, string CodigoAnhoCertificado, string CodigoTipoCertificado, string rutaFile = "")
        {

            rptReporte = new ReportDocument();
            string reportPath;
            //Reporte Principal
            reportPath = Server.MapPath("certHojaInfo.rpt");

            DA.SIC_CERTIFICADO rep = new DA.SIC_CERTIFICADO();

            DataSet dtDatosGen = new DataSet();
            dtDatosGen = new HOJAGEN();

            dtDatosGen = rep.DatosGenerico(dtDatosGen, CodigoCertificado, CodigoAnhoCertificado, CodigoTipoCertificado);
            dtDatosGen.Tables[0].TableName = "HOJAGEN";

            rptReporte.Load(reportPath);

            String Distrito = dtDatosGen.Tables[0].Rows[0][26].ToString() + dtDatosGen.Tables[0].Rows[0][27].ToString();
            String Sector = dtDatosGen.Tables[0].Rows[0][28].ToString() + dtDatosGen.Tables[0].Rows[0][29].ToString();
            String Manzana = dtDatosGen.Tables[0].Rows[0][30].ToString() + dtDatosGen.Tables[0].Rows[0][31].ToString() + dtDatosGen.Tables[0].Rows[0][32].ToString();
            String Lote = dtDatosGen.Tables[0].Rows[0][33].ToString() + dtDatosGen.Tables[0].Rows[0][34].ToString() + dtDatosGen.Tables[0].Rows[0][35].ToString();

            string CODCATAS = Distrito + Sector + Manzana + Lote;

            DataSet dtFoto = new DataSet();
            dtFoto = new FOTO();
            dtFoto = rep.RecuperarFoto(dtFoto, CODCATAS);


            string ft = "";
            try
            {
                ft = dtFoto.Tables[0].Rows[0][7].ToString();
                ft = @ConfigurationManager.AppSettings["RUTA_FOTOS"] + ft.Substring(2);
                dtDatosGen.Tables[0].Rows[0][71] = ft;
            }
            catch (Exception ex)
            {
                ft = "";
            }

            String rutadd = @ConfigurationManager.AppSettings["RUTA_FILSERVER"];
            String RUTIMG = dtDatosGen.Tables[0].Rows[0][70].ToString();

            dtDatosGen.Tables[0].Rows[0][70] = rutadd + RUTIMG;

            rptReporte.SetDataSource(dtDatosGen.Tables[0]);//el data source

            // Subreporte titulares
            DataSet dtTitu = new DataSet();
            dtTitu = new HOJATITULAR();

            dtTitu = rep.DatosHojaTit(dtTitu, CodigoCertificado, CodigoAnhoCertificado, CodigoTipoCertificado, "01");
            dtTitu.Tables[0].TableName = "HOJATITULAR";

            rptReporte.Subreports["subTitulares.rpt"].SetDataSource(dtTitu.Tables[0]);

            // Subreporte LINDEROS
            DataSet dtsubLind = new DataSet();
            dtsubLind = new HOJACOLIND();

            dtsubLind = rep.DatosHojaLind(dtsubLind, CodigoCertificado, CodigoAnhoCertificado, CodigoTipoCertificado, "01");
            dtsubLind.Tables[0].TableName = "HOJACOLIND";

            rptReporte.Subreports["subColind.rpt"].SetDataSource(dtsubLind.Tables[0]);

            // Subreporte titulares ADIC
            DataSet dtTitu2 = new DataSet();
            dtTitu2 = new HOJATITUADIC();

            dtTitu2 = rep.DatosHojaTit(dtTitu2, CodigoCertificado, CodigoAnhoCertificado, CodigoTipoCertificado, "02");
            dtTitu2.Tables[0].TableName = "HOJATITUADIC";

            rptReporte.Subreports["subTitularesAdic.rpt"].SetDataSource(dtTitu2.Tables[0]);

            // Subreporte LINDEROS ADIC
            DataSet dtsubLind2 = new DataSet();
            dtsubLind2 = new HOJACOLADIC();

            dtsubLind2 = rep.DatosHojaLind(dtsubLind2, CodigoCertificado, CodigoAnhoCertificado, CodigoTipoCertificado, "02");
            dtsubLind2.Tables[0].TableName = "HOJACOLADIC";

            rptReporte.Subreports["subColindAdic.rpt"].SetDataSource(dtsubLind2.Tables[0]);

            // SUBREPORTE DE ANOTACIONES 
            DataSet dtsubAnotaciones = new DataSet();
            dtsubAnotaciones = new RESOLNUMERACIONANOTACION();

            dtsubAnotaciones = rep.ListarAnotaciondt(dtsubAnotaciones, CodigoCertificado, CodigoAnhoCertificado, CodigoTipoCertificado);
            dtsubAnotaciones.Tables[0].TableName = "DatosResolNumeracionAnotacion";

            rptReporte.Subreports["DetalleAnotacion.rpt"].SetDataSource(dtsubAnotaciones.Tables[0]);


            if (rutaFile != null)
            {
                rptReporte.ExportToDisk(ExportFormatType.PortableDocFormat, rutaFile + ".pdf");
                return;
            }
            rptReporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "HojaInformativa_" +
                CodigoCertificado + "_" + CodigoAnhoCertificado);

            crvReportes.DisplayGroupTree = false;
            crvReportes.HasViewList = false;
            crvReportes.HasSearchButton = true;
            crvReportes.HasExportButton = true;
            crvReportes.HasToggleGroupTreeButton = false;
            crvReportes.HasPrintButton = true;
            crvReportes.HasGotoPageButton = true;
            crvReportes.ToolPanelView = ToolPanelViewType.None;
            crvReportes.ReportSource = rptReporte;
            crvReportes.DataBind();
            //http://localhost:6456/reportes/reports.aspx?CodigoDistrito=1&CodigoSector=1&CodigoManzana=1&CodigoLote=1
        }

        public void CargarReporteCertAcumul(string CodigoCertificado, string CodigoAnhoCertificado, string CodigoTipoCertificado, string rutaFile = "")
        {
            rptReporte = new ReportDocument();
            string reportPath;
            //Reporte Principal
            reportPath = Server.MapPath("rptPlanoAcumulacion.rpt");

            DA.SIC_CERTIFICADO rep = new DA.SIC_CERTIFICADO();

            DataSet dtDatosGen = new DataSet();
            dtDatosGen = new ACUMULGEN();

            dtDatosGen = rep.DatosGenericoAcum(dtDatosGen, CodigoCertificado, CodigoAnhoCertificado, CodigoTipoCertificado);
            dtDatosGen.Tables[0].TableName = "ACUMULGEN";

            rptReporte.Load(reportPath);

            String rutadd = @ConfigurationManager.AppSettings["RUTA_FILSERVER"];
            String RUTIMG = dtDatosGen.Tables[0].Rows[0][34].ToString();

            dtDatosGen.Tables[0].Rows[0][34] = rutadd + RUTIMG;

            rptReporte.SetDataSource(dtDatosGen.Tables[0]);//el data source

            ////Subreporte titulares
            DataSet dtTitu = new DataSet();
            dtTitu = new ACUMTITU();

            dtTitu = rep.DatosTituAcum(dtTitu, CodigoCertificado, CodigoAnhoCertificado, CodigoTipoCertificado, "01");
            dtTitu.Tables[0].TableName = "ACUMTITU";

            rptReporte.Subreports["subTitu.rpt"].SetDataSource(dtTitu.Tables[0]);

            //// Subreporte DOCUMENTOS
            DataSet dtsubDoc = new DataSet();
            dtsubDoc = new ACUMDOC();

            dtsubDoc = rep.DatosDocAcum(dtsubDoc, CodigoCertificado, CodigoAnhoCertificado, CodigoTipoCertificado, "01");
            dtsubDoc.Tables[0].TableName = "ACUMDOC";

            rptReporte.Subreports["subDoc.rpt"].SetDataSource(dtsubDoc.Tables[0]);

            ////Subreporte Observacion
            DataSet dtsubObs = new DataSet();
            dtsubObs = new ACUMOBS();

            dtsubObs = rep.DatosObsAcum(dtsubObs, CodigoCertificado, CodigoAnhoCertificado, CodigoTipoCertificado, "01");
            dtsubObs.Tables[0].TableName = "ACUMOBS";

            rptReporte.Subreports["subObs.rpt"].SetDataSource(dtsubObs.Tables[0]);

            ////Subreporte titulares ADIC
            DataSet dtTituAdic = new DataSet();
            dtTituAdic = new ACUMTITUADIC();

            dtTituAdic = rep.DatosTituAcum(dtTituAdic, CodigoCertificado, CodigoAnhoCertificado, CodigoTipoCertificado, "02");
            dtTituAdic.Tables[0].TableName = "ACUMTITUADIC";

            rptReporte.Subreports["subTituAdic.rpt"].SetDataSource(dtTituAdic.Tables[0]);

            //// Subreporte DOCUMENTOS ADIC
            DataSet dtsubDocAdic = new DataSet();
            dtsubDocAdic = new ACUMDOCADIC();

            dtsubDocAdic = rep.DatosDocAcum(dtsubDocAdic, CodigoCertificado, CodigoAnhoCertificado, CodigoTipoCertificado, "02");
            dtsubDocAdic.Tables[0].TableName = "ACUMDOCADIC";

            rptReporte.Subreports["subDocAdic.rpt"].SetDataSource(dtsubDocAdic.Tables[0]);

            ////Subreporte Observacion ADIC
            DataSet dtsubObsAdic = new DataSet();
            dtsubObsAdic = new ACUMOBSADIC();

            dtsubObsAdic = rep.DatosObsAcum(dtsubObsAdic, CodigoCertificado, CodigoAnhoCertificado, CodigoTipoCertificado, "02");
            dtsubObsAdic.Tables[0].TableName = "ACUMOBSADIC";

            rptReporte.Subreports["subObsAdic.rpt"].SetDataSource(dtsubObsAdic.Tables[0]);

            if (rutaFile != null)
            {
                rptReporte.ExportToDisk(ExportFormatType.PortableDocFormat, rutaFile + ".pdf");
                return;
            }
            rptReporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "CertificadoAcumulacion_" +
                CodigoCertificado + "_" + CodigoAnhoCertificado);

            crvReportes.DisplayGroupTree = false;
            crvReportes.HasViewList = false;
            crvReportes.HasSearchButton = true;
            crvReportes.HasExportButton = true;
            crvReportes.HasToggleGroupTreeButton = false;
            crvReportes.HasPrintButton = true;
            crvReportes.HasGotoPageButton = true;
            crvReportes.ToolPanelView = ToolPanelViewType.None;
            crvReportes.ReportSource = rptReporte;
            crvReportes.DataBind();
            //http://localhost:6456/reportes/reports.aspx?CodigoDistrito=1&CodigoSector=1&CodigoManzana=1&CodigoLote=1
        }

        public void CargarReporteJurisdiccion(string CodigoCertificado, string CodigoAnhoCertificado, string CodigoTipoCertificado, string rutaFile = "")
        {
            rptReporte = new ReportDocument();
            string reportPath;
            //Reporte Principal
            reportPath = Server.MapPath("CertificadoJurisdiccion.rpt");

            DA.SIC_CERTIFICADO rep = new DA.SIC_CERTIFICADO();

            DataSet dtDatosGen = new DataSet();
            dtDatosGen = new JURISDICCION();

            dtDatosGen = rep.DatosRecuperardt(dtDatosGen, CodigoCertificado, CodigoAnhoCertificado, CodigoTipoCertificado);
            dtDatosGen.Tables[0].TableName = "DatosJurisdiccion";

            String CODCATAS = dtDatosGen.Tables[0].Rows[0]["CODCATASTRAL"].ToString();

            DA.SIC_REPORTE_UNIDAD repFoto = new DA.SIC_REPORTE_UNIDAD();

            DataSet dtFoto = new DataSet();
            dtFoto = new FOTO();
            dtFoto = repFoto.RecuperarFoto(dtFoto, CODCATAS);

            string ft = dtFoto.Tables[0].Rows[0][7].ToString();
            //ft = "http://192.168.41.149:7070/ACUWeb" + ft.Substring(2);
            ft = "http://192.168.41.149/ACUWeb" + ft.Substring(2);
            dtDatosGen.Tables[0].Rows[0]["RUTAFOTO"] = ft;


            rptReporte.Load(reportPath);
            rptReporte.SetDataSource(dtDatosGen.Tables[0]);//el data source



            DataSet dtPartidaElectronica = new DataSet();
            dtPartidaElectronica = new PartidaElectronicaCJ();

            dtPartidaElectronica = rep.DatosRecuperardt(dtDatosGen, CodigoCertificado, CodigoAnhoCertificado, CodigoTipoCertificado);
            dtPartidaElectronica.Tables[0].TableName = "DatosPartidaElectronica";

            rptReporte.Subreports["rptPartidaElectronica.rpt"].SetDataSource(dtPartidaElectronica.Tables[0]);


            DataSet dtFirmaSede = new DataSet();
            dtFirmaSede = new dsFirmaSedeElectronica();

            dtFirmaSede = rep.DatosRecuperardt(dtDatosGen, CodigoCertificado, CodigoAnhoCertificado, CodigoTipoCertificado);
            dtFirmaSede.Tables[0].TableName = "DatosFirma";

            rptReporte.Subreports["rptFirmaSedeElectronica.rpt"].SetDataSource(dtFirmaSede.Tables[0]);

            // SUBREPORTE DE ANOTACIONES 
            DataSet dtsubAnotaciones = new DataSet();
            dtsubAnotaciones = new DatosAnotacionC();

            dtsubAnotaciones = rep.ListarAnotaciondt(dtsubAnotaciones, CodigoCertificado, CodigoAnhoCertificado, CodigoTipoCertificado);
            dtsubAnotaciones.Tables[0].TableName = "DatosAnotacionC";

            rptReporte.Subreports["DetalleAnotacionCJUS.rpt"].SetDataSource(dtsubAnotaciones.Tables[0]);

            if (rutaFile != null)
            {
                rptReporte.ExportToDisk(ExportFormatType.PortableDocFormat, rutaFile + ".pdf");
                return;
            }
            rptReporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "CertificadoJurisdiccion_" +
                CodigoCertificado + "_" + CodigoAnhoCertificado);

            crvReportes.DisplayGroupTree = false;
            crvReportes.HasViewList = false;
            crvReportes.HasSearchButton = true;
            crvReportes.HasExportButton = true;
            crvReportes.HasToggleGroupTreeButton = false;
            crvReportes.HasPrintButton = true;
            crvReportes.HasGotoPageButton = true;
            crvReportes.ToolPanelView = ToolPanelViewType.None;
            crvReportes.ReportSource = rptReporte;
            crvReportes.DataBind();
            //http://localhost:6456/reportes/reports.aspx?CodigoCertificado=0001&CodigoAnhoCertificado=2018&CodigoReporte=CEJU
        }

        public void CargarReporteNomenclatura(string CodigoCertificado, string CodigoAnhoCertificado, string CodigoTipoCertificado, string rutaFile = "")
        {
            rptReporte = new ReportDocument();
            string reportPath;
            //Reporte Principal
            reportPath = Server.MapPath("CertificadoNomenclatura.rpt");

            DA.SIC_CERTIFICADO rep = new DA.SIC_CERTIFICADO();
            DA.SIC_CERTIFIDETA Deta = new DA.SIC_CERTIFIDETA();

            DataSet dtDatosGen = new DataSet();
            dtDatosGen = new NOMENCLATURA();

            dtDatosGen = rep.DatosRecuperardt(dtDatosGen, CodigoCertificado, CodigoAnhoCertificado, CodigoTipoCertificado);
            dtDatosGen.Tables[0].TableName = "DatosNomenclatura";

            String CODCATAS = dtDatosGen.Tables[0].Rows[0]["CODCATASTRAL"].ToString();

            DA.SIC_REPORTE_UNIDAD repFoto = new DA.SIC_REPORTE_UNIDAD();

            DataSet dtFoto = new DataSet();
            dtFoto = new FOTO();
            dtFoto = repFoto.RecuperarFoto(dtFoto, CODCATAS);

            string ft = dtFoto.Tables[0].Rows[0][7].ToString();
            ft = "http://192.168.41.149/ACUWeb" + ft.Substring(2);
            dtDatosGen.Tables[0].Rows[0]["RUTAFOTO"] = ft;

            rptReporte.Load(reportPath);
            rptReporte.SetDataSource(dtDatosGen.Tables[0]);//el data source

            //Subreporte Detalle
            DataSet dtDeta = new DataSet();
            dtDeta = new NOMENCLATURADETALLE();

            dtDeta = Deta.ListarNomenclaturaDettalle(dtDeta, CodigoCertificado, CodigoAnhoCertificado, CodigoTipoCertificado);
            dtDeta.Tables[0].TableName = "DatosNomenclaDetalle";

            rptReporte.Subreports["DetalleVias.rpt"].SetDataSource(dtDeta.Tables[0]);

            //Subreporte Urbanizacion
            DataSet dtsubLinderos = new DataSet();
            dtsubLinderos = new NOMENCLATURAURBANIZACION();

            dtsubLinderos = rep.ListarUrbanizaciondt(dtsubLinderos, CodigoCertificado, CodigoAnhoCertificado, CodigoTipoCertificado);
            dtsubLinderos.Tables[0].TableName = "DatosNomenclaUrba";

            rptReporte.Subreports["DetalleUrbanizacion.rpt"].SetDataSource(dtsubLinderos.Tables[0]);


            DataSet dtFirmaSede = new DataSet();
            dtFirmaSede = new dsFirmaSedeElectronica();

            dtFirmaSede = rep.DatosRecuperardt(dtDatosGen, CodigoCertificado, CodigoAnhoCertificado, CodigoTipoCertificado);
            dtFirmaSede.Tables[0].TableName = "DatosFirma";

            rptReporte.Subreports["rptFirmaSedeElectronica.rpt"].SetDataSource(dtFirmaSede.Tables[0]);


            DataSet dtDetalleLote = new DataSet();
            dtDetalleLote = new NOMENCLATURA();

            dtDetalleLote = rep.DatosRecuperardt(dtDatosGen, CodigoCertificado, CodigoAnhoCertificado, CodigoTipoCertificado);
            dtDetalleLote.Tables[0].TableName = "DatosNomenclatura";

            rptReporte.Subreports["rptDetalleLote.rpt"].SetDataSource(dtDetalleLote.Tables[0]);

            //Subreporte Anotaciones
            DataSet dtsubAnotaciones = new DataSet();
            dtsubAnotaciones = new DatosAnotacionC();

            dtsubAnotaciones = rep.ListarAnotaciondt(dtsubAnotaciones, CodigoCertificado, CodigoAnhoCertificado, CodigoTipoCertificado);
            dtsubAnotaciones.Tables[0].TableName = "DatosAnotacionCEJU";

            rptReporte.Subreports["DetalleAnotacionCJUS.rpt"].SetDataSource(dtsubAnotaciones.Tables[0]);




            /* // Subreporte Lotes Total
            DataSet dtsubLotTot = new DataSet();
            dtsubLotTot = new TOTALLOTE();//

            dtsubLotTot = rep.DatosLotTot(dtsubLotTot, CodigoDistrito, CodigoSector, CodigoManzana);
            dtsubLotTot.Tables[0].TableName = "TOTALLOTE";
            
            rptReporte.Subreports["lottotal.rpt"].SetDataSource(dtsubLotTot.Tables[0]);*/

            if (rutaFile != null)
            {
                rptReporte.ExportToDisk(ExportFormatType.PortableDocFormat, rutaFile + ".pdf");
                return;
            }
            rptReporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "CertificadoNomenclatura_" +
                CodigoCertificado + "_" + CodigoAnhoCertificado);

            crvReportes.DisplayGroupTree = false;
            crvReportes.HasViewList = false;
            crvReportes.HasSearchButton = true;
            crvReportes.HasExportButton = true;
            crvReportes.HasToggleGroupTreeButton = false;
            crvReportes.HasPrintButton = true;
            crvReportes.HasGotoPageButton = true;
            crvReportes.ToolPanelView = ToolPanelViewType.None;
            crvReportes.ReportSource = rptReporte;
            crvReportes.DataBind();
            //http://localhost:6456/reportes/reports.aspx?CodigoCertificado=0001&CodigoAnhoCertificado=2018&CodigoReporte=CENO
        }

        public void CargarResolucionNumeracion(string CodigoCertificado, string CodigoAnhoCertificado, string CodigoTipoCertificado, string rutaFile = "")
        {

            rptReporte = new ReportDocument();
            string reportPath;
            //Reporte Principal
            reportPath = Server.MapPath("rptCertificadoNumeracion.rpt");

            DA.SIC_CERTIFICADO rep = new DA.SIC_CERTIFICADO();
            DA.SIC_CERTIFIDETA Deta = new DA.SIC_CERTIFIDETA();

            DataSet dtDatosGen = new DataSet();
            dtDatosGen = new RESOLNUMERACION();

            dtDatosGen = rep.DatosRecuperardt(dtDatosGen, CodigoCertificado, CodigoAnhoCertificado, CodigoTipoCertificado);
            dtDatosGen.Tables[0].TableName = "DatosResolNumeracion";

            String CODCATAS = dtDatosGen.Tables[0].Rows[0]["CODCATASTRAL"].ToString();

            if (!string.IsNullOrEmpty(CODCATAS))
            {
                DA.SIC_REPORTE_UNIDAD repFoto = new DA.SIC_REPORTE_UNIDAD();

                DataSet dtFoto = new DataSet();
                dtFoto = new FOTO();
                dtFoto = repFoto.RecuperarFoto(dtFoto, CODCATAS);

                string ft = dtFoto.Tables[0].Rows[0][7].ToString();
                //ft = "http://192.168.41.149:7070/ACUWeb" + ft.Substring(2);
                ft = "http://192.168.41.149/ACUWeb" + ft.Substring(2);
                dtDatosGen.Tables[0].Rows[0]["RUTAFOTO"] = ft;
            }

            rptReporte.Load(reportPath);
            rptReporte.SetDataSource(dtDatosGen.Tables[0]);//el data source

            //Subreporte Detalle
            DataSet dtDeta = new DataSet();
            dtDeta = new RESOLNUMERACIONDETALLE();

            dtDeta = Deta.ListarResolNumeracionDettalle(dtDeta, CodigoCertificado, CodigoAnhoCertificado, CodigoTipoCertificado);
            dtDeta.Tables[0].TableName = "DatosResolNumeracionDetalle";

            rptReporte.Subreports["DetalleViasRNum.rpt"].SetDataSource(dtDeta.Tables[0]);


            ////Subreporte Anexo
            ////DataSet dtAnexo = new DataSet();
            ////dtAnexo = new RESOLNUMERACIONANEXO();

            ////dtAnexo = Deta.ListarResolNumeracionAnexo(dtDeta, CodigoCertificado, CodigoAnhoCertificado, CodigoTipoCertificado);
            ////dtAnexo.Tables[0].TableName = "DatosResolNumeracionAnexo";

            ////rptReporte.Subreports["DetalleViasAnexo.rpt"].SetDataSource(dtAnexo.Tables[0]);

            //Subreporte Anexo
            DataSet dtAnexo = new DataSet();
            dtAnexo = new RESOLNUMERACIONANEXO();

            dtAnexo = Deta.ListarResolNumeracionAnexo(dtDeta, CodigoCertificado, CodigoAnhoCertificado, CodigoTipoCertificado);

            dtAnexo.Tables[0].TableName = "DatosResolNumeracionAnexo";
            //rptReporte.Subreports["DetalleViasAnexo.rpt"].SetDataSource(dtAnexo.Tables[0]);            

            /*KRAMOS - 27/12/2019: Ordenar el reporte por el campo NUMERO*/
            //dtAnexo.Tables[0].Columns.Add("Correlativo", Type.GetType("System.Int32"));

            //int numerofilas = dtAnexo.Tables[0].Rows.Count;
            //for (int i = 0; i < numerofilas; i++)
            //{
            //    dtAnexo.Tables[0].Rows[i]["Correlativo"] = int.Parse(dtAnexo.Tables[0].Rows[i]["TXTNUMEROINT"].ToString());
            //}

            //dtAnexo.Tables[0].DefaultView.Sort = "Correlativo";
            /*KRAMOS - 27/12/2019*/

            rptReporte.Subreports["DetalleViasAnexo.rpt"].SetDataSource(dtAnexo.Tables[0].DefaultView.ToTable());



            //Subreporte Urbanizacion
            DataSet dtsubUrba = new DataSet();
            dtsubUrba = new NOMENCLATURAURBANIZACION();

            dtsubUrba = rep.ListarUrbanizaciondt(dtsubUrba, CodigoCertificado, CodigoAnhoCertificado, CodigoTipoCertificado);
            dtsubUrba.Tables[0].TableName = "DatosNomenclaUrba";

            rptReporte.Subreports["DetalleUrbanizacionRNum.rpt"].SetDataSource(dtsubUrba.Tables[0]);


            //SubReporte de Recibos
            DataSet dtRecibosCertificados = new DataSet();
            dtRecibosCertificados = new dsRecibosCertificados();

            dtRecibosCertificados = rep.ListarRecibosCertificadosdt(dtRecibosCertificados, CodigoCertificado, CodigoAnhoCertificado, CodigoTipoCertificado);
            dtRecibosCertificados.Tables[0].TableName = "dtRecibosCertificados";

            rptReporte.Subreports["RecibosCertificados.rpt"].SetDataSource(dtRecibosCertificados.Tables[0]);




            //Subreporte Detalle
            DataSet dtsubViaAnte = new DataSet();
            dtsubViaAnte = new RESOLNUMERACIONVIAANTE();

            dtsubViaAnte = Deta.ListarResolNumeracionViaAnte(dtsubViaAnte, CodigoCertificado, CodigoAnhoCertificado, CodigoTipoCertificado);
            dtsubViaAnte.Tables[0].TableName = "DatosResolNumeracionViaAnte";

            rptReporte.Subreports["DetalleViaAnte.rpt"].SetDataSource(dtsubViaAnte.Tables[0]);


            // Subreporte Detalle
            DataSet dtsubAnotaciones = new DataSet();
            dtsubViaAnte = new RESOLNUMERACIONANOTACION();

            dtsubAnotaciones = rep.ListarAnotaciondt(dtsubViaAnte, CodigoCertificado, CodigoAnhoCertificado, CodigoTipoCertificado);
            dtsubAnotaciones.Tables[0].TableName = "DatosResolNumeracionAnotacion";

            rptReporte.Subreports["DetalleAnotacion.rpt"].SetDataSource(dtsubAnotaciones.Tables[0]);

            if (rutaFile != null)
            {
                rptReporte.ExportToDisk(ExportFormatType.PortableDocFormat, rutaFile + ".pdf");
                return;
            }
            rptReporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "CertificadoNumeracion_" +
                CodigoCertificado + "_" + CodigoAnhoCertificado);

            crvReportes.DisplayGroupTree = false;
            crvReportes.HasViewList = false;
            crvReportes.HasSearchButton = true;
            crvReportes.HasExportButton = true;
            crvReportes.HasToggleGroupTreeButton = false;
            crvReportes.HasPrintButton = true;
            crvReportes.HasGotoPageButton = true;
            crvReportes.ToolPanelView = ToolPanelViewType.None;
            crvReportes.ReportSource = rptReporte;
            crvReportes.DataBind();
            //http://localhost:6456/reportes/reports.aspx?CodigoCertificado=0001&CodigoAnhoCertificado=2018&CodigoReporte=CENO
        }

        public void CargarCertificadoNumeracion(string CodigoCertificado, string CodigoAnhoCertificado, string CodigoTipoCertificado, string rutaFile = "")
        {
            rptReporte = new ReportDocument();
            string reportPath;
            //Reporte Principal
            reportPath = Server.MapPath("CertificadoNumeracion.rpt");

            DA.SIC_CERTIFICADO rep = new DA.SIC_CERTIFICADO();
            DA.SIC_CERTIFIDETA Deta = new DA.SIC_CERTIFIDETA();

            DataSet dtDatosGen = new DataSet();
            dtDatosGen = new RESOLNUMERACION();

            dtDatosGen = rep.DatosRecuperardt(dtDatosGen, CodigoCertificado, CodigoAnhoCertificado, CodigoTipoCertificado);
            dtDatosGen.Tables[0].TableName = "DatosCertNumeracion";

            rptReporte.Load(reportPath);
            rptReporte.SetDataSource(dtDatosGen.Tables[0]);//el data source

            //Subreporte Detalle
            DataSet dtDeta = new DataSet();
            dtDeta = new CERTNUMERACIONDETALLE();

            dtDeta = Deta.ListarCertNumeracionDetalle(dtDeta, CodigoCertificado, CodigoAnhoCertificado, CodigoTipoCertificado);
            dtDeta.Tables[0].TableName = "DatosCertNumeracionDetalle";

            rptReporte.Subreports["DetalleViaCNum.rpt"].SetDataSource(dtDeta.Tables[0]);

            //Subreporte Urbanizacion
            DataSet dtsubUrba = new DataSet();
            dtsubUrba = new NOMENCLATURAURBANIZACION();

            dtsubUrba = rep.ListarUrbanizaciondt(dtsubUrba, CodigoCertificado, CodigoAnhoCertificado, CodigoTipoCertificado);
            dtsubUrba.Tables[0].TableName = "DatosNomenclaUrba";

            rptReporte.Subreports["DetalleUrbanizacionCNum.rpt"].SetDataSource(dtsubUrba.Tables[0]);

            /*//Subreporte Detalle
            DataSet dtsubViaAnte = new DataSet();
            dtsubViaAnte = new RESOLNUMERACIONVIAANTE();

            dtsubViaAnte = Deta.ListarResolNumeracionViaAnte(dtsubViaAnte, CodigoCertificado, CodigoAnhoCertificado, CodigoTipoCertificado);
            dtsubViaAnte.Tables[0].TableName = "DatosResolNumeracionViaAnte";

            rptReporte.Subreports["DetalleViaAnte.rpt"].SetDataSource(dtsubViaAnte.Tables[0]);*/


            //Subreporte Detalle
            DataSet dtsubAnotaciones = new DataSet();
            dtsubAnotaciones = new RESOLNUMERACIONANOTACION();

            dtsubAnotaciones = rep.ListarAnotaciondt(dtsubAnotaciones, CodigoCertificado, CodigoAnhoCertificado, CodigoTipoCertificado);
            dtsubAnotaciones.Tables[0].TableName = "DatosResolNumeracionAnotacion";

            rptReporte.Subreports["DetalleAnotacionCNum.rpt"].SetDataSource(dtsubAnotaciones.Tables[0]);

            if (rutaFile != null)
            {
                rptReporte.ExportToDisk(ExportFormatType.PortableDocFormat, rutaFile + ".pdf");
                return;
            }
            rptReporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "ResolucionNumeracu_" +
                CodigoCertificado + "_" + CodigoAnhoCertificado);

            crvReportes.DisplayGroupTree = false;
            crvReportes.HasViewList = false;
            crvReportes.HasSearchButton = true;
            crvReportes.HasExportButton = true;
            crvReportes.HasToggleGroupTreeButton = false;
            crvReportes.HasPrintButton = true;
            crvReportes.HasGotoPageButton = true;
            crvReportes.ToolPanelView = ToolPanelViewType.None;
            crvReportes.ReportSource = rptReporte;
            crvReportes.DataBind();
            //http://localhost:6456/reportes/reports.aspx?CodigoCertificado=0001&CodigoAnhoCertificado=2018&CodigoReporte=CNMU
        }

        public void CargarReporteTest()
        {
            rptReporte = new ReportDocument();
            string reportPath;
            //Reporte Principal
            reportPath = Server.MapPath("submanzana/test.rpt");

            DA.SIC_REPORTE_MANZANA rep = new DA.SIC_REPORTE_MANZANA();

            DataSet dtDatosGen = new DataSet();
            dtDatosGen = new LINDEROSMANZANA();

            dtDatosGen = rep.DatosLindMz(dtDatosGen, "31", "09", "019");
            dtDatosGen.Tables[0].TableName = "LINDEROS";

            rptReporte.Load(reportPath);
            rptReporte.SetDataSource(dtDatosGen.Tables[0]);//el data source

            crvReportes.DisplayGroupTree = false;
            crvReportes.HasViewList = false;
            crvReportes.HasSearchButton = true;
            crvReportes.HasExportButton = true;
            crvReportes.HasToggleGroupTreeButton = false;
            crvReportes.HasPrintButton = true;
            crvReportes.HasGotoPageButton = true;
            crvReportes.ToolPanelView = ToolPanelViewType.None;
            crvReportes.ReportSource = rptReporte;
            crvReportes.DataBind();
            rptReporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Export");
            //http://localhost:6456/reportes/reports.aspx?CodigoDistrito=1&CodigoSector=1&CodigoManzana=1&CodigoLote=1
        }

        public void CargarReporteInformeVerificacion(string codigoInforme, string codigoAnio, string codigoTipoInforme, string CodigoCorrInforme)
        {
            rptReporte = new ReportDocument();
            string reportPath;
            //Reporte Principal
            reportPath = Server.MapPath("InformeVerificacion.rpt");

            DA.SIC_INFORME rep = new DA.SIC_INFORME();

            DataSet dtDatosGen = new DataSet();
            dtDatosGen = new INFORME();

            dtDatosGen = rep.DatosInforme(dtDatosGen, codigoInforme, codigoAnio, codigoTipoInforme, CodigoCorrInforme);
            dtDatosGen.Tables[0].TableName = "DatosInforme";

            rptReporte.Load(reportPath);
            rptReporte.SetDataSource(dtDatosGen.Tables[0]);//el data source

            // Informe Detalle
            DA.SIC_INFORMEDETA repDeta = new DA.SIC_INFORMEDETA();

            DataSet dtsubInforDet = new DataSet();
            dtsubInforDet = new INFORMEDETALLE();

            dtsubInforDet = repDeta.ListarInformeConstruccion(dtsubInforDet, codigoInforme, codigoAnio, codigoTipoInforme);
            dtsubInforDet.Tables[0].TableName = "InformeDetalleConst";

            rptReporte.Subreports["DetalleVerificacion.rpt"].SetDataSource(dtsubInforDet);


            rptReporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "InformeVerificacion");

            crvReportes.DisplayGroupTree = false;
            crvReportes.HasViewList = false;
            crvReportes.HasSearchButton = true;
            crvReportes.HasExportButton = true;
            crvReportes.HasToggleGroupTreeButton = false;
            crvReportes.HasPrintButton = true;
            crvReportes.HasGotoPageButton = true;
            crvReportes.ToolPanelView = ToolPanelViewType.None; http://localhost:6456/Reportes/Reports.aspx.cs
            crvReportes.ReportSource = rptReporte;
            crvReportes.DataBind();
            //http://localhost:6456/reportes/reports.aspx?codigoInforme=0002&CodigoAnio=2018&CodigoTipoInforme=010002&CodigoReporte=010002
        }

        public void CargarReporteInformeTecnico(string codigoInforme, string codigoAnio, string codigoTipoInforme, string CodigoCorrInforme)
        {
            rptReporte = new ReportDocument();
            string reportPath;
            //Reporte Principal
            reportPath = Server.MapPath("InformeTecnico.rpt");

            DA.SIC_INFORME rep = new DA.SIC_INFORME();

            DataSet dtDatosGen = new DataSet();
            dtDatosGen = new INFORME();

            dtDatosGen = rep.DatosInforme(dtDatosGen, codigoInforme, codigoAnio, codigoTipoInforme, CodigoCorrInforme);
            dtDatosGen.Tables[0].TableName = "DatosInforme";

            rptReporte.Load(reportPath);
            rptReporte.SetDataSource(dtDatosGen.Tables[0]);//el data source

            //DetalleTecnico
            DA.SIC_INFORMEDETA repDeta = new DA.SIC_INFORMEDETA();

            DataSet dtsubInforDet = new DataSet();
            dtsubInforDet = new INFORMEDETALLE();

            dtsubInforDet = repDeta.ListaInformeDetalle(dtsubInforDet, codigoInforme, codigoAnio, codigoTipoInforme, CodigoCorrInforme);
            dtsubInforDet.Tables[0].TableName = "DatosDetalleInforme";

            rptReporte.Subreports["DetalleTecnico.rpt"].SetDataSource(dtsubInforDet.Tables[0]);


            rptReporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "InformeTecnico");

            crvReportes.DisplayGroupTree = false;
            crvReportes.HasViewList = false;
            crvReportes.HasSearchButton = true;
            crvReportes.HasExportButton = true;
            crvReportes.HasToggleGroupTreeButton = false;
            crvReportes.HasPrintButton = true;
            crvReportes.HasGotoPageButton = true;
            crvReportes.ToolPanelView = ToolPanelViewType.None;
            crvReportes.ReportSource = rptReporte;
            crvReportes.DataBind();
            //http://localhost:6456/reportes/reports.aspx?codigoInforme=0002&CodigoAnio=2018&CodigoTipoInforme=010002&CodigoReporte=010002
        }

        public void CargarReporteInformeNumeracion(string codigoInforme, string codigoAnio, string codigoTipoInforme, string CodigoCorrInforme)
        {
            rptReporte = new ReportDocument();
            string reportPath;
            //Reporte Principal
            reportPath = Server.MapPath("InformeNumeracion.rpt");

            DA.SIC_INFORME rep = new DA.SIC_INFORME();

            DataSet dtDatosGen = new DataSet();
            dtDatosGen = new INFORME();

            dtDatosGen = rep.DatosInforme(dtDatosGen, codigoInforme, codigoAnio, codigoTipoInforme, CodigoCorrInforme);
            dtDatosGen.Tables[0].TableName = "DatosInforme";

            rptReporte.SetDataSource(dtDatosGen.Tables[0]);//el data source



            //DetalleNumeracion
            DA.SIC_INFORMEDETA repDeta = new DA.SIC_INFORMEDETA();

            DataSet dtsubInforDet = new DataSet();
            dtsubInforDet = new INFORMEDETALLE();

            dtsubInforDet = repDeta.ListaInformeDetalleNumeracion(dtsubInforDet, codigoInforme, codigoAnio, codigoTipoInforme);
            dtsubInforDet.Tables[0].TableName = "DatosDetalleInformeNum";

            rptReporte.Subreports["DetalleNumeracion.rpt"].SetDataSource(dtsubInforDet.Tables[0]);


            rptReporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "InformeNumeracion");




            rptReporte.Load(reportPath);




            crvReportes.DisplayGroupTree = false;
            crvReportes.HasViewList = false;
            crvReportes.HasSearchButton = true;
            crvReportes.HasExportButton = true;
            crvReportes.HasToggleGroupTreeButton = false;
            crvReportes.HasPrintButton = true;
            crvReportes.HasGotoPageButton = true;
            crvReportes.ToolPanelView = ToolPanelViewType.None;
            crvReportes.ReportSource = rptReporte;
            crvReportes.DataBind();
            //http://localhost:6456/reportes/reports.aspx?codigoInforme=0001&CodigoAnio=2018&CodigoTipoInforme=010003&CodigoReporte=01003
        }

        public void CargarReporteCartaCitacion(string codigoCarta, string codigoTipoInforme, string codigoAnio, string CodigoCorrCarta, string rutaFile = "")
        {
            rptReporte = new ReportDocument();
            string reportPath;
            //Reporte Principal
            reportPath = Server.MapPath("CartaCitacion.rpt");

            DA.SIC_CARTA rep = new DA.SIC_CARTA();

            DataSet dtDatosGen = new DataSet();
            dtDatosGen = new CARTA();

            dtDatosGen = rep.DatosCarta(dtDatosGen, codigoCarta, codigoTipoInforme, codigoAnio, CodigoCorrCarta);
            dtDatosGen.Tables[0].TableName = "DatosCarta";

            rptReporte.Load(reportPath);
            rptReporte.SetDataSource(dtDatosGen.Tables[0]);//el data source

            //DetalleTecnico
            //DA.SIC_INFORMEDETA repDeta = new DA.SIC_INFORMEDETA();

            //DataSet dtsubInforDet = new DataSet();
            //dtsubInforDet = new INFORMEDETALLE();

            //dtsubInforDet = repDeta.ListaInformeDetalle(dtsubInforDet, codigoInforme, codigoAnio, codigoTipoInforme);
            //dtsubInforDet.Tables[0].TableName = "DatosDetalleInforme";

            //rptReporte.Subreports["DetalleTecnico.rpt"].SetDataSource(dtsubInforDet.Tables[0]);

            if (rutaFile != null)
            {
                rptReporte.ExportToDisk(ExportFormatType.PortableDocFormat, rutaFile);
                return;
            }
            rptReporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "CartaCitacion");

            crvReportes.DisplayGroupTree = false;
            crvReportes.HasViewList = false;
            crvReportes.HasSearchButton = true;
            crvReportes.HasExportButton = true;
            crvReportes.HasToggleGroupTreeButton = false;
            crvReportes.HasPrintButton = true;
            crvReportes.HasGotoPageButton = true;
            crvReportes.ToolPanelView = ToolPanelViewType.None;
            crvReportes.ReportSource = rptReporte;
            crvReportes.DataBind();
            //http://localhost:6456/reportes/reports.aspx?codigoCarta=0002&codigoTipoInforme=010004&CodigoReporte=010004&codigoAnio=2018&CodigoCorrCarta=0001
        }

        public void CargarReporteCartaConstancia(string codigoCarta, string codigoTipoInforme, string codigoAnio, string CodigoCorrCarta, string rutaFile = "")
        {
            rptReporte = new ReportDocument();
            string reportPath;
            //Reporte Principal
            reportPath = Server.MapPath("CartaConstancia.rpt");

            DA.SIC_CARTA rep = new DA.SIC_CARTA();

            DataSet dtDatosGen = new DataSet();
            dtDatosGen = new CARTA();

            dtDatosGen = rep.DatosCarta(dtDatosGen, codigoCarta, codigoTipoInforme, codigoAnio, CodigoCorrCarta);
            dtDatosGen.Tables[0].TableName = "DatosCarta";

            rptReporte.Load(reportPath);
            rptReporte.SetDataSource(dtDatosGen.Tables[0]);//el data source

            //DetalleTecnico
            //DA.SIC_INFORMEDETA repDeta = new DA.SIC_INFORMEDETA();

            //DataSet dtsubInforDet = new DataSet();
            //dtsubInforDet = new INFORMEDETALLE();

            //dtsubInforDet = repDeta.ListaInformeDetalle(dtsubInforDet, codigoInforme, codigoAnio, codigoTipoInforme);
            //dtsubInforDet.Tables[0].TableName = "DatosDetalleInforme";

            //rptReporte.Subreports["DetalleTecnico.rpt"].SetDataSource(dtsubInforDet.Tables[0]);

            if (rutaFile != null)
            {
                rptReporte.ExportToDisk(ExportFormatType.PortableDocFormat, rutaFile + ".pdf");
                return;
            }
            rptReporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "CartaConstancia");

            crvReportes.DisplayGroupTree = false;
            crvReportes.HasViewList = false;
            crvReportes.HasSearchButton = true;
            crvReportes.HasExportButton = true;
            crvReportes.HasToggleGroupTreeButton = false;
            crvReportes.HasPrintButton = true;
            crvReportes.HasGotoPageButton = true;
            crvReportes.ToolPanelView = ToolPanelViewType.None;
            crvReportes.ReportSource = rptReporte;
            crvReportes.DataBind();
            //http://localhost:6456/reportes/reports.aspx?codigoCarta=0001&codigoTipoInforme=010005&CodigoReporte=010005&codigoAnio=2018&CodigoCorrCarta=0001
        }

        public void CargarReporteCartaGeneral(string codigoCarta, string codigoTipoInforme, string codigoAnio, string CodigoCorrCarta, string rutaFile = "")
        {
            rptReporte = new ReportDocument();
            string reportPath;
            //Reporte Principal
            reportPath = Server.MapPath("CartaGeneral.rpt");

            DA.SIC_CARTA rep = new DA.SIC_CARTA();

            DataSet dtDatosGen = new DataSet();
            dtDatosGen = new CARTA();

            dtDatosGen = rep.DatosCarta(dtDatosGen, codigoCarta, codigoTipoInforme, codigoAnio, CodigoCorrCarta);
            dtDatosGen.Tables[0].TableName = "DatosCarta";

            rptReporte.Load(reportPath);
            rptReporte.SetDataSource(dtDatosGen.Tables[0]);//el data source

            //DetalleTecnico
            //DA.SIC_INFORMEDETA repDeta = new DA.SIC_INFORMEDETA();

            //DataSet dtsubInforDet = new DataSet();
            //dtsubInforDet = new INFORMEDETALLE();

            //dtsubInforDet = repDeta.ListaInformeDetalle(dtsubInforDet, codigoInforme, codigoAnio, codigoTipoInforme);
            //dtsubInforDet.Tables[0].TableName = "DatosDetalleInforme";

            //rptReporte.Subreports["DetalleTecnico.rpt"].SetDataSource(dtsubInforDet.Tables[0]);

            if (rutaFile != null)
            {
                rptReporte.ExportToDisk(ExportFormatType.PortableDocFormat, rutaFile);
                return;
            }
            rptReporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "CartaGeneral");

            crvReportes.DisplayGroupTree = false;
            crvReportes.HasViewList = false;
            crvReportes.HasSearchButton = true;
            crvReportes.HasExportButton = true;
            crvReportes.HasToggleGroupTreeButton = false;
            crvReportes.HasPrintButton = true;
            crvReportes.HasGotoPageButton = true;
            crvReportes.ToolPanelView = ToolPanelViewType.None;
            crvReportes.ReportSource = rptReporte;
            crvReportes.DataBind();
            //http://localhost:6456/reportes/reports.aspx?codigoCarta=0001&codigoTipoInforme=010005&CodigoReporte=010005&codigoAnio=2018&CodigoCorrCarta=0001
        }
        private void CargarReporteEstadisticosUnidadPorUso(string codigoCertificado, string codigoAnio, string codigoTipoInforme)
        {
            var oStreamReportes = new List<MemoryStream>();

            if (codigoTipoInforme == "01")
            {
                DA.SIC_REPORTE rep = new DA.SIC_REPORTE();
                DataSet dtEstadisticaGeneral = new DataSet();
                dtEstadisticaGeneral = new unidadxSector();
                dtEstadisticaGeneral = rep.EstadisticoGeneralUso(dtEstadisticaGeneral, codigoAnio);


                rptReporte = new ReportDocument();
                rptReporte.Load(Server.MapPath("rptEstadisticaUnidadUsosGeneral.rpt"));
                dtEstadisticaGeneral.Tables[0].TableName = "TB_ESTADISTICA";
                rptReporte.SetDataSource(dtEstadisticaGeneral.Tables[0]);//el data source
                rptReporte.SetParameterValue("AnioReporte", codigoAnio);
                oStreamReportes.Add(rptReporte.ExportToPdfMemoryStream());


                var rptGraficoEstadistico = new ReportDocument();
                rptGraficoEstadistico.Load(Server.MapPath("rptEstadisticaUnidadUsosGeneralGrafico.rpt"));
                rptGraficoEstadistico.Database.Tables["TB_ESTADISTICA"].SetDataSource(dtEstadisticaGeneral);
                oStreamReportes.Add(rptGraficoEstadistico.ExportToPdfMemoryStream());
            }
            else
            {
                DA.SIC_REPORTE rep = new DA.SIC_REPORTE();
                DataSet dtEstadisticaGeneral = new DataSet();
                dtEstadisticaGeneral = new unidadxSector();
                dtEstadisticaGeneral = rep.EstadisticoGeneralUsoAnio(dtEstadisticaGeneral, codigoAnio);


                rptReporte = new ReportDocument();
                rptReporte.Load(Server.MapPath("rptEstadisticaUnidadUsosGeneralAnio.rpt"));
                dtEstadisticaGeneral.Tables[0].TableName = "TB_ESTADISTICAANIO";
                rptReporte.SetDataSource(dtEstadisticaGeneral.Tables[0]);//el data source
                rptReporte.SetParameterValue("AnioReporte", codigoAnio);
                oStreamReportes.Add(rptReporte.ExportToPdfMemoryStream());


                var rptGraficoEstadistico = new ReportDocument();
                rptGraficoEstadistico.Load(Server.MapPath("rptEstadisticaUnidadUsosGeneralGraficoAnio.rpt"));
                rptGraficoEstadistico.Database.Tables["TB_ESTADISTICAANIO"].SetDataSource(dtEstadisticaGeneral);
                oStreamReportes.Add(rptGraficoEstadistico.ExportToPdfMemoryStream());
            }


            var rptGlosarioTerminosUso = new ReportDocument();
            rptGlosarioTerminosUso.Load(Server.MapPath("rptGlosarioTerminosUsos.rpt"));
            oStreamReportes.Add(rptGlosarioTerminosUso.ExportToPdfMemoryStream());







            var pdfReport = MailHelpers.CombinarArchivosPDF(oStreamReportes);


            crvReportes.ReportSource = pdfReport;
            crvReportes.DataBind();

            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.BinaryWrite(pdfReport);
            Response.Flush();
            Response.Close();




        }

    }
}