using Entitas;
using Entitas.CodeGeneration.Attributes;
using Game.Service;

namespace Game.Component
{
    [Game,Unique]
    public class FindObjectServiceComponent : IComponent
    {
        public IFindObjectService findObjectService;
    }
}