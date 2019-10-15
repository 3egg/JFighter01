using Game.View;
using UnityEngine;

namespace Game.Service
{
    public interface IFindObjectService : IService
    {
        T[] findAllType<T>() where T : Object;

        IView[] findAllIView();
    }
}