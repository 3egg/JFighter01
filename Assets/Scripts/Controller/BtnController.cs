using System;
using System.Linq;
using Const;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Controller
{
    public class BtnController : MonoBehaviour
    {
        [HideInInspector] public int currentBtnIndex;
        private UiController _uiController;
        private AnimationController _animationController;

        private void Awake()
        {
            _uiController = FindObjectOfType<UiController>();
            _animationController = FindObjectOfType<AnimationController>();
        }

        public Button[] getCurrentUiButtons()
        {
            Transform currentShowUi = _uiController.currentShowUi();
            return currentShowUi.GetComponentsInChildren<Button>();
        }

        public void showSelectBtn(int index)
        {
            getCurrentUiButtons()[index].GetComponent<Image>().DOColor(new Color32(154, 170, 255, 255), 1)
                .SetLoops(-1, LoopType.Yoyo);
        }

        public void clickStartGame()
        {
            //把uiController显示StartGame
            _uiController.currentUiIndex = _uiController.escUi.IndexOf(_uiController.escUi
                .Where(ui => ui.name.Equals(UiConstant.StartGame.ToString())).ToArray()[0]);
            //找到当前ui页面的btn,然后显示当前ui的第一个
            showSelectBtn(0);
            //跳转到startGame里面去了
            _animationController.startGameShowUp();
        }
    }
}