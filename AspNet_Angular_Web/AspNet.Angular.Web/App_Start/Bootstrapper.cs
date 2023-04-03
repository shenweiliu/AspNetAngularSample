using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Compilation;
using System.Reflection;
using System.Web.Mvc;
using AspNet.Angular.Web.Logic;
using AspNet.Angular.Contracts;

namespace AspNet.Angular.Web.App_Start
{
    public class Bootstrapper
    {
        private static AggregateCatalog catalog;
        private static CompositionContainer masterContainer;

        private static readonly Dictionary<string, IModule> moduleList = new Dictionary<string, IModule>(); 

        public static void Compose()
        {
            catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            //catalog.Catalogs.Add(new DirectoryCatalog(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin")));

            foreach (var plugin in Directory.GetDirectories(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Areas")))
            {
                try
                {
                    var directoryCatalog = new DirectoryCatalog(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Areas", plugin));
                    catalog.Catalogs.Add(directoryCatalog);
                    var container = new CompositionContainer(directoryCatalog);
                    //container.ComposeParts();

                    //load plugin
                    var module = container.GetExportedValue<IModule>();
                    if (module != null)
                    {
                        if (!moduleList.ContainsKey(module.Name))
                        {
                            moduleList.Add(module.Name, module);
                        }
                        BuildManager.AddReferencedAssembly(module.GetType().Assembly);
                        module.StartUp(Framework.GetInstance());
                    }

                    //load run-time compiled view models
                    var viewModelModule = container.GetExportedValue<IViewModelRegistration>();
                    if (viewModelModule != null)
                    {
                        BuildManager.AddReferencedAssembly(viewModelModule.GetType().Assembly);
                    }

                    //
                    //var module = container.GetExportedValue<IModule>();
                }
                catch (Exception)  { /* ignore */}

            }
            masterContainer = new CompositionContainer(catalog);
            masterContainer.ComposeParts();
            // Add assembly handler for strongly-typed view models
            AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolve;
        }

        internal static void SatisfyImportsOnce(IController controller)
        {
            masterContainer.SatisfyImportsOnce(controller);
        }

        private static Assembly AssemblyResolve(object sender, ResolveEventArgs resolveArgs)
        {
            var currentAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            // Check we don't already have the assembly loaded
            foreach (var assembly in currentAssemblies)
            {
                if (assembly.FullName == resolveArgs.Name || assembly.GetName().Name == resolveArgs.Name)
                {
                    return assembly;
                }
            }

            return null;
        }

        public static T GetInstance<T>()
        {
            return masterContainer.GetExportedValue<T>();
        }

        public static IModule GetModuleByName(string name)
        {
            //var modules = container.GetExportedValues<IModule>();
            return (moduleList.ContainsKey(name)) ? moduleList[name] : null;
        }

        public static string GetPlugInOverrideUrl(Uri url)
        {
            // negotiation of who has control
            string overrideUrl = null;
            var framework = Framework.GetInstance();
            framework.CacheHelper.AddOrUpdate("OverrideUrl", "");
            foreach (var key in moduleList.Keys)
            {
                var mod = moduleList[key];
                var useUrl = mod.UrlOverride(url);
                if (!string.IsNullOrEmpty(useUrl))
                {
                    overrideUrl = useUrl;
                    framework.CacheHelper.AddOrUpdate("OverrideUrl", useUrl);
                }
            }
            framework.CacheHelper.AddOrUpdate("OverrideUrl", "");
            return overrideUrl;
        }

        public static IEnumerable<IModule> ModuleList()
        {
            return moduleList.Keys.Select(key => moduleList[key]).ToList();
        }
    }
}