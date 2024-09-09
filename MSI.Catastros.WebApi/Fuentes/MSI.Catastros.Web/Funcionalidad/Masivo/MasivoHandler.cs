using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BL = MSI.Catastros.BusinessLogic;
using BE = MSI.Catastros.BusinessEntities;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using MSI.Catastros.Utiles;
using MSI.Catastros.Web.Funcionalidad.ProgramarInspeccion;
using System.IO;
using System.Data;
using ClosedXML.Excel;
namespace MSI.Catastros.Web.Funcionalidad.Masivo
{
    public class MasivoHandler
    {
        public List<CodigoCatastralAsignado> ListarMasivo(Configuacion modelo)
        {
            #region Obtener datos
            BE.SIC_UNIDADMAS entQuery = new BE.SIC_UNIDADMAS();
            entQuery.CODTIPOSOLI = modelo.CODTIPOSOLI;
            entQuery.CODNUMESOLI = modelo.CODNUMESOLI;
            entQuery.CODANOSOLI = modelo.CODANOSOLI;
            entQuery.CODUNI = Convert.ToInt32(modelo.CODUNI);
            entQuery.CORRELUNIDAD = modelo.CORRELUNIDAD;

            #endregion
            #region Asignar al ViewModel

            List<CodigoCatastralAsignado> listaCatastral = new List<CodigoCatastralAsignado>();

            IEnumerable<BE.SIC_UNIDADMAS> queryResult = new BL.SIC_UNIDADMAS().Buscar(entQuery);
            int i = 0;
            foreach (var item in queryResult)
            {
                listaCatastral.Add(new CodigoCatastralAsignado
                {
                    TXTTIPOINTEDESCRIPCION = item.TXTTIPOINTEDESCRIPCION,
                    CODANOSOLI = item.CODANOSOLI,
                    CODTIPOSOLI = item.CODTIPOSOLI,
                    CODNUMESOLI = item.CODNUMESOLI,
                    CODUNI = item.CODUNI.ToString(),
                    CORRELUNIDAD = item.CORRELUNIDAD,

                    Distrito = item.CODDISTRITO,
                    Sec = item.CODSECTOR,
                    Manzana = item.CODMANZANA,
                    Lote = item.CODLOTE,
                    Ed = item.CODEDIFICACION,
                    Entr = item.CODENTRADA,
                    Piso = item.CODPISO,
                    Unidad = item.CODUNIDAD,
                    UbicacionPredio = "",
                    CANTDIRECCION = item.DIRECCION,
                    CANTCLASIFICACION = item.CLASIFICACION,
                    CANTTITULARIDAD = item.TITULARIDAD,
                    CANTOBSERVACION = item.OBSERVACION,
                    CANTLINEASCONSTRUCTIVAS = item.LINEASCONSTRUCTIVAS,
                    CANTOTRASINSTALACIONES = item.OTRASINSTALACIONES,
                    CANTAREATERRENO = item.AREATERRENO,
                    //Titular = titular,
                    Indice = (i++)
                });
            }
            #endregion
            return listaCatastral;
        }
        public MemoryStream Excel(Configuacion modelo)
        {
            #region Obtener datos
            BE.SIC_UNIDADMAS entQuery = new BE.SIC_UNIDADMAS();
            entQuery.CODTIPOSOLI = modelo.CODTIPOSOLI;
            entQuery.CODNUMESOLI = modelo.CODNUMESOLI;
            entQuery.CODANOSOLI = modelo.CODANOSOLI;
            entQuery.CODUNI = Convert.ToInt32(modelo.CODUNI);
            entQuery.CORRELUNIDAD = modelo.CORRELUNIDAD;

            DataTable dt = new BL.SIC_UNIDADMAS().Excel(entQuery);

            #endregion

            using (XLWorkbook workbook = new XLWorkbook())
            {
                var ws = workbook.Worksheets.Add(modelo.CODTIPOSOLI + modelo.CODNUMESOLI + modelo.CODANOSOLI + modelo.CODUNI + modelo.CORRELUNIDAD);
                ws.Range("A1:AM1").Merge().Value = "INDEPENDIZACION";
                ws.Range("A1:AM1").Merge().Style.Font.FontSize = 20;
                ws.Range("A1:AM1").Merge().Style.Font.Bold = true;
                ws.Range("A1:AM1").Merge().Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Range("A1:AM1").Merge().Style.Fill.BackgroundColor = XLColor.Black;
                ws.Range("A1:AM1").Merge().Style.Font.FontColor = XLColor.White;
                /**/

                /**/
                ws.Row(1).Height = 30;
                //ws.Range("A2:AL2").Merge().Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //ws.Range("A2:AL2").Merge().Style.Fill.BackgroundColor = XLColor.Black;
                //ws.Range("A2:AL2").Merge().Style.Font.FontColor = XLColor.White;
                ws.Range("A2:AM2").Style.Font.Bold = true;
                ws.Range("A2:AM2").Style.Font.FontSize = 12;
                ws.Range("A3:AM3").Style.Font.Bold = true;
                ws.Range("A3:AM3").Style.Font.FontSize = 12;
                ws.Range("A3:AM3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;


                ws.Range("A2:A3").Merge().Value = "N°";

                ws.Range("B2:B3").Merge().Value = "CODIGO CATASTRA";
                ws.Range("C2:C3").Merge().Value = "FECHA DE CORTE";
                ws.Range("D2:D3").Merge().Value = "NUMERACION OFICIAL";
                ws.Range("D2:D3").Merge().Style.Alignment.WrapText = true;
                ws.Range("E2:E3").Merge().Value = "NUMERACION CAMPO";
                ws.Range("E2:E3").Merge().Style.Alignment.WrapText = true;
                ws.Range("F2:F3").Merge().Value = "NIVEL";

                ws.Range("G2:H2").Merge().Value = "ANT. DE LA CONST.";
                ws.Range("G3").Merge().Value = "MES";
                ws.Range("H3").Merge().Value = "AÑO";

                ws.Range("I2:I3").Merge().Value = "M. ESTRUCTURAL";
                ws.Range("J2:J3").Merge().Value = "ESTADO DE CONS.";

                ws.Range("K2:Q2").Merge().Value = "CATEGOR.";
                ws.Range("K3").Merge().Value = "M";
                ws.Range("L3").Merge().Value = "T";
                ws.Range("M3").Merge().Value = "P";
                ws.Range("N3").Merge().Value = "P Y V";
                ws.Range("O3").Merge().Value = "R";
                ws.Range("P3").Merge().Value = "B";
                ws.Range("Q3").Merge().Value = "I, E Y S";

                ws.Range("R2:R3").Merge().Value = "AREA VERIFICADA";
                ws.Range("S2:S3").Merge().Value = "AREA OCUPADA";
                ws.Range("T2:T3").Merge().Value = "% OFICIAL";
                ws.Range("U2:U3").Merge().Value = "CLASIFICACION";
                ws.Range("V2:V3").Merge().Value = "TIPO";
                ws.Range("W2:W3").Merge().Value = "INSCRIPCION";
                ws.Range("X2:X3").Merge().Value = "COD. DE USO";
                ws.Range("Y2:Y3").Merge().Value = "TIPO DE LLENADO";
                ws.Range("Z2:Z3").Merge().Value = "PARTIDA REGISTRAL.";
                ws.Range("AA2:AA3").Merge().Value = "ASIENTO";
                ws.Range("AB2:AB3").Merge().Value = "FECHA DOCUMENTO RRPP";
                ws.Range("AC2:AC3").Merge().Value = "COD. CONTRIBUYENTE";
                ws.Range("AD2:AD3").Merge().Value = "CONDICION PROPIEDAD";
                ws.Range("AE2:AE3").Merge().Value = "% DE CONDOMINIO";
                ws.Range("AF2:AF3").Merge().Value = "OBSERVACIONES COMUNES";
                ws.Range("AF2:AF3").Merge().Style.Alignment.WrapText = true;
                ws.Range("AG2:AG3").Merge().Value = "OBSERVACIONES INDIVIDUALES";
                ws.Range("AG2:AG3").Merge().Style.Alignment.WrapText = true;
                ws.Range("AH2:AM2").Merge().Value = "OTRAS INSTALACIONES.";
                ws.Range("AH3").Merge().Value = "COD.";
                ws.Range("AI3").Merge().Value = "CAPAC.";
                ws.Range("AJ3").Merge().Value = "CANT.";
                ws.Range("AK3").Merge().Value = "MES";
                ws.Range("AL3").Merge().Value = "AÑO";
                ws.Range("AM3").Merge().Value = "ESTADO";

                ws.Cell(4, 1).InsertData(dt);
                ws.Columns().AdjustToContents();



                using (MemoryStream stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    //return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Grid.xlsx");
                    return stream;
                }
            }

            //foreach (DataRow row in dt.Rows)
            //{
            //    dt.Rows.Add();
            //    for (int i = 0; i < row.Cells.Count; i++)
            //    {
            //        dt.Rows[dt.Rows.Count - 1][i] = row.Cells[i].Text;
            //    }
            //}
            //using (XLWorkbook wb = new XLWorkbook())
            //{
            //    wb.Worksheets.Add(dt);
            //    using (MemoryStream stream = new MemoryStream())
            //    {
            //        wb.SaveAs(stream);
            //        //return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Grid.xlsx");
            //        return stream;
            //    }
            //}

        }
        public Nullable<bool> ProcesarMasivo(Configuacion modelo)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();

            foreach (var item in modelo.configuracion)
            {
                #region Grabar Masivo
                var Unidad = new BE.SIC_UNIDADMAS()
                {
                    CODUNI = Convert.ToInt32(modelo.CODUNI),
                    CORRELUNIDAD = modelo.CORRELUNIDAD,

                    CODTIPOSOLI = modelo.CODTIPOSOLI,
                    CODNUMESOLI = modelo.CODNUMESOLI,
                    CODANOSOLI = modelo.CODANOSOLI,

                    CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                    CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                    CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0'),
                    CODSECTOR = modelo.sector.ToUpper().PadLeft(2, '0'),
                    CODMANZANA = modelo.manzana.ToUpper().PadLeft(2, '0'),
                    CODLOTE = modelo.lote.ToUpper().PadLeft(2, '0'),

                    CODEDIFICACION = item.edificacion.ToUpper(),
                    CODENTRADA = item.entrada.ToUpper(),
                    CODPISO = item.piso.ToUpper(),
                    NROUNIDADES = item.nroUnidad.ToString(),
                    CODTIPONINTE = item.tipoInscripcion,
                    CODUSUARIO = VariablesWeb.IdUsuarioIntento
                };

                entSIC_RETORNO = new BL.SIC_UNIDADMAS().Grabar(Unidad);
                #endregion
            }
            return entSIC_RETORNO.Ok;
        }
        public Nullable<bool> ProcesarClasifiacion(ClasificacionUnidadViewModel modelo)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();

            #region Actualizar Maestro Inspectores por Unidad
            var Unidad = new BE.SIC_UNIDAD()
            {
                CODUNI = Convert.ToInt32(modelo.CODUNI),
                CODCLASIFICA = modelo.CodigoClasificacionPredio,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento
            };
            entSIC_RETORNO = new BL.SIC_UNIDAD().Actualizar(Unidad);
            #endregion

            return entSIC_RETORNO.Ok;
        }
    }
}