using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.Mvc;
using AspNet.Angular.Web.Logic;
using System.Configuration;

namespace AspNet.Angular.Web.Controllers
{
    public class HomeController : WebControllerBase
    {           
        public ActionResult Index(int? id)
        {
            ViewBag.AngularModuleLoader = ConfigurationManager.AppSettings["AngularModuleLoader"] ?? "cli";

            if (id != null && id == 1)
            {
                return View();
            }
            else
            {
                return View("Start");
            }
        }
        
    }
}