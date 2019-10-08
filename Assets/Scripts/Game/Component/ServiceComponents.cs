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
    public class EntitasInputServiceComponent : IComponent
    {
        public IInputService entitasInputServiceComponent;
    }
    
    /// <summary>
    /// 日志的组件
    /// </summary>
    [Game,Unique]
    public class LogServiceComponent : IComponent
    {
        public ILogService logService;
    }
    
    /// <summary>
    /// 日志的组件
    /// </summary>
    [Game,Unique]
    public class LoadServiceComponent : IComponent
    {
        public ILoadService loadService;
    }
}