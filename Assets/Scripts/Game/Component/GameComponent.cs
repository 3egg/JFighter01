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
}