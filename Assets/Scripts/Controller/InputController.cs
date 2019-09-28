using System;
using UnityEngine;

namespace Controller
{
    public class InputController : MonoBehaviour
    {
        private UiController _uiController;
        private AnimationController _animationController;
        private BtnController _btnController;
        private AudioController _audioController;

        private void Awake()
        {
            _uiController = FindObjectOfType<UiController>();
            _animationController = FindObjectOfType<AnimationController>();
            _btnController = FindObjectOfType<BtnController>();
            _audioController = FindObjectOfType<AudioController>();
        }

        public void pressEsc()
        {
            if (_uiController.currentUiIndex != 0 && Input.GetKeyDown(KeyCode.Escape))
            {
                _uiController.currentUiIndex--;
                //播放这个ui的退出动画
                string animationName = _uiController.escUi[_uiController.currentUiIndex].name;
                _audioController.playUiOut();
                _animationController.Invoke("escTo" + animationName, 0);
                _btnController.showNewUiButton();
            }
        }

        public void pressABtnToLeft()
        {
            if (!Input.GetKeyDown(KeyCode.A)) return;
            var length = _btnController.currentUiBtns.Length;
            _btnController.currentBtnIndex--;
            if (_btnController.currentBtnIndex < 0)
            {
                _btnController.currentBtnIndex = length - 1;
            }
        }

        public void pressDBtnToRight()
        {
            if (!Input.GetKeyDown(KeyCode.D)) return;
            var length = _btnController.currentUiBtns.Length;
            _btnController.currentBtnIndex++;
            if (_btnController.currentBtnIndex > length - 1)
            {
                _btnController.currentBtnIndex = 0;
            }
        }
    }
}