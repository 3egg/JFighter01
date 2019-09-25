using System;
using UnityEngine;

namespace Controller
{
    public class InputController : MonoBehaviour
    {
        private UiController _uiController;
        private AnimationController _animationController;

        private void Awake()
        {
            _uiController = FindObjectOfType<UiController>();
            _animationController = FindObjectOfType<AnimationController>();
        }

        public void pressEsc()
        {
            if (_uiController.currentUiIndex != 0 && Input.GetKeyDown(KeyCode.Escape))
            {
                _uiController.currentUiIndex--;
                //播放这个ui的退出动画
                string animationName = _uiController.escUi[_uiController.currentUiIndex].name;
                _animationController.Invoke("esc" + animationName, 0);
            }
        }
    }
}