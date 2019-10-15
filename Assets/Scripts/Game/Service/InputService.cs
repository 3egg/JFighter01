using Game.Enums;
using Game.interfaces;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Game.Service
{
    public interface IInputService : IPlayerBehaviour, IService
    {
        /*void init(Contexts contexts);

        void update();*/
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
            contexts.game.SetGameComponentEntitasInputService(this);
            contexts.input.SetGameComponentInputButton(InputButtn.NULL);
            //contexts.game.SetGameComponentEntitasInputService(this);
        }

        public void update()
        {
        }

        public int getPriority()
        {
            return 0;
        }

        public void idle()
        {
            contexts.input.ReplaceGameComponentInputButton(InputButtn.NULL);
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
        private Contexts contexts;
        private bool isPress;

        //帧函数
        public void update()
        {
            if (entitasInputService == null)
            {
                return;
            }

            isPress = false;
            forward();
            back();
            left();
            right();
            attackO();
            attackX();
            idle();
        }

        public int getPriority()
        {
            return 1;
        }


        //unity的input事件
        //获取EntitasInputService
        public void init(Contexts contexts)
        {
            //contexts.game.SetGameComponentEntitasInputService(this);
            this.contexts = contexts;
            contexts.game.ReplaceGameComponentEntitasInputService(this);
            entitasInputService = contexts.game.gameComponentEntitasInputService.entitasInputServiceComponent;
        }


        public void idle()
        {
            if (!isPress)
            {
                entitasInputService.idle();
            }
        }

        public void forward()
        {
            if (Input.GetKey(KeyCode.W))
            {
                entitasInputService.forward();
                isPress = true;
            }
        }

        public void back()
        {
            if (Input.GetKey(KeyCode.S))
            {
                entitasInputService.back();
                isPress = true;
            }
        }

        public void right()
        {
            if (Input.GetKey(KeyCode.D))
            {
                entitasInputService.right();
                isPress = true;
            }
        }

        public void left()
        {
            if (Input.GetKey(KeyCode.A))
            {
                entitasInputService.left();
                isPress = true;
            }
        }

        public void attackO()
        {
            if (Input.GetKey(KeyCode.K))
            {
                entitasInputService.attackO();
                isPress = true;
            }
        }

        public void attackX()
        {
            if (Input.GetKey(KeyCode.L))
            {
                entitasInputService.attackX();
                isPress = true;
            }
        }
    }
}