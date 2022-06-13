using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace CBFRM
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
  //"~/Content/assets/global/plugins/jQuery v3.4.1.js",
  "~/Content/assets/global/plugins/jquery.min.js",
  "~/Content/assets/global/plugins/bootstrap/js/bootstrap.min.js",
  "~/Content/assets/global/plugins/js.cookie.min.js",
  "~/Content/assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js",
  "~/Content/assets/global/plugins/jquery.blockui.min.js",
  "~/Content/assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js",
  "~/Content/assets/global/scripts/app.min.js",
  "~/Content/assets/layouts/layout/scripts/layout.min.js",
  "~/Content/assets/layouts/layout/scripts/demo.min.js",
  "~/Content/assets/layouts/global/scripts/quick-sidebar.min.js",
  "~/Content/assets/layouts/global/scripts/quick-nav.min.js",
  "~/Content/assets/global/plugins/bootstrap-sweetalert/sweetalert.min.js",
 "~/Content/assets/pages/scripts/ui-sweetalert.min.js"));




            bundles.Add(new StyleBundle("~/Content/css").Include(


  "~/Content/assets/global/plugins/font-awesome/css/font-awesome.min.css",
  "~/Content/assets/global/plugins/simple-line-icons/simple-line-icons.min.css",
  "~/Content/assets/global/plugins/bootstrap/css/bootstrap.min.css",
  "~/Content/assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css",

  "~/Content/assets/global/css/components.css",
  "~/Content/assets/global/css/plugins.min.css",
  "~/Content/assets/layouts/layout/css/layout.min.css",
  "~/Content/assets/layouts/layout/css/themes/darkblue.min.css",
  "~/Content/assets/layouts/layout/css/custom.min.css",

  "~/Content/assets/global/plugins/bootstrap-sweetalert/sweetalert.css"

   ));

            bundles.Add(new StyleBundle("~/Content/css/bootstrap").Include("~/Content/bootstrap.min.css", new CssRewriteUrlTransform()));


            bundles.Add(new StyleBundle("~/Content/DataTable/css").Include(

       "~/Content/assets/global/plugins/datatables/datatables.min.css",
       "~/Content/assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.css",
       "~/Content/assets/global/plugins/bootstrap-datepicker/css/bootstrap-datepicker3.min.css"

                   ));




            bundles.Add(new ScriptBundle("~/bundles/DataTable/jquery").Include(

                "~/Content/assets/global/scripts/datatable.js",
                "~/Content/assets/global/plugins/datatables/datatables.min.js",
                "~/Content/assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.js",

                "~/Content/assets/pages/scripts/table-datatables-buttons.js",
                  "~/Content/assets/global/plugins/bootstrap-datepicker/js/bootstrap-datepicker.min.js"

  ));
        }
        //       public static void RegisterBundles(BundleCollection bundles)
        //       {
        //           bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
        // //"~/Content/assets/global/plugins/jQuery v3.4.1.js",
        // "~/Content/assets/global/plugins/jquery.min.js",
        // "~/Content/assets/global/plugins/bootstrap/js/bootstrap.min.js",
        // "~/Content/assets/global/plugins/js.cookie.min.js",
        // "~/Content/assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js",
        // "~/Content/assets/global/plugins/jquery.blockui.min.js",
        // "~/Content/assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js",
        // "~/Content/assets/global/scripts/app.min.js",
        // "~/Content/assets/layouts/layout3/scripts/layout.min.js",
        // "~/Content/assets/layouts/layout3/scripts/demo.min.js",
        // "~/Content/assets/layouts/global/scripts/quick-sidebar.min.js",
        // "~/Content/assets/layouts/global/scripts/quick-nav.min.js",
        // "~/Content/assets/global/plugins/bootstrap-sweetalert/sweetalert.min.js",
        //"~/Content/assets/pages/scripts/ui-sweetalert.min.js"));




        //           bundles.Add(new StyleBundle("~/Content/css").Include(


        // "~/Content/assets/global/plugins/font-awesome/css/font-awesome.min.css",
        // "~/Content/assets/global/plugins/simple-line-icons/simple-line-icons.min.css",
        // "~/Content/assets/global/plugins/bootstrap/css/bootstrap.min.css",
        // "~/Content/assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css",

        // "~/Content/assets/global/css/components.min.css",
        // "~/Content/assets/global/css/plugins.min.css",

        //   "~/Content/assets/layouts/layout3/css/layout.min.css",
        //      "~/Content/assets/layouts/layout3/css/themes/default.min.css",
        //       "~/Content/assets/layouts/layout3/css/custom.min.css",
        // "~/Content/assets/global/plugins/bootstrap-sweetalert/sweetalert.css"

        //  ));

        //           bundles.Add(new StyleBundle("~/Content/css/bootstrap").Include("~/Content/bootstrap.min.css", new CssRewriteUrlTransform()));


        //           bundles.Add(new StyleBundle("~/Content/DataTable/css").Include(

        //      "~/Content/assets/global/plugins/datatables/datatables.min.css",
        //      "~/Content/assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.css",
        //      "~/Content/assets/global/plugins/bootstrap-datepicker/css/bootstrap-datepicker3.min.css"

        //                  ));




        //           bundles.Add(new ScriptBundle("~/bundles/DataTable/jquery").Include(

        //               "~/Content/assets/global/scripts/datatable.js",
        //               "~/Content/assets/global/plugins/datatables/datatables.min.js",
        //               "~/Content/assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.js",

        //               "~/Content/assets/pages/scripts/table-datatables-buttons.js",
        //                 "~/Content/assets/global/plugins/bootstrap-datepicker/js/bootstrap-datepicker.min.js"

        // ));
        //       }
    }
}