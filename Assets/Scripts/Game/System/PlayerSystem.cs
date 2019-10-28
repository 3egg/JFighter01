using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Entitas;
using Game.Enums;
using Game.LogicService;
using Manager;
using UnityEngine;
using Utils;

namespace Game.System
{
    public class PlayerSystem : ReactiveSystem<PlayerEntity>, IInitializeSystem
    {
        private readonly Contexts _contexts;
        private Transform _player;
        private Animator _animator;
        private float _speed = 5;
        private Timer _timer;

        public void Initialize()
        {
            _player = _contexts.player.GetGroup(PlayerMatcher.Player).GetEntities()[0].player.player;
            _animator = _player.GetComponent<Animator>();
            _timer = Timer.Register(1, null);
            _timer.Pause();
            destroyUselessPlayer();
        }

        private void destroyUselessPlayer()
        {
            Timer.Register(1, () =>
            {
                foreach (var entity in _contexts.player.GetEntities().Where(
                    i => i.player.player == null))
                {
                    entity.Destroy();
                }
            }, null, true);
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
            var inputBtn = entities.First().player.inputBtn;
            var isPress = entities.First().player.isPress;
            var inputSkill = _contexts.input.inputSkill;
            var skillCode = inputSkill.skillCode;
            //攻击可以移动?
            if (skillCode > 0 || _animator.GetInteger(Const.Constant.SKILL_NAME) > 0)
            {
                return;
            }

            movePlayer(inputBtn);
            walkToRun(isPress);
        }

        private bool isAttacking()
        {
            return _animator.GetCurrentAnimatorStateInfo(0).IsName("Skill");
        }

        private void walkToRun(bool isPress)
        {
            if (isPress)
            {
                _timer.Resume();
                if (_timer.isCompleted)
                {
                    playAnimator(PlayerAniIndex.RUN);
                }
            }
            else
            {
                _timer = Timer.Register(1, null);
                _timer.Pause();
                playAnimator(PlayerAniIndex.IDLE);
            }
        }

        private void movePlayer(InputBtn inputBtn)
        {
            _player.DOKill();
            switch (inputBtn)
            {
                case InputBtn.NULL:
                    playAnimator(PlayerAniIndex.IDLE);
                    break;
                case InputBtn.FORWARD:
                    movement(Vector3.forward);
                    playerOrientation(Vector3.zero);
                    break;
                case InputBtn.DOWN:
                    movement(Vector3.back);
                    playerOrientation(Vector3.up * 180);
                    break;
                case InputBtn.RIGHT:
                    movement(Vector3.right);
                    playerOrientation(Vector3.up * 90);
                    break;
                case InputBtn.LEFT:
                    movement(Vector3.left);
                    playerOrientation(Vector3.up * -90);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(inputBtn), inputBtn, null);
            }
        }

        private void playAnimator(PlayerAniIndex index)
        {
            _animator.SetInteger(Constant.PlayerParaName, (int) index);
        }

        private void movement(Vector3 direction)
        {
            playAnimator(PlayerAniIndex.WALK);
            _player.Translate(Time.deltaTime * _speed * direction, Space.World);
        }

        private void playerOrientation(Vector3 direction)
        {
            _player.eulerAngles = direction;
        }
    }
}