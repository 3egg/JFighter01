using Game.Service;
using Game.System.Service;

namespace Game.Feature
{
    public class ServiceFeature : global::Feature
    {
        public ServiceFeature(Contexts contexts, ServicesManager services) : base("InitService")
        {
            Add(new InitServicesSystem(contexts, services));
            Add(new ExcuteServicesSystem(contexts, services));
        }
    }
}