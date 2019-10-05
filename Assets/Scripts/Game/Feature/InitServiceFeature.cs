using Game.Service;

namespace Game.Feature
{
    public class InitServiceFeature : global::Feature
    {
        public InitServiceFeature(Contexts contexts, Services services) : base("InitService")
        {
            contexts.game.ReplaceGameComponentFindObjectService(services.findObjectService);
        }
    }
}