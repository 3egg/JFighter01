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
        private UiController _uiController;
        private AnimationController _animationController;
        private AudioController _audioController;
        private int tempBtnIndex;

        [HideInInspector]
        public int currentBtnIndex
        {
            get => tempBtnIndex;
            set => setCurrentUiBtnIndex(value);
        }

        [HideInInspector] public Button currentBtn;
        [HideInInspector] public Button[] currentUiBtns;

        public void setCurrentUiBtnIndex(int value)
        {
            tempBtnIndex = value;
            killCurrentUiBtnEffect();

            currentBtn = currentUiBtns[value];
            currentBtn.GetComponent<Image>().DOColor(new Color32(154, 170, 255, 255), 1)
                .SetLoops(-1, LoopType.Yoyo);
        }

        private void killCurrentUiBtnEffect()
        {
            foreach (var button in currentUiBtns)
            {
                button.GetComponent<Image>().DOKill();
                button.GetComponent<Image>().DOColor(Color.white, 0);
            }
        }
        private void Awake()
        {
            _uiController = FindObjectOfType<UiController>();
            _animationController = FindObjectOfType<AnimationController>();
            _audioController = FindObjectOfType<AudioController>();
        }

        public Button[] getCurrentUiButtons()
        {
            Transform currentShowUi = _uiController.currentShowUi();
            currentUiBtns = currentShowUi.GetComponentsInChildren<Button>();
            disableOrEnableBtns(true);
            return currentUiBtns;
        }

        private void disableOrEnableBtns(bool isEnable)
        {
            foreach (var btn in currentUiBtns)
            {
                btn.enabled = isEnable;
            }
        }

        /**ui function**/
        public void clickStartGame()
        {
            _audioController.playUiIn();
            killCurrentUiBtnEffect();
            //把uiController显示StartGame
            _uiController.currentUiIndex = _uiController.escUi.IndexOf(_uiController.escUi
                .Where(ui => ui.name.Equals(UiConstant.StartGame.ToString())).ToArray()[0]);
            //找到当前ui页面的btn,然后显示当前ui的第一个
            showNewUiButton();
            //跳转到startGame里面去了
            _animationController.startGameShowUp();
        }

        public void clickStartLevelGame(int index)
        {
            _audioController.playUiIn();
            killCurrentUiBtnEffect();
            _uiController.currentUiIndex = _uiController.escUi.IndexOf(_uiController.escUi
                .Where(ui => ui.name.Equals(UiConstant.NewGameWarning.ToString())).ToArray()[0]);
            showNewUiButton();
            _animationController.newGameWarningShowUp();
            sendLevenIndex(index);
        }

        private void sendLevenIndex(int index)
        {
            print("level index: " + index);
        }

        public void showNewUiButton()
        {
            disableOrEnableBtns(false);
            getCurrentUiButtons();
            currentBtnIndex = 0;
        }

        /**ui function**/
    }
}