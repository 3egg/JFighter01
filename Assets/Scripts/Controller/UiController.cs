using System;
using System.Collections.Generic;
using UnityEngine;

namespace Controller
{
    public class UiController : MonoBehaviour
    {
        [SerializeField] private Transform mainMenu;
        [SerializeField] private Transform startGame;
        [SerializeField] private Transform newGameWarning;
        [SerializeField] private Transform loadingPicture;
        [HideInInspector] public int currentUiIndex;
        [HideInInspector] public List<Transform> escUi = new List<Transform>();

        private void Awake()
        {
            escUi.Add(mainMenu);
            escUi.Add(startGame);
            escUi.Add(newGameWarning);
        }

        public Transform currentShowUi()
        {
            return escUi[currentUiIndex];
        }
    }
}