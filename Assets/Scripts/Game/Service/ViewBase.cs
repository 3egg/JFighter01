using Game.View;
using UnityEngine;
namespace Game.Service
{
    public abstract class ViewBase : MonoBehaviour,IView
    {
        public abstract void init();
    }
}