using Entitas;
using Game.Enums;
using UnityEngine;

namespace Game.System
{
    public class InputSystem : IExecuteSystem
    {
        private readonly Contexts _contexts;
        private bool _isPress = false;

        public InputSystem(Contexts contexts)
        {
            _contexts = contexts;
        }

        public void Execute()
        {
            _isPress = false;
            _contexts.player.ReplacePlayer(InputBtn.NULL, null, _isPress);

            if (Input.GetKey(KeyCode.A))
            {
                Debug.Log("press a");
                pressBtn(InputBtn.LEFT);
            }

            if (Input.GetKey(KeyCode.D))
            {
                pressBtn(InputBtn.RIGHT);
            }

            if (Input.GetKey(KeyCode.W))
            {
                Debug.Log("press w");
                pressBtn(InputBtn.FORWARD);
            }

            if (Input.GetKey(KeyCode.S))
            {
                pressBtn(InputBtn.DOWN);
            }

            if (Input.GetMouseButtonDown(0))
            {
                _contexts.player.ReplacePlayer(InputBtn.ATTACKO, null, false);
            }

            if (Input.GetMouseButtonDown(1))
            {
                _contexts.player.ReplacePlayer(InputBtn.ATTACKX, null, false);
            }
        }

        private void pressBtn(InputBtn btn, bool isPress = true)
        {
            _contexts.player.ReplacePlayer(btn, null, isPress);
        }
    }
}