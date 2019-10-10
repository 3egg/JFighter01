using Game.Enums;
using Game.interfaces;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Game.Service
{
    public interface IInputService : IPlayerBehaviour
    {
        void init(Contexts contexts);

        void update();
        
    }


    /// <summary>
    /// 与entitas交互的输入服务
    /// </summary>
    public class EntitasInputService : IInputService
    {
        private Contexts contexts;

        public void init(Contexts contexts)
        {
            this.contexts = contexts;
            contexts.input.SetGameComponentInputButton(InputButtn.NULL);
        }

        public void update()
        {
        }

        public void forward()
        {
            contexts.input.ReplaceGameComponentInputButton(InputButtn.UP);
        }

        public void back()
        {
            contexts.input.ReplaceGameComponentInputButton(InputButtn.DOWN);
        }

        public void right()
        {
            contexts.input.ReplaceGameComponentInputButton(InputButtn.RIGHT);
        }

        public void left()
        {
            contexts.input.ReplaceGameComponentInputButton(InputButtn.LEFT);
        }

        public void attackO()
        {
            contexts.input.ReplaceGameComponentInputButton(InputButtn.ATTACK_O);
        }

        public void attackX()
        {
            contexts.input.ReplaceGameComponentInputButton(InputButtn.ATTACK_X);
        }
    }

    /// <summary>
    /// 与unity交互的输入服务
    /// </summary>
    public class UnityInputService : IInputService
    {
        private IInputService entitasInputService;

        //帧函数
        public void update()
        {
            forward();
            back();
            left();
            right();
            attackO();
            attackX();
        }

        //unity的input事件
        //获取EntitasInputService
        public void init(Contexts contexts)
        {
            entitasInputService = contexts.game.gameComponentEntitasInputService.entitasInputServiceComponent;
        }


        public void forward()
        {
            if (Input.GetKey(KeyCode.W))
            {
                entitasInputService.forward();
            }
        }

        public void back()
        {
            if (Input.GetKey(KeyCode.S))
            {
                entitasInputService.back();
            }
        }

        public void right()
        {
            if (Input.GetKey(KeyCode.D))
            {
                entitasInputService.right();
            }
        }

        public void left()
        {
            if (Input.GetKey(KeyCode.A))
            {
                entitasInputService.left();
            }
        }

        public void attackO()
        {
            if (Input.GetKey(KeyCode.K))
            {
                entitasInputService.attackO();
            }
        }

        public void attackX()
        {
            if (Input.GetKey(KeyCode.L))
            {
                entitasInputService.attackX();
            }
        }
    }
}