namespace Game.Service
{
    public interface IService
    {
        void init(Contexts contexts);
        void update();
        int getPriority();
    }
}