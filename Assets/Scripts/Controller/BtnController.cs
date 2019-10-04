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
        public static BtnController instance { get; private set; } = new BtnController();

        private UiController _uiController;
        private AnimationController _animationController;
        private AudioController _audioController;
        private InputController _inputController;
        private LoadSceneController _loadSceneController;
        private LevelController _levelController;
        private int _tempBtnIndex;

        private int _tempLevelIndex;

        [HideInInspector]
        public int currentBtnIndex
        {
            get => _tempBtnIndex;
            set => setCurrentUiBtnIndex(value);
        }

        [HideInInspector] public Button currentBtn;
        [HideInInspector] public Button[] currentUiBtns;

        public void setCurrentUiBtnIndex(int value)
        {
            _tempBtnIndex = value;
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
            instance._uiController = _uiController;
            _animationController = FindObjectOfType<AnimationController>();
            instance._animationController = _animationController;
            _audioController = FindObjectOfType<AudioController>();
            instance._audioController = _audioController;
            _inputController = FindObjectOfType<InputController>();
            instance._inputController = _inputController;
            _loadSceneController = FindObjectOfType<LoadSceneController>();
            instance._loadSceneController = _loadSceneController;
            _levelController = FindObjectOfType<LevelController>();
            instance._levelController = _levelController;
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

        public void clickYes()
        {
            switch (instance._tempLevelIndex)
            {
                case 0:
                    //继续游戏,显示lading场景
                    continueGame();
                    break;
                case 1:
                    //选中了newGameWarning里面的yes
                    startNewGame();
                    instance._levelController.levelDifficult = LevelDifficult.Easy;
                    break;
                case 2:
                    //选中了newGameWarning里面的yes
                    startNewGame();
                    instance._levelController.levelDifficult = LevelDifficult.Normal;
                    break;
                case 3:
                    //选中了newGameWarning里面的yes
                    startNewGame();
                    instance._levelController.levelDifficult = LevelDifficult.Hard;
                    break;
                default:
                    Debug.LogError("can not load scene with level index = -1");
                    break;
            }
            instance._uiController.showOrHideLoadingPicture(true);
            instance._loadSceneController.loadScene("02-Comics");
            instance._loadSceneController.allowSwitchScene();
        }

        public void continueGame()
        {
            //todo continue game
            print("continue game to do...");
        }

        private void startNewGame()
        {
            print("start a new game with level: " + instance._tempLevelIndex);
        }

        public void clickNo()
        {
            instance._tempLevelIndex = -1;
            _inputController.pressEsc();
        }

        private void sendLevenIndex(int index)
        {
            instance._tempLevelIndex = index;
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