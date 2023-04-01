using System;
using System.Linq;
using System.Web;
using AspNet.Angular.Web.App_Start;
using Microsoft.Practices.Unity;
using System.Configuration;
using AspNet.Angular.Contracts;

namespace AspNet.Angular.Web.Logic
{
    public class Framework : IFramework
    {
        private static Framework instance;

        private ICache cache
        {
            get; set;
        }

        public ICache CacheHelper
        {
            get { return cache; }
        }
        //private ValidatedCacheServiceClient cacheClient { get; set; }

        public IEventAggregator EventAggregator
        {
            get; private set;
        }
        static Framework()
        {
            instance = new Framework();
            //instance.EventAggregator = new EventAggregator();            
        }

        private Framework()
        {
            //cache = new Cache();
            //cacheClient = new ValidatedCacheServiceClient();
        }

        public static IFramework GetInstance()
        {
            return instance;
        }

        public void RegisterType<TFrom, TTo>() where TTo : TFrom
        {
            UnityConfig.GetConfiguredContainer().RegisterType(typeof(TFrom), typeof(TTo));
        }

        public string CurrentCompanyId
        {            
            get
            {
                if (HttpContext.Current != null)
                {
                    var currentCompany = HttpContext.Current.Items["CurrentCompany"];
                    if (currentCompany != null)
                    {
                        return currentCompany.ToString();
                    }
                }
                return null;
            }
            set
            {
                if (HttpContext.Current != null)
                {
                    HttpContext.Current.Items["CurrentCompany"] = value;
                }
            }
        }

        private string SafeString(string s)
        {
            return s ?? String.Empty;
        }

        //public ISecurityContext GetCurrentUser(bool refreshData = false)
        //{            
        //    return null;
        //}

        //public ISecurityContext GetAnonymousUser()
        //{
        //    return null;
        //}

        public string GetExecutingConfiguration()
        {
            return ConfigurationManager.AppSettings["Configuration"];
        }

        private ILogger _logger;
        //public ILogger Logger { get { return _logger ?? (_logger = new LoggerClient()); } }
        public ILogger Logger { get { return _logger ?? (_logger = null); } }

    }
}