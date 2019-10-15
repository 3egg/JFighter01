using Game.View;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Game.Service
{
    /// <summary>
    /// 查找场景内的物体服务
    /// </summary>
    public class FindObjectService : IFindObjectService
    {
        public T[] findAllType<T>() where T : Object
        {
            T[] temp = Object.FindObjectsOfType<T>();
            if (temp == null || temp.Length == 0)
            {
                Debug.LogError("can not find type: " + typeof(T).FullName);
            }

            return temp;
        }

        public IView[] findAllIView()
        {
           return findAllType<ViewService>();
        }

        public void init(Contexts contexts)
        {
            contexts.game.SetGameComponentFindObjectService(this);
        }

        public void update()
        {
        }

        public int getPriority()
        {
            return 0;
        }
    }
}