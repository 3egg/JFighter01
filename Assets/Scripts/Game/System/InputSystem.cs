using Entitas;
using Game.Enums;
using UnityEngine;

namespace Game.System
{
    public class InputSystem : IExecuteSystem
    {
        private readonly Contexts _contexts;

        public InputSystem(Contexts contexts)
        {
            _contexts = contexts;
        }

        public void Execute()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                _contexts.player.ReplacePlayer(InputBtn.LEFT, null);
            }
        }
    }
}