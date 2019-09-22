using System.Collections;
using System.Collections.Generic;
using Const;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private UIManager uiManager;
    private BtnCotroller btnCotroller;

    private void Awake()
    {
        uiManager = gameObject.GetComponent<UIManager>();
        btnCotroller = gameObject.GetComponent<BtnCotroller>();
    }


    void Start()
    {
        //找到当前显示页面的buttons
        btnCotroller.defaultBtnSelect();
        uiManager.mainMenuButtonsAnimation(MainMenuAnimation.MainMenuButtonStart.ToString());
    }

    private void Update()
    {
        btnCotroller.escBack();
        btnToRightOrLeft();
        btnCotroller.pressEnther();
    }
    

    /**private method**/
    private void btnToRightOrLeft()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            btnCotroller.btnToLeft();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            btnCotroller.btnToRight();
        }
    }
    
    /**private method**/
}