using System;
using System.Collections.Generic;
using Const;
using UnityEngine;

namespace Controller
{
    public class UiController : MonoBehaviour
    {
        [SerializeField] private Transform mainMenu;
        [SerializeField] private Transform startGame;
        [SerializeField] private Transform newGameWarning;
        [SerializeField] private Transform loadingPicture;
        [SerializeField] private Transform continueBtn;
        [HideInInspector] public int currentUiIndex;
        [HideInInspector] public List<Transform> escUi = new List<Transform>();
        private LevelController _levelController;


        private void Awake()
        {
            escUi.Add(mainMenu);
            escUi.Add(startGame);
            escUi.Add(newGameWarning);
            _levelController = FindObjectOfType<LevelController>();
        }

        public Transform currentShowUi()
        {
            return escUi[currentUiIndex];
        }

        public void showOrHideLoadingPicture(bool isActive)
        {
            loadingPicture.gameObject.SetActive(isActive);
        }

        public void ifLevelDifficultExist()
        {
            _levelController.ifLevelIndexExist(continueBtn);
        }
    }
}