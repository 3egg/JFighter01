using System.Collections.Generic;
using Game.Enums;

namespace Game.System.Input
{
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
            contexts.game.gameComponentLogService.logService.log("attackO");
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
            contexts.game.gameComponentLogService.logService.log("attackX");
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
        }

        protected override bool filterCondition(InputEntity entity)
        {
            return entity.gameComponentInputButton.inputButton == InputButtn.UP;
        }
    }
}