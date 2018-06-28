﻿using System.Web;
using System.Web.Optimization;

namespace WebDulsa
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jquery-template").Include(
            //            "~/Scripts/jquery.min.js",
            //            "~/Scripts/bootstrap.bundle.min.js",
            //            "~/Scripts/jquery-jvectormap-1.2.2.min.js",
            //            "~/Scripts/jquery-jvectormap-world-mill-en.js",
            //            "~/Scripts/jquery.knob.js",
            //            "~/Scripts/daterangepicker.js",
            //            "~/Scripts/jquery.slimscroll.min.js",
            //            "~/Scripts/fastclick.js",
            //            "~/Scripts/adminlte.js",
            //            "~/Scripts/dashboard.js",
            //            "~/Scripts/demo.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/adminlte/js").Include(
                      "~/Content/vendor/jquery/jquery.min.js",
                      "~/Content/vendor/bootstrap/js/bootstrap.bundle.min.js",
                      "~/Content/js/adminlte.js",
                      "~/Content/js/demo.js",
                      "~/Content/js/pages/dashboard3.js"));

            bundles.Add(new StyleBundle("~/adminlte/css").Include(
                      "~/Content/vendor/font-awesome/font-awesome.min.css",
                      "~/Content/css/adminlte.min.css"));
        }
    }
}