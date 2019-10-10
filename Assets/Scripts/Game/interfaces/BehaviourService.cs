using NotImplementedException = System.NotImplementedException;

namespace Game.interfaces
{
    /// <summary>
    /// 基础行为接口
    /// </summary>
    public interface IBehaviour
    {
        void forward();
        void back();
        void left();
        void right();
    }

    /// <summary>
    /// 玩家行为接口
    /// </summary>
    public interface IPlayerBehaviour : IBehaviour
    {
        //攻击 K
        void attackO();

        //攻击 L
        void attackX();
    }
}