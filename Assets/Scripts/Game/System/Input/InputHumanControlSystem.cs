using System.Collections.Generic;
using Game.Enums;

namespace Game.System.Input
{
    /// <summary>
    /// 没有按键按下的状态 
    /// </summary>
    public class InputNullSystem : InputButtonSystemBase
    {
        public InputNullSystem(Contexts context) : base(context)
        {
        }

        protected override void Execute(List<InputEntity> entities)
        {
            if (contexts.game.hasGameComponentPlayer)
            {
                contexts.game.gameComponentPlayer.ani.idle();
            }
        }

        protected override bool filterCondition(InputEntity entity)
        {
            return entity.gameComponentInputButton.inputButton == InputButtn.NULL;
        }
    }
    
    /// <summary>
    /// 向上按键相应系统
    /// </summary>
    public class InputAttackOButtonSystem : InputButtonSystemBase
    {
        public InputAttackOButtonSystem(Contexts context) : base(context)
        {
        }

        protected override void Execute(List<InputEntity> entities)
        {
            contexts.game.gameComponentPlayer.behaviour.attackO();
            contexts.game.gameComponentPlayer.ani.attackO();
        }

        protected override bool filterCondition(InputEntity entity)
        {
            return entity.gameComponentInputButton.inputButton == InputButtn.ATTACK_O;
        }
    }

    /// <summary>
    /// 向上按键相应系统
    /// </summary>
    public class InputAttackXButtonSystem : InputButtonSystemBase
    {
        public InputAttackXButtonSystem(Contexts context) : base(context)
        {
        }

        protected override void Execute(List<InputEntity> entities)
        {
            contexts.game.gameComponentPlayer.behaviour.attackX();
            contexts.game.gameComponentPlayer.ani.attackX();
        }

        protected override bool filterCondition(InputEntity entity)
        {
            return entity.gameComponentInputButton.inputButton == InputButtn.ATTACK_X;
        }
    }

    /// <summary>
    /// 向上按键相应系统
    /// </summary>
    public class InputBackButtonSystem : InputButtonSystemBase
    {
        public InputBackButtonSystem(Contexts context) : base(context)
        {
        }

        protected override void Execute(List<InputEntity> entities)
        {
            contexts.game.gameComponentPlayer.behaviour.back();
            contexts.game.gameComponentPlayer.ani.back();
        }

        protected override bool filterCondition(InputEntity entity)
        {
            return entity.gameComponentInputButton.inputButton == InputButtn.DOWN;
        }
    }

    /// <summary>
    /// 向上按键相应系统
    /// </summary>
    public class InputLeftButtonSystem : InputButtonSystemBase
    {
        public InputLeftButtonSystem(Contexts context) : base(context)
        {
        }

        protected override void Execute(List<InputEntity> entities)
        {
            contexts.game.gameComponentPlayer.behaviour.left();
            contexts.game.gameComponentPlayer.ani.left();
        }

        protected override bool filterCondition(InputEntity entity)
        {
            return entity.gameComponentInputButton.inputButton == InputButtn.LEFT;
        }
    }

    /// <summary>
    /// 向上按键相应系统
    /// </summary>
    public class InputRightButtonSystem : InputButtonSystemBase
    {
        public InputRightButtonSystem(Contexts context) : base(context)
        {
        }

        protected override void Execute(List<InputEntity> entities)
        {
            contexts.game.gameComponentPlayer.behaviour.right();
            contexts.game.gameComponentPlayer.ani.right();
            
        }

        protected override bool filterCondition(InputEntity entity)
        {
            return entity.gameComponentInputButton.inputButton == InputButtn.RIGHT;
        }
    }

    /// <summary>
    /// 向上按键相应系统
    /// </summary>
    public class InputForwardButtonSystem : InputButtonSystemBase
    {
        public InputForwardButtonSystem(Contexts context) : base(context)
        {
        }

        protected override void Execute(List<InputEntity> entities)
        {
            contexts.game.gameComponentPlayer.behaviour.forward();
            contexts.game.gameComponentPlayer.ani.forward();
        }

        protected override bool filterCondition(InputEntity entity)
        {
            return entity.gameComponentInputButton.inputButton == InputButtn.UP;
        }
    }
}