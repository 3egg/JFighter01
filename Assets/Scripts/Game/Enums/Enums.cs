namespace Game.Enums
{
    /// <summary>
    /// 相机动画状态名称
    /// </summary>
    public enum CameraAnimationName
    {
        NULL,
        START_GAME_ANI, //开场相机动画
    }

    /// <summary>
    /// 相机父物体的位置
    /// </summary>
    public enum CameraParent
    {
        START,
        IN_GAME
    }

    /// <summary>
    /// 输入按钮
    /// </summary>
    public enum InputButtn
    {
        NULL,
        UP,
        DOWN,
        LEFT,
        RIGHT,
        ATTACK_O,
        ATTACK_X,
    }

    /// <summary>
    /// 游戏状态
    /// </summary>
    public enum GameState
    {
        START,
        PAUSE,
        END
    }

    /// <summary>
    /// 人物动画参数对应枚举
    /// </summary>
    public enum PlayerAniIndex
    {
        IDLE,
        RUN,
        WALK
    }
}