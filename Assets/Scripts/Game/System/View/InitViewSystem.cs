using Entitas;
using Game.Service;
using Game.View;
using UnityEngine;
using UnityEngine.UI;

namespace Game.System.View
{
    /// <summary>
    /// 初始化所有的View
    /// </summary>
    public class InitViewSystem : IInitializeSystem
    {
        private Contexts _contexts;
        public InitViewSystem(Contexts contexts)
        {
            this._contexts = contexts;
        }
        
        public void Initialize()
        {
            /*var views = _contexts.game.gameComponentFindObjectService.findObjectService.findAllIView();
            foreach (var view in views)
            {
                view.init();
            }*/
        }
    }
}