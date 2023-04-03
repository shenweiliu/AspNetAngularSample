using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace AspNet.Angular.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/ngSystemJS").Include(
                //Use SystemJS as Angular module loader for local code work.
                //"~/Scripts/system-js/core-js/client/shim.min.js",
                "~/angular-debug/shim.min.js",
                "~/angular-content/node_modules/zone.js/dist/zone.js",
                "~/angular-content/node_modules/reflect-metadata/Reflect.js",
                "~/angular-content/node_modules/systemjs/dist/system.src.js",
                "~/angular-debug/systemjs.config.js"
              ));

            bundles.Add(new ScriptBundle("~/bundles/ngCLI").Include(
                //Use Angular CLI as module loader and file bundles for all server environments.
                //Those js files are available after doing "ng build".
                //Build for prod merges vendor.js and main.js to one main.js file.
                "~/angular-dist/app/runtime.js",
                "~/angular-dist/app/polyfills-es5.js",
                "~/angular-dist/app/polyfills.js",
                "~/angular-dist/app/vendor.js",
                "~/angular-dist/app/main.js"
              ));

            bundles.Add(new StyleBundle("~/ngSystemJs/css").Include(
                "~/angular-content/src/assets/css/ex-dialog.css"

            ));

            bundles.Add(new StyleBundle("~/ngCLI/css").Include(
                "~/angular-dist/app/styles.css"

            ));

            bundles.Add(new StyleBundle("~/Content/css/portal-style").Include(
                "~/Content/css/main.css",
                "~/Content/css/old-styles.css",
                "~/Content/css/dc-only.css",                
                "~/angular-content/src/assets/css/angular-site.css"
            ));
        }
    }
}