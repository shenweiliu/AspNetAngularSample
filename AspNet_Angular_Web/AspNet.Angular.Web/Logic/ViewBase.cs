using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNet.Angular.Web.Logic
{

    public abstract class ViewBase : System.Web.Mvc.WebViewPage
    {
        public PortalHelpers PortalHelpers { get; set; }

        public ViewBase()
        {
            this.PortalHelpers = new PortalHelpers(this);
        }
    }


    public abstract class ViewBase<T> : System.Web.Mvc.WebViewPage<T>
    {
        public PortalHelpers PortalHelpers { get; set; }

        public ViewBase()
        {
            this.PortalHelpers = new PortalHelpers(this);
        }
    }
}