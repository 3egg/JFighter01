using Game.Enums;
using NotImplementedException = System.NotImplementedException;

namespace Game.Service
{
    public interface IInputService
    {
        void init(Contexts contexts);
        void up();
        void down();
        void right();
        void left();

        //攻击 K
        void attackO();
        //攻击 L
        void attackX();
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

        public void up()
        {
            contexts.input.ReplaceGameComponentInputButton(InputButtn.UP);
        }

        public void down()
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
        //帧函数
        //unity的input事件
        //获取EntitasInputService
        public void init(Contexts contexts)
        {
            
        }

        public void up()
        {
            
        }

        public void down()
        {
            
        }

        public void right()
        {
            
        }

        public void left()
        {
            
        }

        public void attackO()
        {
            
        }

        public void attackX()
        {
            
        }
    }
}