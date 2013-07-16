using System.Web.Optimization;

namespace MobileVoting.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
           // BundleTable.EnableOptimizations = true;

            // --- scripts ---
            bundles
                .Add(new ScriptBundle("~/scripts/modernizr")
                    .Include("~/Scripts/modernizr-*"));

            bundles
                .Add(new ScriptBundle("~/scripts/jquery")
                    .Include("~/Scripts/jquery-*"));

            bundles
                .Add(new ScriptBundle("~/scripts/jquerymobile")
                    .Include("~/Scripts/jquery.mobile-{version}.js"));

            bundles
                .Add(new ScriptBundle("~/scripts/bootstrap")
                    .Include("~/Scripts/bootstrap*"));

            // --- styles ---
            bundles
                .Add(new StyleBundle("~/styles/admin_styles")
                    .Include("~/Content/main.admin.css", "~/Content/bootstrap*"));

            bundles
                .Add(new StyleBundle("~/styles/voter_styles")
                    .Include("~/Content/main.voter.css", "~/Content/jquery.mobile*"));
        }
    }
}