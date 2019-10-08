﻿using UnityEngine;
using Utils;

namespace Manager
{
    public interface ILoad
    {
        T load<T>(string path, string name) where T : class;
        GameObject loadAndInstaniate(string path, Transform parent);
        T[] loadAll<T>(string path) where T : Object;
    }

    public class LoadManager : SingletonUtil<LoadManager>, ILoad
    {
        public T load<T>(string path, string name) where T : class
        {
            return Resources.Load(path + name) as T;
        }

        public GameObject loadAndInstaniate(string path, Transform parent)
        {
            var temp = Resources.Load<GameObject>(path);

            if (temp == null)
            {
                Debug.LogError("path :" + path + " is null");
                return null;
            }
            else
            {
                var go = Object.Instantiate(temp, parent);
                return go;
            }
        }

        public T[] loadAll<T>(string path) where T : Object
        {
            return Resources.LoadAll<T>(path);
        }
    }
}