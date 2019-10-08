using Manager;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Game.Service
{
    /// <summary>
    /// 加载所有资源的服务接口
    /// </summary>
    public interface ILoadService : ILoad
    {
        void load();
    }

    public class LoadService : ILoadService
    {
        public void load()
        {
        }

        public T load<T>(string path, string name) where T : class
        {
            return LoadManager.single.load<T>(path, name);
        }

        public GameObject loadAndInstaniate(string path, Transform parent)
        {
            return LoadManager.single.loadAndInstaniate(path, parent);
        }

        public T[] loadAll<T>(string path) where T : Object
        {
            return LoadManager.single.loadAll<T>(path);
        }
    }
}