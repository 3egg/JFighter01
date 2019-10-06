using Entitas;
using Entitas.CodeGeneration.Attributes;
using Game.Enums;

namespace Game.Component
{
    /// <summary>
    /// 输入按键
    /// </summary>
    [Event(EventTarget.Self),Input,Unique]
    public class InputButtonComponent : IComponent
    {
        public InputButtn inputButton;
    }
}