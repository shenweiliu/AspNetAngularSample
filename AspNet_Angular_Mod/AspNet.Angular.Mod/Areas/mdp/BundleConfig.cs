using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace AspNet.Angular.Mod.Areas
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(System.Web.Optimization.BundleCollection bundles)
        {
             bundles.Add(new ScriptBundle("~/bundles/mdp").Include(
               //Not used
             ));

            
        }
    }
}