using System.Collections;
using System.Collections.Generic;
using Const;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField] private Animator mainMenuButton;

    [SerializeField] private Animator mainMenuGameName;
    [SerializeField] private Animator startGameTitle;
    [SerializeField] private Animator startGameButtonBg;
    [SerializeField] private Animator startGameButtons;

    public void mainMenuButtonsAnimation(string command)
    {
        mainMenuButton.SetTrigger(command);
    }
    
    public void mainMenuGameNameAnimation(string command)
    {
        mainMenuGameName.SetTrigger(command);
    }
    
    public void startGameButtonsAnimation(string command)
    {
        startGameButtons.SetTrigger(command);
    }
    
    public void startGameButtonBgAnimation(string command)
    {
        startGameButtonBg.SetTrigger(command);
    }
    
    public void startGameTitleAnimation(string command)
    {
        startGameTitle.SetTrigger(command);
    }

}