using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using AspNet.Angular.Mod.Areas.Mdp.Controllers.Base;
using Newtonsoft.Json;
using System.Configuration;

namespace AspNet.Angular.Mod.Areas.Mdp.Controllers.MVC
{
    public class MdpHomeController : WebControllerBase
    {        
        public ActionResult Main()
        {
            ViewBag.AngularModuleLoader = ConfigurationManager.AppSettings["AngularModuleLoader"] ?? "cli";

            var serverParams = base.ServerParams();
            ViewBag.ServerParams = JsonConvert.SerializeObject(serverParams);
             
            return PartialView("~/Areas/Mdp/Views/Home/Main.cshtml");
        }        
    }
}
