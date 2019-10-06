using Entitas;
using Entitas.CodeGeneration.Attributes;
using Game.Service;

namespace Game.Component
{
    /// <summary>
    /// 查找服务的组件
    /// </summary>
    [Game,Unique]
    public class FindObjectServiceComponent : IComponent
    {
        public IFindObjectService findObjectService;
    }

    /// <summary>
    /// 输入服务的组件
    /// </summary>
    [Game,Unique]
    public class InputServiceComponent : IComponent
    {
        public IInputService inputService;
    }
}