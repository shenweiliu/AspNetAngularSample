using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Http.Routing;
using Newtonsoft.Json.Serialization;
using AspNet.Angular.Contracts;

namespace AspNet.Angular.Web
{
    public class NamespaceHttpControllerSelector : DefaultHttpControllerSelector
    {
        private const string ControllerKey = "controller";
        private readonly HttpConfiguration _configuration;
        private readonly Lazy<IEnumerable<Type>> _duplicateControllerTypes;

        public NamespaceHttpControllerSelector(HttpConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
            _duplicateControllerTypes = new Lazy<IEnumerable<Type>>(GetDuplicateControllerTypes);
        }

        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            var routeData = request.GetRouteData();
            if (routeData == null || routeData.Route == null || routeData.Route.DataTokens == null || routeData.Route.DataTokens["Namespaces"] == null)
                return base.SelectController(request);

            // Look up controller in route data
            object controllerName;
            routeData.Values.TryGetValue(ControllerKey, out controllerName);
            var controllerNameAsString = controllerName as string;
            if (controllerNameAsString == null)
                return SelectControllerWithResolver(request, routeData);

            //get the currently cached default controllers - this will not contain duplicate controllers found so if
            // this controller is found in the underlying cache we don't need to do anything
            var map = base.GetControllerMapping();
            if (map.ContainsKey(controllerNameAsString))
                return SelectControllerWithResolver(request, routeData);

            //the cache does not contain this controller because it's most likely a duplicate, 
            // so we need to sort this out ourselves and we can only do that if the namespace token
            // is formatted correctly.
            var namespaces = routeData.Route.DataTokens["Namespaces"] as IEnumerable<string>;
            if (namespaces == null)
                return SelectControllerWithResolver(request, routeData);

            //see if this is in our cache
            var found = _duplicateControllerTypes.Value
                .Where(x => string.Equals(x.Name, controllerNameAsString + ControllerSuffix, StringComparison.OrdinalIgnoreCase))
                .FirstOrDefault(x => namespaces.Contains(x.Namespace));

            if (found == null)
                return base.SelectController(request);

            var controllerDescriptor = new HttpControllerDescriptor(_configuration, controllerNameAsString, found);
            return SelectResolver(controllerDescriptor, routeData);
        }

        private HttpControllerDescriptor SelectControllerWithResolver(HttpRequestMessage request, IHttpRouteData routeData) {
            HttpControllerDescriptor baseDescriptor = base.SelectController(request);
            return SelectResolver(baseDescriptor, routeData);
        }

        private HttpControllerDescriptor SelectResolver(HttpControllerDescriptor controllerDescriptor, IHttpRouteData routeData)
        {
            var contractResolver = routeData.Route.DataTokens["ContractResolver"] as WebApiContractResolver?;
            if (contractResolver != null)
            {
                switch (contractResolver.Value)
                {
                    case WebApiContractResolver.CamelCase:
                        controllerDescriptor.Configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                        break;
                    default:
                        controllerDescriptor.Configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new DefaultContractResolver();
                        break;
                }
            }
            return controllerDescriptor;
        }

        private IEnumerable<Type> GetDuplicateControllerTypes()
        {
            var assembliesResolver = _configuration.Services.GetAssembliesResolver();
            var controllersResolver = _configuration.Services.GetHttpControllerTypeResolver();
            var controllerTypes = controllersResolver.GetControllerTypes(assembliesResolver);

            //we have all controller types, so just store the ones with duplicate class names - we don't
            // want to cache too much and the underlying selector caches everything else

            var duplicates = controllerTypes.GroupBy(x => x.Name)
                .Where(x => x.Count() > 1)
                .SelectMany(x => x)
                .ToArray();

            return duplicates;
        }
    }
}
