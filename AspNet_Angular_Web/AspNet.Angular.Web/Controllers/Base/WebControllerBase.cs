using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AspNet.Angular.Web.Logic;
using AspNet.Angular.Contracts;

namespace AspNet.Angular.Web.Controllers
{
    public class WebControllerBase : Controller, IModuleController
    {        
        public DivisionContext Division
        {
            get { return DivisionContext.Common; }
        }

        public WebControllerBase()
        {            
        }   
    }
}