using System;
using System.Collections;
using System.Collections.Generic;
using Const;
using Controller;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private AnimationController _animationController;
    private UiController _uiController;
    private BtnController _btnController;
    private InputController _inputController;
    private AudioController _audioController;
    private LevelController _levelController;
    private void Awake()
    {
        /*GameObject[] objs = GameObject.FindGameObjectsWithTag("GameController");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);*/
        
        
        _animationController = GetComponent<AnimationController>();
        _uiController = GetComponent<UiController>();
        _btnController = GetComponent<BtnController>();
        _inputController = GetComponent<InputController>();
        _audioController = GetComponent<AudioController>();
        _levelController = LevelController.single;
    }

    private void Start()
    {
        _animationController.mainMenuButtonsShowUp();
        _uiController.currentUiIndex = 0;
        Button[] uiButtons = _btnController.getCurrentUiButtons();
        print(uiButtons);
        _btnController.currentBtnIndex = 0;
        
        _audioController.playUiBg();
        
        _uiController.ifLevelDifficultExist();
        
    }

    private void Update()
    {
        _inputController.pressEsc();
        _inputController.pressABtnToLeft();
        _inputController.pressDBtnToRight();
    }
}