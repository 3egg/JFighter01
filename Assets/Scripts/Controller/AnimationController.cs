using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Controller
{
    public class AnimationController : MonoBehaviour
    {
        private readonly Dictionary<string, Vector3> _animationNormalMap = new Dictionary<string, Vector3>();
        //private Dictionary<string,Transform> _animationMovedMap = new Dictionary<string, Transform>();

        [SerializeField] private Transform mainMenuButtons;
        [SerializeField] private Transform mainMenuGameName;
        [SerializeField] private Transform startGameTitle;
        [SerializeField] private Transform startGameButtonBg;
        [SerializeField] private Transform startGameButtons;
        [SerializeField] private Transform newGameWarning;

        private void Awake()
        {
            _animationNormalMap.Add(mainMenuButtons.name, mainMenuButtons.localPosition);
            _animationNormalMap.Add(mainMenuGameName.name, mainMenuGameName.localPosition);
            _animationNormalMap.Add(startGameTitle.name, startGameTitle.localPosition);
            _animationNormalMap.Add(startGameButtonBg.name, startGameButtonBg.localPosition);
            _animationNormalMap.Add(startGameButtons.name, startGameButtons.localPosition);
            _animationNormalMap.Add(newGameWarning.name, newGameWarning.localPosition);
        }


        /**ui function**/
        public void mainMenuButtonsShowUp()
        {
            mainMenuButtons.DOKill();
            mainMenuButtons.DOLocalMove(new Vector2(0, -400), 1, true);
        }

        private void mainMenuButtonsHideIn()
        {
            mainMenuButtons.DOKill();
            mainMenuButtons.DOLocalMove(_animationNormalMap[mainMenuButtons.name], 1, true);
        }

        private void mainMenuGameNameShrink()
        {
            mainMenuGameName.DOKill();
            mainMenuGameName.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 1);
            mainMenuGameName.DOLocalMoveX(520, 1, true);
        }

        private void mainMenuGameNameShowBack()
        {
            mainMenuGameName.DOKill();
            mainMenuGameName.DOScale(new Vector3(2f, 2, 2), 1);
            mainMenuGameName.DOLocalMoveX(_animationNormalMap[mainMenuGameName.name].x, 1, true);
        }

        public void startGameShowUp()
        {
            mainMenuButtonsHideIn();
            mainMenuGameNameShrink();
            startGameTitle.DOKill();
            startGameButtonBg.DOKill();
            startGameButtons.DOKill();
            startGameTitle.DOLocalMoveX(-960, 1, true); //-960,-19,0
            startGameButtonBg.DOScaleY(1, 1); //scaley1
            startGameButtons.DOLocalMoveX(0, 1, true); //0
        }

        public void newGameWarningShowUp()
        {
            startGameTitle.DOKill();
            newGameWarning.DOKill();
            startGameTitle.DOLocalMoveX(-1919, 1, true); //-960,-19,0
            newGameWarning.DOLocalMove(Vector3.zero, 1, true);
        }

        public void escToMainMenu()
        {
            mainMenuButtonsShowUp();
            mainMenuGameNameShowBack();
            startGameTitle.DOKill();
            startGameButtonBg.DOKill();
            startGameButtons.DOKill();
            startGameTitle.DOLocalMoveX(-1919, 1, true); //-960,-19,0
            startGameButtonBg.DOScaleY(0, 1); //scaley1
            startGameButtons.DOLocalMoveX(_animationNormalMap[startGameButtons.name].x, 1, true); //0
        }

        public void escToStartGame()
        {
            startGameTitle.DOKill();
            startGameTitle.DOLocalMoveX(-960, 1, true); //-960,-19,0
            newGameWarning.DOLocalMove(_animationNormalMap[newGameWarning.name], 1, true);
        }


        /**ui function**/
    }
}