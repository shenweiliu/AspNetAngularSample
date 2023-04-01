using System;
using System.Collections.Generic;

namespace AspNet.Angular.Contracts
{
    public interface IModule
    {
        string Name { get; }
           
        void StartUp(IFramework framework);

        string UrlOverride(Uri url);
    }
}
