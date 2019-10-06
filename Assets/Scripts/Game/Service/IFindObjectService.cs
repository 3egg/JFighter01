using Game.View;
using UnityEngine;

namespace Game.Service
{
    public interface IFindObjectService
    {
        T[] findAllType<T>() where T : Object;

        IView[] findAllIView();
    }
}