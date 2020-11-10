using System.Web;
using System.Web.Optimization;

namespace FDMSWeb
{
    /* Bundel Configuration */
    public class BundleConfig
    {
        /// <summary>
        /// Register bundles for the project to use
        /// </summary>
        /// <param name="bundles"></param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Library/Bootstrap/js/jquery-3.5.1.slim.min.js")); // add jquery bundle

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*")); // add jquery validate bundle

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*")); // add mondernizr bundle

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Library/Bootstrap/js/bootstrap.js")); // add bootstrap javascript bundle

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Library/Bootstrap/css/bootstrap.css")); // add bootstrap css bundle
        }
    }
}
