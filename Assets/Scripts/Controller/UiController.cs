using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject startGame;

    public static UiController instance { get; private set; } = new UiController();
    
}
