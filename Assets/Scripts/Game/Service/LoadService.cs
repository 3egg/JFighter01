using Game.Enums;
using Game.interfaces;
using Game.View;
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
        IPlayerBehaviour loadPlayer();
    }

    public class LoadService : ILoadService
    {
        private GameParentManager gameParentManager;

        public LoadService(GameParentManager gameParentManager)
        {
            this.gameParentManager = gameParentManager;
        }

        public IPlayerBehaviour loadPlayer()
        {
            var player = loadAndInstaniate(Path.PLAYER_PREFAB, gameParentManager.getParentTrans(ParentName.PlayerRoot));
            var view = player.AddComponent<PlayerView>();
            var gameEntity = Contexts.sharedInstance.game.CreateEntity();
            gameEntity.AddGameComponentPlayer(view);
            view.init(Contexts.sharedInstance, gameEntity);
            return view;
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