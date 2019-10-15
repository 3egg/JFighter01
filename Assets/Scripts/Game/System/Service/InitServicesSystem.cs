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
        private ServicesManager services;
        public InitServicesSystem(Contexts contexts,ServicesManager services)
        {
            this.contexts = contexts;
            this.services = services;
        }
        
        public void Initialize()
        {
            initUniqueComponent(contexts, services);
            
            initServices(contexts, services);
        }

        private void initServices(Contexts contexts, ServicesManager services)
        {
            services.unityInputService.init(contexts); 
            services.entitasInputService.init(contexts); 
        }
        
        /// <summary>
        /// 初始化单例组件
        /// </summary>
        /// <param name="contexts"></param>
        /// <param name="services"></param>
        private void initUniqueComponent(Contexts contexts, ServicesManager services)
        {
            
            //contexts.game.SetGameComponentEntitasInputService(services.entitasInputService);
            //contexts.game.SetGameComponentLogService(services.logService);
            //contexts.game.SetGameComponentLoadService(services.loadService);
        }
    }
}