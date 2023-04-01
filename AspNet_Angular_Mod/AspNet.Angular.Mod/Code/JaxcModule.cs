using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using AspNet.Angular.Contracts;

namespace AspNet.Angular.Mod.Logic.WebModule
{    
    [Export(typeof(IModule))]
    public class PlugInModule : IModule
    {        
        private static IFramework _framework;

        public static string ModuleName { get { return "MDP"; } }

        public string UrlOverride(Uri url)
        {
            return null;
        }

        public string Name
        {
            get
            {
                return ModuleName;
            }
        }
        public void StartUp(IFramework framework)
        {
            _framework = framework;
            // These registrations are used with dependency injection.
            //framework.RegisterType<ICookieProvider, CookieProvider>();            
        }

        public static IFramework GetFramework()
        {
            return _framework;
        }
    }
}