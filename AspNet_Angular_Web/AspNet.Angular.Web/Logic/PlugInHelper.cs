using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AspNet.Angular.Web.Logic
{
    public class PlugInHelper
    {
        public int UrlOverrideCacheTimeoutMins
        {
            get
            {
                var valEntry = ConfigurationManager.AppSettings["RedirectionCacheTimeoutMinutes"];
                int val;
                return (int.TryParse(valEntry, out val)) ? val : 480; // def 8 hrs
            }
        }

    }
}