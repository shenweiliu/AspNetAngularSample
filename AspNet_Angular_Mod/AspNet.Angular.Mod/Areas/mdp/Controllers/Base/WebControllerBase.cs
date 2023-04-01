using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
using AspNet.Angular.Contracts;

namespace AspNet.Angular.Mod.Areas.Mdp.Controllers.Base
{
    /// <summary>
    /// Common functionality between all plug-in Module web controllers.
    /// </summary>
    /// <remarks>
    /// The IModuleController interface is required
    /// for a area plug-in module that containes
    /// views that need prior authentication, such as when
    /// ._PrivateLayout.cshtml is used.
    /// </remarks>
    
    public class WebControllerBase : Controller, IModuleController
    { 
        public DivisionContext Division { get { return DivisionContext.BzTwo; } }

        protected ILogger Logger { get; private set; }

        public IFramework Framework { get; private set; }

        public Dictionary<string, object> ServerParams()
        {
            Dictionary<string, object> serverParams = new Dictionary<string, object>();
            
            //Test.
            serverParams.Add("companyId", "000-12345-67890");
            serverParams.Add("fullCustomerName", "My Test Group"); 
            return serverParams;
        }

        public static IHtmlString SerializeObject(object value)
        {
            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var serializer = new JsonSerializer();
                //{
                //    // Let's use camelCasing as is common practice in JavaScript
                //    ContractResolver = new CamelCasePropertyNamesContractResolver()
                //};

                // We don't want quotes around object names
                jsonWriter.QuoteName = false;
                serializer.Serialize(jsonWriter, value);

                return new HtmlString(stringWriter.ToString());
            }
        }
    }
}