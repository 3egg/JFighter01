namespace Game.Enums
{
    public enum CameraState
    {
        NULL,
        START,
        FELLOW,
        END,
    }

    /// <summary>
    /// 相机父物体的位置
    /// </summary>
    public enum CameraParent
    {
        START,
        IN_GAME
    }

    public enum InputBtn
    {
        NULL,
        FORWARD,
        DOWN,
        RIGHT,
        LEFT,
        ATTACKX = 1,
        ATTACKO = 2,
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
        WALK,
    }
}