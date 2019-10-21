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

        public InputSystem(Contexts contexts)
        {
            _contexts = contexts;
        }

        public void Execute()
        {
            pressBtnToMovePlayer();


            if (Input.GetMouseButtonDown(0))
            {
                pressMouseSkill(KeyCode.Mouse0);
            }

            if (Input.GetMouseButtonDown(1))
            {
                pressMouseSkill(KeyCode.Mouse1);
            }

        }

        private void pressBtnToMovePlayer()
        {
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
            if (key != KeyCode.Mouse0 || key != KeyCode.Mouse1)
            {
                return;
            }

            //当前计时器完成时,把isValid设置为true
            void OnComplete()
            {
                SetSkillValid(true);
            }

            void SetSkillValid(bool isValid)
            {
                var skillCode =
                    PlayerInputSystem.single.getCurrentSkillCode(key == KeyCode.Mouse0 ? 1 : 2,
                        _contexts.input.inputSkill.skillCode);
                _contexts.input.ReplaceInputSkill(isValid, skillCode);
            }

            _skillTimer = Timer.Register(0.2f, OnComplete);
            //一定时间内按下的按钮次数,就出释放对应的技能
            if (_skillTimer == null || _skillTimer.isDone || _skillTimer.isCompleted)
            {
                _skillTimer = Timer.Register(0.2f, OnComplete);
            }
            
            SetSkillValid(false);
        }
    }
}