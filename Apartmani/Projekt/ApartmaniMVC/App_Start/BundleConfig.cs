using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace ApartmaniMVC.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundle/css").Include("~/Content/bootstrap.min.css"));
            bundles.Add(new ScriptBundle("~/bundle/jq").Include("~/Scripts/jquery-3.6.0.min.js", "~/Scripts/bootstrap.min.js"));
            bundles.Add(new ScriptBundle("~/Validation").Include("~/Scripts/jquery.validate.min.js"));
        }
    }
}