using System;
using System.Linq;
using Entitas;
using Game.Enums;
using Game.LogicService;
using UnityEngine;

namespace Game.System
{
    public class InputSystem : IExecuteSystem
    {
        private readonly Contexts _contexts;
        private bool _isPress;
        private Timer _skillTimer;
        private bool _isAttacking;

        public InputSystem(Contexts contexts)
        {
            _contexts = contexts;
        }

        public void Execute()
        {
            pressBtnToMovePlayer();
            
            if (Input.GetKeyDown(KeyCode.K))
            {
                pressMouseSkill(KeyCode.Mouse0);
                _isAttacking = true;
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                pressMouseSkill(KeyCode.Mouse1);
                _isAttacking = true;
            }
            
            _isAttacking = false;
        }

        private void pressBtnToMovePlayer()
        {
            if (_isAttacking)
            {
                return;
            }

            _isPress = false;
            //InputBtn.NULL, null, false
            if (Input.GetKey(KeyCode.A))
            {
                pressBtn(InputBtn.LEFT);
            }

            if (Input.GetKey(KeyCode.D))
            {
                pressBtn(InputBtn.RIGHT);
            }

            if (Input.GetKey(KeyCode.W))
            {
                pressBtn(InputBtn.FORWARD);
            }

            if (Input.GetKey(KeyCode.S))
            {
                pressBtn(InputBtn.DOWN);
            }

            _contexts.player.CreateEntity().AddPlayer(InputBtn.NULL, null, _isPress);
        }


        private void pressBtn(InputBtn btn)
        {
            _isPress = true;
            _contexts.player.CreateEntity().AddPlayer(btn, null, _isPress);
        }

        private void pressMouseSkill(KeyCode key)
        {
            //当前计时器完成时,把isValid设置为true
            void OnComplete(bool isTimer)
            {
                SetSkillValid(true, isTimer);
            }

            void SetSkillValid(bool isValid, bool isTimer)
            {
                var skillCode = _contexts.input.inputSkill.skillCode;
                if (isTimer && skillCode == 0)
                {
                    return;
                }

                if (skillCode == 0)
                {
                    skillCode = key == KeyCode.Mouse0 ? 1 : 2;
                }

                if (!isValid)
                {
                    skillCode =
                        PlayerInputSystem.single.getCurrentSkillCode(key == KeyCode.Mouse0 ? 1 : 2,
                            _contexts.input.inputSkill.skillCode);
                }

                //按下k inputSkill 1, 计时器  inputSkill 1
                //按下kl inputSkill 12 
                _contexts.input.ReplaceInputSkill(isValid, skillCode);
            }

            _skillTimer = Timer.Register(0.5f, () =>
                OnComplete(true));
            SetSkillValid(false, false);
        }
    }
}