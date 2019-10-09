using Game.Service;

namespace Game.Feature
{
    /// <summary>
    /// 系统初始化了所有feature
    /// </summary>
    public class InitFeature : global::Feature
    {
        public InitFeature(Contexts contexts,Services services) : base("Init")
        {
            Add(new GameEventSystems(contexts));
            Add(new GameFeature(contexts));
            Add(new ServiceFeature(contexts, services));
            Add(new ViewFeature(contexts));
            Add(new SystemFeature(contexts));
        }
    }
}