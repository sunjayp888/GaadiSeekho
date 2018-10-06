using System.Web;
using System.Web.Optimization;

namespace Gadi
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.ResetAll();

            bundles.Add(new ScriptBundle("~/Scripts/bower").Include(
                "~/bower_components/jquery/dist/jquery.min.js",
                "~/bower_components/jquery-validation/dist/jquery.validate.min.js",
                "~/bower_components/jquery-validation-unobtrusive/jquery.validate.unobtrusive.min.js",
                "~/bower_components/bootstrap/dist/js/bootstrap.min.js",
                "~/bower_components/moment/min/moment.min.js",
                "~/bower_components/angular/angular.min.js",
                "~/bower_components/angular-animate/angular-animate.min.js",
                "~/bower_components/angular-sanitize/angular-sanitize.min.js",
                "~/bower_components/angular-bootstrap/ui-bootstrap-tpls.min.js",
                "~/bower_components/angular-responsive-tables/release/angular-responsive-tables.min.js",
                "~/bower_components/angular-ui-select/dist/select.min.js",
                "~/bower_components/angular-ui-uploader/dist/uploader.min.js",
                //"~/bower_components/angular-img-cropper/dist/angular-img-cropper.min.js",
                "~/bower_components/angular-ui-mask/dist/mask.min.js",
                "~/bower_components/Chart.js/dist/Chart.min.js",
                "~/bower_components/bootbox/bootbox.js",
                "~/bower_components/ngBootbox/ngBootbox.js",
                "~/bower_components/cookieconsent/build/cookieconsent.min.js",
                "~/bower_components/ng-file-upload/ng-file-upload-shim.min.js",
                "~/bower_components/ng-file-upload/ng-file-upload.min.js",
                "~/bower_components/pnotify/dist/pnotify.js",
                "~/bower_components/pnotify/dist/pnotify.buttons.js",
                "~/bower_components/pnotify/dist/pnotify.mobile.js",
                "~/bower_components/pnotify/dist/pnotify.desktop.js",
                "~/bower_components/adminbsb-materialdesign/plugins/node-waves/waves.min.js",
                "~/bower_components/adminbsb-materialdesign/js/admin.js",
                "~/bower_components/adminbsb-materialdesign/plugins/js/materialize.min.js",
                "~/bower_components/adminbsb-materialdesign/plugins/node-waves/waves.min.js"
                ));

            //bundles.Add(new ScriptBundle("~/Scripts/SignalR").Include(
            //    "~/Scripts/jquery.signalR-2.2.2.min.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Application").Include(
                "~/Scripts/Angular/Moment.js",
                "~/Scripts/Angular/app.js",
                "~/Scripts/Angular/Filters/*.js",
                //"~/Scripts/Angular/Decorators/*.js",
                "~/Scripts/Angular/Prototypes/*.js",
                "~/Scripts/Angular/Controllers/*.js",
                //"~/Scripts/Angular/Factories/*.js",
                "~/Scripts/Angular/Services/*.js",
                "~/Scripts/Angular/Directives/*.js",
                "~/Scripts/App/*.js"
                ));


            bundles.Add(new StyleBundle("~/Content/bower").Include(
                 "~/bower_components/angular-responsive-tables/release/angular-responsive-tables.min.css",
                 "~/bower_components/angular-ui-select/dist/select.min.css",
                 "~/bower_components/font-awesome/css/font-awesome.min.css",
                 "~/bower_components/less-space/dist/less-space.min.css",
                 "~/bower_components/bootstrap-side-navbar/source/assets/stylesheets/navbar-fixed-side.css",
                 "~/bower_components/bootstrap-daterangepicker/daterangepicker.css",
                 "~/bower_components/datatables.net-bs/css/dataTables.bootstrap.min.css",
                 "~/bower_components/cookieconsent/build/cookieconsent.min.css",
                 "~/bower_components/pnotify/dist/pnotify.css",
                 "~/bower_components/pnotify/dist/pnotify.buttons.css",
                 "~/bower_components/pnotify/dist/pnotify.mobile.css",
                 "~/bower_components/adminbsb-materialdesign/css/materialize.css"
                 ));


            bundles.Add(new StyleBundle("~/Content/Styles").Include(
                "~/Content/css/*.min.css",
                "~/Content/bootstrap.min.css",
                "~/Content/fonts/css/font-awesome.css"
                ));

            // slimScroll
            bundles.Add(new ScriptBundle("~/plugins/slimScroll").Include(
                "~/Scripts/plugins/slimscroll/jquery.slimscroll.min.js"));

            // Custom
            bundles.Add(new ScriptBundle("~/plugins/Custom").Include(
                "~/Scripts/plugins/Custom/admin.js"
                ));

            // bootstrap-select
            bundles.Add(new ScriptBundle("~/plugins/bootstrap-select").Include(
                "~/Scripts/plugins/bootstrap-select/bootstrap-select.min.js"
            ));

            //node - waves
            //bundles.Add(new ScriptBundle("~/plugins/node-waves").Include(
            //    "~/Scripts/plugins/node-waves/waves.min.js"
            //));

            //node - waves
            bundles.Add(new ScriptBundle("~/plugins/jquery-countto").Include(
                "~/Scripts/plugins/jquery-countto/jquery-countto.js"
            ));



            //BundleTable.EnableOptimizations = true;
        }
    }
}
