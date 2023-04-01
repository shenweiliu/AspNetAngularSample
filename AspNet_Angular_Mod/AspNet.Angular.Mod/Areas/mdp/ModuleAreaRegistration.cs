using System.CodeDom;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Xml.XPath;
using AspNet.Angular.Contracts;
using AspNet.Angular.Mod.Logic.WebModule;

namespace AspNet.Angular.Mod.Areas
{
    public class ModuleAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return PlugInModule.ModuleName;
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            //SW: attribute route works on regular Aera, but not on plugin Area site. 
            //context.Routes.MapMvcAttributeRoutes();

            // This is how you must register an API call.
            // NOTE: The name of the mapped route must be unique between all registrations in the site.
            var r = context.Routes.MapHttpRoute("MDP_WebApi",
                "{companyId}/mdp/api/{controller}/{action}/{id}",
                new { id = RouteParameter.Optional });
            r.DataTokens = new RouteValueDictionary();
            r.DataTokens["Namespaces"] = new string[]
            {
                "AspNet.Angular.Mod.Areas.mdp.Controllers.API",
                "AspNet.Angular.Mod.Areas.mdp.Controllers"
            };
            r.DataTokens["ContractResolver"] = WebApiContractResolver.CamelCase;

            var r1 = context.Routes.MapHttpRoute("MDP_WebApi2",
             "mdp/api/{controller}/{action}/{id}",
             new { id = RouteParameter.Optional });
            r1.DataTokens = new RouteValueDictionary();
            r1.DataTokens["Namespaces"] = new string[] 
            {
                "AspNet.Angular.Mod.Areas.mdp.Controllers.API",
                "AspNet.Angular.Mod.Areas.mdp.Controllers"
            };
            r1.DataTokens["ContractResolver"] = WebApiContractResolver.CamelCase;
                        
            context.MapRoute(
                "MDP_company",
                "{companyId}/mdp/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new string[]
                {
                    "AspNet.Angular.Mod.Areas.mdp.Controllers.MVC",
                    "AspNet.Angular.Mod.Areas.mdp.Controllers.Widget",
                    "AspNet.Angular.Mod.Areas.mdp.Controllers"
                }
            );

            // This is how anonymous routes are mapped.
            context.MapRoute(
                "MDP_default",
                "mdp/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new string[]
                {
                    "AspNet.Angular.Mod.Areas.mdp.Controllers.MVC",
                    "AspNet.Angular.Mod.Areas.mdp.Controllers.Widget",
                    "AspNet.Angular.Mod.Areas.mdp.Controllers"
                }
            );            
            this.RegisterBundles();
        }

        private void RegisterBundles()
        {
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}