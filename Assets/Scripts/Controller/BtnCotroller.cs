using System;
using System.Collections;
using System.Collections.Generic;
using Const;
using UnityEngine;
using UnityEngine.UI;

public class BtnCotroller : MonoBehaviour
{
    [HideInInspector]
    public Button[] uiButtons { get; set; }

    private UIManager uiManager;
    private UiController uiController;

    private int btnIndex;
    
    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        uiController = FindObjectOfType<UiController>();
    }

    public void clickStartGame()
    {
        Invoke(nameof(defaultBtnSelect),0.85f);
        StartCoroutine(deOrActiveMainMenu(false,0.8f));
        StartCoroutine(deOrActiveStartGame(true,0f));
        clickStartGameOnMainMenu();
        clickStartGameOnStartGame();
    }
    
    public void escBack()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Invoke(nameof(defaultBtnSelect),0.85f);
            StartCoroutine(deOrActiveMainMenu(true,0f));
            StartCoroutine(deOrActiveStartGame(false,0.8f));
            
            escBackGameOnMainMenu();
            escBackGameOnStartGame();
        }
    }
     
    public void defaultBtnSelect()
    {
        var buttons = GameObject.FindGameObjectWithTag(UiConstant.UiButtons.ToString())
            .GetComponentsInChildren<Button>();
        uiButtons = buttons;
        selectBtnColor(0);
    }


    public void btnToRight()
    {
        clearBtnColor();
        btnIndex++;
        if (btnIndex >= uiButtons.Length)
        {
            btnIndex = 0;
        }
        selectBtnColor(btnIndex);
    }
    
    public void btnToLeft()
    {
        clearBtnColor();
        btnIndex--;
        if (btnIndex < 0)
        {
            btnIndex = uiButtons.Length - 1;
        }
        selectBtnColor(btnIndex);
    }

    public void mouseEnterClick(int index)
    {
        btnIndex = index;
        clearBtnColor();
        selectBtnColor(index);
    }

    public void pressEnther()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            uiButtons[btnIndex].onClick.Invoke();
        }
    }
    
    /**private method*/
    private void clickStartGameOnMainMenu()
    {
        //播放mainMenuButton的back
        uiManager.mainMenuButtonsAnimation(MainMenuAnimation.MainMenuButtonBack.ToString());
        //播放mainMenuGameName的Start
        uiManager.mainMenuGameNameAnimation(MainMenuAnimation.MainMenuGameNameStart.ToString());
    }
    private void clickStartGameOnStartGame()
    {
        //滑动StartGame的image和button
        uiManager.startGameButtonsAnimation(MainMenuAnimation.StartGameButtonsStart.ToString());
        uiManager.startGameTitleAnimation(MainMenuAnimation.StartGameTitleStart.ToString());
        uiManager.startGameButtonBgAnimation(MainMenuAnimation.StartGameButtonBgStart.ToString());
    }
    
    private void escBackGameOnMainMenu()
    {
        //动画过程怎么解决?
        uiManager.mainMenuGameNameAnimation(MainMenuAnimation.MainMenuGameNameBack.ToString());
        uiManager.mainMenuButtonsAnimation(MainMenuAnimation.MainMenuButtonStart.ToString());
    }
    private void escBackGameOnStartGame()
    {
        //滑动StartGame的image和button
        uiManager.startGameButtonsAnimation(MainMenuAnimation.StartGameButtonsBack.ToString());
        uiManager.startGameTitleAnimation(MainMenuAnimation.StartGameTitleBack.ToString());
        uiManager.startGameButtonBgAnimation(MainMenuAnimation.StartGameButtonBgBack.ToString());
    }

    private void selectBtnColor(int index)
    {
        uiButtons[index].image.color = Color.cyan;
    }
    private void clearBtnColor()
    {
        foreach (var button in uiButtons)
        {
            button.image.color = Color.white;
        }
    }
    
    
    IEnumerator  deOrActiveMainMenu(bool isActive,float time)
    {
        if (time > 0)
        {
            yield return new WaitForSeconds(time);
        }

        Transform[] transforms = uiController.mainMenu.GetComponentsInChildren<Transform>(true);
        foreach (var trs in transforms)
        {
            if (trs.name.Equals(UiConstant.GameName.ToString()) ||trs.name.Equals(UiConstant.MainMenu.ToString()))
            {
                continue;
            }
            trs.gameObject.SetActive(isActive);
        }
    }
    IEnumerator deOrActiveStartGame(bool isActive,float time)
    {
        if (time > 0)
        {
            yield return new WaitForSeconds(time);
        }
        uiController.startGame.SetActive(isActive);
    }
    
    /**private method*/
}