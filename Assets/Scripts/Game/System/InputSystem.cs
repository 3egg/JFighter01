using System.Linq;
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
            //InputBtn.NULL, null, false
            if (Input.GetKey(KeyCode.A))
            {
                pressBtn(InputBtn.LEFT);
            }

            if (Input.GetKey(KeyCode.D))
            {
                pressBtn(InputBtn.RIGHT);
            }

            if (Input.GetKey(KeyCode.W))
            {
                pressBtn(InputBtn.FORWARD);
            }

            if (Input.GetKey(KeyCode.S))
            {
                pressBtn(InputBtn.DOWN);
            }

            if (Input.GetMouseButtonDown(0))
            {
                _contexts.player.CreateEntity().AddPlayer(InputBtn.ATTACKO, null, false);
            }

            if (Input.GetMouseButtonDown(1))
            {
                _contexts.player.CreateEntity().AddPlayer(InputBtn.ATTACKX, null, false);
            }
        }

        private void pressKey(KeyCode keyCode,InputBtn btn)
        {
            if (Input.GetKey(keyCode))
            {
                pressBtn(btn);
            }
            else
            {
                pressBtn(InputBtn.NULL, false);
            }
        }

        private void pressBtn(InputBtn btn, bool isPress = true)
        {
            _contexts.player.CreateEntity().AddPlayer(btn, null, isPress);
        }
    }
}