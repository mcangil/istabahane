using System;
using System.Web;
using System.Web.Caching;

namespace IsteBahane.Manager
{
    public class CacheManager 
    {
        readonly TimeSpan _defaultCacheTime = new TimeSpan(0, 0, 5, 0);

        public bool Remove(string key)
        {
            HttpRuntime.Cache.Remove(key);
            return true;
        }

        public void RemoveAll()
        {
            var enumerator = HttpRuntime.Cache.GetEnumerator();

            while (enumerator.MoveNext())
            {
               Remove(enumerator.Key.ToString());

            }
        }

        public T Get<T>(string key)
        {
            var value = HttpRuntime.Cache[key];
            if (value == null)
                return default(T);
            return (T)value;
        }

        public bool Add<T>(string key, T value)
        {
            return Add(key, value, _defaultCacheTime);
        }


        public bool Add<T>(string key, T value, DateTime expiresAt)
        {
            HttpRuntime.Cache.Insert(key, value, null, expiresAt, new TimeSpan(), CacheItemPriority.High, null);
            return true;
        }

        public bool Add<T>(string key, T value, TimeSpan expiresIn)
        {
            var dateTime = DateTime.Now.AddSeconds(expiresIn.TotalSeconds);
            return Add(key, value, dateTime);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
