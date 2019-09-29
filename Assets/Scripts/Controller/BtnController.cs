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
            _animationController = FindObjectOfType<AnimationController>();
            _audioController = FindObjectOfType<AudioController>();
            _inputController = FindObjectOfType<InputController>();
            _loadSceneController = FindObjectOfType<LoadSceneController>();
            _levelController = FindObjectOfType<LevelController>();
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
            switch (_tempBtnIndex)
            {
                case 0:
                    //继续游戏,显示lading场景
                    continueGame();
                    break;
                case 1:
                    //选中了newGameWarning里面的yes
                    startNewGame();
                    _levelController.levelDifficult = LevelDifficult.Easy;
                    break;
                case 2:
                    //选中了newGameWarning里面的yes
                    startNewGame();
                    _levelController.levelDifficult = LevelDifficult.Normal;
                    break;
                case 3:
                    //选中了newGameWarning里面的yes
                    startNewGame();
                    _levelController.levelDifficult = LevelDifficult.Hard;
                    break;
                default:
                    Debug.LogError("can not load scene with level index = -1");
                    break;
            }

            StartCoroutine(_loadSceneController.loadSceneAsync(""));
            _loadSceneController.allowSwitchScene();
        }

        private void continueGame()
        {
            
        }

        public void startNewGame()
        {
            
        }

        public void clickNo()
        {
            _tempLevelIndex = -1;
            _inputController.pressEsc();
        }

        private void sendLevenIndex(int index)
        {
            _tempLevelIndex = index;
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