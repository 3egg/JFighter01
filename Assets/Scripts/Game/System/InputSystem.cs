using System.Linq;
using Entitas;
using Game.Enums;
using UnityEngine;

namespace Game.System
{
    public class InputSystem : IExecuteSystem
    {
        private readonly Contexts _contexts;
        private bool _isPress;

        public InputSystem(Contexts contexts)
        {
            _contexts = contexts;
        }

        public void Execute()
        {
            _isPress = false;
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
            
            _contexts.player.CreateEntity().AddPlayer(InputBtn.NULL, null, _isPress);

            if (Input.GetMouseButtonDown(0))
            {
                _isPress = true;
                _contexts.player.CreateEntity().AddPlayer(InputBtn.ATTACKO, null, false);
            }

            if (Input.GetMouseButtonDown(1))
            {
                _isPress = true;
                _contexts.player.CreateEntity().AddPlayer(InputBtn.ATTACKX, null, false);
            }
        }


        private void pressBtn(InputBtn btn)
        {
            _isPress = true;
            _contexts.player.CreateEntity().AddPlayer(btn, null, _isPress);
        }
    }
}