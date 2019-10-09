using Entitas;
using Game.View;
using UnityEngine;
namespace Game.Service
{
    public abstract class ViewService : MonoBehaviour,IView
    {
        public abstract void init(Contexts contexts,IEntity entity);
    }
}