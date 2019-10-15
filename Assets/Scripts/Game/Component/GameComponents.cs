using Entitas;
using Entitas.CodeGeneration.Attributes;
using Game.Enums;
using Game.interfaces;
using Game.Service;
using Game.View;

namespace Game.Component
{
    /// <summary>
    /// 相机动画状态,根据状态,播放动画
    /// </summary>
    [Event(EventTarget.Self), Game, Unique]
    public class CameraState : IComponent
    {
        //这里定义cameraState
        public CameraAnimationName state;
    }

    /// <summary>
    /// 游戏状态
    /// </summary>
    [Game, Unique]
    public class GameStateComponent : IComponent
    {
        public GameState gameState;
    }

    [Game, Unique]
    public class PlayerComponent : IComponent
    {
        public IView player;
        public IPlayerBehaviour behaviour;
        //动画接口,查找服务
        public IPlayerAni ani;
    }

    /// <summary>
    /// 玩家动画
    /// </summary>
    public class PlayerAniState : IComponent
    {
        public PlayerAniIndex aniIndex;
    }

   
}