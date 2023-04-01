using System;

namespace AspNet.Angular.Contracts
{
    public interface IEventAggregator
    {
        void Publish<TMessageType>(TMessageType message);
        ISubscription<TMessageType> Subscribe<TMessageType>(Action<TMessageType> action);
        void Unsubscribe<TMessageType>(ISubscription<TMessageType> subscription);
    }
}
