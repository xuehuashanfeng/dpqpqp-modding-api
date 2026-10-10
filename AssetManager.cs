using System;
using System.Collections.Generic;

namespace DpqApi
{
    public class AssetManager
    {
        public static AssetManager Instance { get; private set; }
        protected Dictionary<string,object> assets = new Dictionary<string, object>();
        public AssetManager()
        {
            Instance = this;
        }
        public void Add(string key, object value){
            if (!assets.ContainsKey(key))
            {
                assets.Add(key, value);
            }
        }
        public object Get(string key)
        {
            if (assets.ContainsKey(key))
            {
                return assets[key];
            }
            return null;
        }
    }
}