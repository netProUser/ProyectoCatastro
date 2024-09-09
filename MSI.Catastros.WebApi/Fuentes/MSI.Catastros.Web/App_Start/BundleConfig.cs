using System.Web;
using System.Web.Optimization;

namespace MSI.Catastros.Web
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, consulte http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información sobre los formularios. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/assets/vendor/bootstrap/css/bootstrap.min.css",
                      "~/Binarios/Content/toastr.min.css",
                      "~/Binarios/Content/bootstrap-datepicker.min.css"
                      //,"~/Content/site.css"
                      ));

            bundles.Add(new StyleBundle("~/tagsinput/css").Include(
                      "~/assets/vendor/bootstrap-tagsinput/bootstrap-tagsinput.css"));

            bundles.Add(new ScriptBundle("~/bundles/unobtrusiveajax")
              .Include("~/Scripts/jquery.unobtrusive-ajax.js")
              );

            bundles.Add(new ScriptBundle("~/bundles/validate").Include(
                      "~/Scripts/jquery.validate.js",
                      "~/Scripts/jquery.validate.unobtrusive.js"));
            bundles.Add(new ScriptBundle("~/bundles/inputmask").Include(
                      "~/assets/vendor/inputmask/js/inputmask.js",
                      "~/assets/vendor/inputmask/js/inputmask.numeric.extensions.js",
                      "~/assets/vendor/inputmask/js/jquery.inputmask.js"));

            bundles.Add(new ScriptBundle("~/bundles/toastr").Include(
                      "~/Scripts/toastr.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/tagsinput").Include(
                      "~/Scripts/bootstrap-tagsinput.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/general").Include(
                      "~/Scripts/js_General.js"));

            bundles.Add(new ScriptBundle("~/bundles/weightMask").Include(
                      "~/Scripts/jQuery.weightMask.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-datepicker").Include(
                      "~/Scripts/bootstrap-datepicker.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootbox").Include(
                      "~/Scripts/bootbox.min.js"));

        }
    }
}
