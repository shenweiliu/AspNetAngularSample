using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Routing;
using AspNet.Angular.Web.App_Start;

namespace AspNet.Angular.Web
{
    internal class MefControllerFactory : DefaultControllerFactory
    {

        public override IController CreateController(
            RequestContext requestContext,
            string controllerName)
        {
            IController controller = base.CreateController(requestContext, controllerName);
            Bootstrapper.SatisfyImportsOnce(controller);
            return controller;
        }
    }
}