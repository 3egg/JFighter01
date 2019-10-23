using Entitas;
using Entitas.CodeGeneration.Attributes;
using Game.Enums;
using UnityEngine;

namespace Game.Component
{
    [Player]
    public sealed class PlayerComponent : IComponent
    {
        public InputBtn inputBtn;
        public Transform player;
        public bool isPress;
    }

    [Input, Unique]
    public sealed class InputSkillComponent : IComponent
    {
        //是否释放技能
        public bool isValid;
        public int skillCode;
    }

    [Controller, Unique]
    public sealed class AnimatorSkillController : IComponent
    {
        public int skillCode = 0;
    }
}