using Entitas;
using Entitas.Unity;
using Game.interfaces;
using Game.Service;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Game.View
{
    /// <summary>
    /// 玩家预制体view
    /// </summary>
    public class PlayerView : ViewService
    {
        public override void init(Contexts contexts,IEntity entity)
        {
            gameObject.Link(entity);
        }

       
    }
}