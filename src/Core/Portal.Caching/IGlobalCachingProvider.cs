namespace Portal.Caching
{
    public interface IGlobalCachingProvider
    {
        void AddItem(string key, object value);
        object GetItem(string key);

        bool ItemExist(string key);

        string GetCacheKey(params string[] str);
    } 
}
