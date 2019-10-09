﻿using Entitas;
using Entitas.CodeGeneration.Attributes;
using Game.Enums;
using Game.interfaces;
using Game.Service;

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
        public IPlayerBehaviour behaviour;
    }
}