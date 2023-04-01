using System;

namespace AspNet.Angular.Contracts
{
    public interface ICache
    {
        T AddOrGet<T>(string key, Func<T> valueFactory, DateTimeOffset? expiration = null);
        T Get<T>(string key);
        void Add(string key, object value, DateTimeOffset? expiration = null);
        void AddOrUpdate(string key, object value, DateTimeOffset? expiration = null);
    }
}
