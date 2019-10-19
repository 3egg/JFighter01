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
        private Animator _animator;
        private float _speed = 5;
        private Timer _timer;

        public void Initialize()
        {
            _player = _contexts.player.player.player;
            _animator = _player.GetComponent<Animator>();
            _timer = Timer.Register(1, null);
            _timer.Pause();
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
            var entity = entities.SingleEntity();
            var inputBtn = entity.player.inputBtn;
            var isPress = entity.player.isPress;
            Debug.Log(inputBtn);
            movePlayer(inputBtn);
            walkToRun(isPress);
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
            if (inputBtn == InputBtn.NULL)
            {
                playAnimator(PlayerAniIndex.IDLE);
            }

            if (inputBtn == InputBtn.FORWARD)
            {
                movement(Vector3.forward);
                playerOrientation(Vector3.up);
            }

            if (inputBtn == InputBtn.DOWN)
            {
                movement(Vector3.back);
                playerOrientation(Vector3.up * 180);
            }

            if (inputBtn == InputBtn.RIGHT)
            {
                movement(Vector3.right);
                playerOrientation(Vector3.up * 90);
            }

            if (inputBtn == InputBtn.LEFT)
            {
                movement(Vector3.left);
                playerOrientation(Vector3.up * -90);
            }

            if (inputBtn == InputBtn.ATTACKO)
            {
                Debug.Log("mouse 1 press");
            }

            if (inputBtn == InputBtn.ATTACKX)
            {
                Debug.Log("mouse 2 press");
            }

            /*switch (inputBtn)
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
                case InputBtn.ATTACKO:
                    Debug.Log("k");
                    break;
                case InputBtn.ATTACKX:
                    Debug.Log("l");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(inputBtn), inputBtn, null);
            }*/
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