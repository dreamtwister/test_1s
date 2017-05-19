using System.Web;
using System.Web.Optimization;

namespace Books
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                        "~/Scripts/DataTables/jquery.dataTables.min.js",
                        "~/Scripts/DataTables/dataTables.bootstrap.js"));

            //bundles.Add(new ScriptBundle("~/bundles/blueimpgallery").Include(
            //            "~/Scripts/BlueimpGallery/blueimp-gallery.js",
            //            "~/Scripts/BlueimpGallery/gallery-modal.js"));

            //bundles.Add(new ScriptBundle("~/bundles/fileupload").Include(
            //            "~/Scripts/FileUpload/jquery.fileupload.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //bundles.Add(new ScriptBundle("~/bundles/fluentvalidation").Include(
            //            "~/Scripts/fluentvalidation.validate.unobtrusive.js"));

            bundles.Add(new StyleBundle("~/Content/datatables/css").Include(
                      "~/Content/DataTables/css/dataTables.bootstrap.css"));

            //bundles.Add(new StyleBundle("~/Content/fileupload/css").Include(
            //            "~/Content/FileUpload/jquery.fileupload.css"));


            bundles.Add(new ScriptBundle("~/bundles/multiselect").Include(
                        "~/Scripts/MultiSelect/magicsuggest-min.js"));

            bundles.Add(new StyleBundle("~/Content/multiselect/css").Include(
                      "~/Content/MultiSelect/magicsuggest-min.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                      "~/Content/themes/base/all.css"));
        }
    }
}
