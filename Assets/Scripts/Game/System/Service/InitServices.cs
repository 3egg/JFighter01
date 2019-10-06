using Entitas;
using Game.Service;
using NotImplementedException = System.NotImplementedException;

namespace Game.System.Service
{
    /// <summary>
    /// 初始化服务系统
    /// </summary>
    public class InitServices : IInitializeSystem
    {
        private Contexts contexts;
        private Services services;
        public InitServices(Contexts contexts,Services services)
        {
            this.contexts = contexts;
            this.services = services;
        }
        
        public void Initialize()
        {
            services.inputService.init(contexts); 
            initUniqueComponent(contexts, services);
        }
        
        /// <summary>
        /// 初始化单例组件
        /// </summary>
        /// <param name="contexts"></param>
        /// <param name="services"></param>
        private void initUniqueComponent(Contexts contexts, Services services)
        {
            contexts.game.SetGameComponentFindObjectService(services.findObjectService);
            contexts.game.SetGameComponentInputService(services.inputService);
        }
    }
}