using Game.Enums;
using Game.Function;
using Game.interfaces;
using Game.View;
using Manager;
using model;
using UnityEngine;
using Utils;
using NotImplementedException = System.NotImplementedException;

namespace Game.Service
{
    /// <summary>
    /// 加载所有资源的服务接口
    /// </summary>
    public interface ILoadService : ILoad
    {
        void loadPlayer();
    }

    public class LoadService : ILoadService
    {
        private GameParentManager gameParentManager;

        public LoadService(GameParentManager gameParentManager)
        {
            this.gameParentManager = gameParentManager;
        }

        public void loadPlayer()
        {
            var player = loadAndInstaniate(Path.PLAYER_PREFAB, gameParentManager.getParentTrans(ParentName.PlayerRoot));
            IView view = player.AddComponent<PlayerView>();
            IPlayerBehaviour playerBehaviour = new PlayerBehaviour(player.transform,ModelManager.single.playerDataModel);
            Animator animator = player.GetComponent<Animator>();
            IPlayerAni playerAni = null;
            if (animator == null)
            {
                Debug.LogError("player prefabs can not find animator");
            }
            else
            {
                playerAni = new PlayerAni(animator);
            }
            var gameEntity = Contexts.sharedInstance.game.CreateEntity();
            gameEntity.AddGameComponentPlayer(view, playerBehaviour,playerAni);
            gameEntity.AddGameComponentPlayerAniState(PlayerAniIndex.IDLE);
            view.init(Contexts.sharedInstance, gameEntity);
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