using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace PayrollManagement.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/jquery").Include(
                "~/Scripts/jquery-{version}.js")
            );

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                "~/Scripts/js/kendo.all.min.js",
                "~/Scripts/js/kendo.aspnetmvc.min.js"));

            bundles.Add(new StyleBundle("~/Content/kendo/css").Include(
                "~/Content/styles/kendo.common-bootstrap.min.css",
                "~/Content/styles/kendo.bootstrap.min.css"));

            bundles.IgnoreList.Clear();
        }
    }
}