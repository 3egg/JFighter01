using Entitas;
using Game.Service;
using NotImplementedException = System.NotImplementedException;

namespace Game.System.Service
{
    /// <summary>
    /// 初始化服务系统
    /// </summary>
    public class InitServicesSystem : IInitializeSystem
    {
        private Contexts contexts;
        private Services services;
        public InitServicesSystem(Contexts contexts,Services services)
        {
            this.contexts = contexts;
            this.services = services;
        }
        
        public void Initialize()
        {
            initUniqueComponent(contexts, services);
            
            initServices(contexts, services);
        }

        private void initServices(Contexts contexts, Services services)
        {
            services.unityInputService.init(contexts); 
            services.entitasInputService.init(contexts); 
        }
        
        /// <summary>
        /// 初始化单例组件
        /// </summary>
        /// <param name="contexts"></param>
        /// <param name="services"></param>
        private void initUniqueComponent(Contexts contexts, Services services)
        {
            contexts.game.SetGameComponentFindObjectService(services.findObjectService);
            contexts.game.SetGameComponentEntitasInputService(services.entitasInputService);
            contexts.game.SetGameComponentLogService(services.logService);
            contexts.game.SetGameComponentLoadService(services.loadService);
        }
    }
}