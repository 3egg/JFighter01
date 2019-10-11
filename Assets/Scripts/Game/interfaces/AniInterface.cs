namespace Game.interfaces
{
    /// <summary>
    /// 动画部分接口
    /// </summary>
    public interface IAniInterface
    {
        void play(int aniIndex);

    }

    public interface IPlayerAni : IAniInterface, IPlayerBehaviour
    {
    }
}