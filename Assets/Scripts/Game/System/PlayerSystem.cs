using System;
using System.Collections.Generic;
using DG.Tweening;
using Entitas;
using Game.Enums;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Game.System
{
    public class PlayerSystem : ReactiveSystem<PlayerEntity>, IInitializeSystem
    {
        private readonly Contexts _contexts;
        private Transform _player;

        public void Initialize()
        {
            _player = _contexts.player.player.player;
        }

        public PlayerSystem(Contexts contexts) : base(contexts.player)
        {
            _contexts = contexts;
        }

        protected override ICollector<PlayerEntity> GetTrigger(IContext<PlayerEntity> context)
        {
            return context.CreateCollector(PlayerMatcher.Player);
        }

        protected override bool Filter(PlayerEntity entity)
        {
            return entity.hasPlayer;
        }

        protected override void Execute(List<PlayerEntity> entities)
        {
            var inputBtn = entities.SingleEntity().player.inputBtn;
            movePlayer(inputBtn);
        }

        private void movePlayer(InputBtn inputBtn)
        {
            _player.DOKill();
            switch (inputBtn)
            {
                case InputBtn.FORWARD:
                    break;
                case InputBtn.DOWN:
                    break;
                case InputBtn.RIGHT:
                    break;
                case InputBtn.LEFT:
                    _player.DOMove(Vector3.left, 1);
                    break;
                case InputBtn.ATTACKO:
                    break;
                case InputBtn.ATTACKX:
                    break;
            }
        }
    }
}