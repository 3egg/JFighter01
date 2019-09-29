using UnityEngine;

namespace Const
{
    public enum MainMenuAnimation
    {
        MainMenuGameNameStart,
        MainMenuGameNameBack,
        MainMenuButtonStart,
        MainMenuButtonBack,
        StartGameButtonBgStart,
        StartGameButtonBgBack,
        StartGameTitleStart,
        StartGameTitleBack,
        StartGameButtonsStart,
        StartGameButtonsBack,
    }

    public enum UiConstant
    {
        UiButtons,   
        StartGame,
        MainMenu,
        NewGameWarning,
    }

    public enum LevelDifficult
    {
        None,
        Continue,
        Easy,
        Normal,
        Hard,
    }
    
    public enum LevelGamePartID
    {
        ONE = 1,
        TWO,
        THREE,
        FOUR,
        FIVE
    }

    /// <summary>
    /// 关卡游戏部分小区域ID
    /// </summary>
    public enum LevelPartID
    {
        ONE = 1,
        TWO
    }
}