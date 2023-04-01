using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspNet.Angular.Web.Logic;

namespace AspNet.Angular.Web.Controllers
{
    public class ErrorController: WebControllerBase
    {
        public ErrorController()
        {
        }        
        public ActionResult Index()
        {            
            return View( "_PublicError" );                
        }
    }
}