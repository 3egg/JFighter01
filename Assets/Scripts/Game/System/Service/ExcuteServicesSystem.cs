using Entitas;
using Game.Service;
using NotImplementedException = System.NotImplementedException;

namespace Game.System.Service
{
    /// <summary>
    /// 调用服务部分的帧函数
    /// </summary>
    public class ExcuteServicesSystem : IExecuteSystem
    {
        private Contexts contexts;
        private ServicesManager services;
        public ExcuteServicesSystem(Contexts contexts,ServicesManager services)
        {
            this.contexts = contexts;
            this.services = services;
        }
        
        public void Execute()
        {
            services.unityInputService.update();
        }
    }
}