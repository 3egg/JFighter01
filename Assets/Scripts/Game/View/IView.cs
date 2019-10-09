using Entitas;
using UnityEngine;
namespace Game.View
{
    public interface IView 
    {
        void init(Contexts contexts,IEntity entity);
    }
}