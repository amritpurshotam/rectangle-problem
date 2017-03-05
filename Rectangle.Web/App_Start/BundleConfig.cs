using System.Web.Optimization;

namespace RectangleProblem
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            /* Clear all items from the default ignore list to allow minified CSS and JavaScript files to be included in debug mode */
            bundles.IgnoreList.Clear();
            /* Add back the default ignore list rules sans the ones which affect minified files and debug mode */
            bundles.IgnoreList.Ignore("*.intellisense.js");
            bundles.IgnoreList.Ignore("*-vsdoc.js");
            bundles.IgnoreList.Ignore("*.debug.js", OptimizationMode.WhenEnabled);

            bundles.Add(new ScriptBundle("~/Scripts/Rectangle").Include(
                "~/Scripts/PageScripts/rectangle.js"));
        }
    }
}