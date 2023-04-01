using System;

namespace AspNet.Angular.Contracts
{
    public interface IFramework
    {
        void RegisterType<TFrom, TTo>() where TTo : TFrom;

        IEventAggregator EventAggregator { get; }             
                
        string GetExecutingConfiguration();       

        ILogger Logger { get; }

        ICache CacheHelper { get; }
    }
}
