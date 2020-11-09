using System.Web;
using System.Web.Optimization;

namespace FDMSWeb
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Library/Bootstrap/js/jquery-3.5.1.slim.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Library/Bootstrap/js/bootstrap.js"));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Library/Bootstrap/css/bootstrap.css"));

            bundles.Add(new ScriptBundle("~/Library/fontawesome").Include(
                      "~/Library/fontawesome.js"));
        }
    }
}
