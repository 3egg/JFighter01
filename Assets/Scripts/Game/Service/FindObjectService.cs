using UnityEngine;

namespace Game.Service
{
    /// <summary>
    /// 查找场景内的物体服务
    /// </summary>
    public class FindObjectService : IFindObjectService
    {
        public T findAllType<T>() where T : Object
        {
            T[] temp = Object.FindObjectsOfType<T>();
            if (temp == null || temp.Length == 0)
            {
                Debug.LogError("find type error: " + typeof(T).FullName);
                return null;
            }

            return Object.FindObjectOfType<T>();
        }
    }
}