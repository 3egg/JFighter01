using Game.Service;
using Game.System.Service;

namespace Game.Feature
{
    public class ServiceFeature : global::Feature
    {
        public ServiceFeature(Contexts contexts, Services services) : base("InitService")
        {
            Add(new InitServices(contexts, services));
        }
    }
}