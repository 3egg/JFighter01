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

    private void Awake()
    {
        _animationController = GetComponent<AnimationController>();
        _uiController = GetComponent<UiController>();
        _btnController = GetComponent<BtnController>();
        _inputController = GetComponent<InputController>();
        _audioController = GetComponent<AudioController>();
    }

    private void Start()
    {
        _animationController.mainMenuButtonsShowUp();
        _uiController.currentUiIndex = 0;
        _btnController.getCurrentUiButtons();
        _btnController.currentBtnIndex = 0;
        
        _audioController.playUiBg();
    }

    private void Update()
    {
        _inputController.pressEsc();
        _inputController.pressABtnToLeft();
        _inputController.pressDBtnToRight();
    }
}