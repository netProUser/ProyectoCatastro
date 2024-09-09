using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;

namespace MSI.Catastros.Web.Helpers
{
    public static class ReportDocumentExtensions
    {
        public static MemoryStream ExportToPdfMemoryStream(this ReportDocument prdDocument)
        {
            var result = new MemoryStream();
            using (var fileStream = prdDocument.ExportToStream(ExportFormatType.PortableDocFormat))
            {
                fileStream.CopyTo(result);
            }
            return result;
        }

        public static void Destroy(this ReportDocument reporte)
        {
            if (reporte == null) return;
            reporte.Close();
            reporte.Dispose();
            reporte = null;
        }
    }
}