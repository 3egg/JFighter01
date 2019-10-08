namespace Game.Service
{
    public class Services
    {
        public IFindObjectService findObjectService { get; private set; }
        public IInputService entitasInputService { get; private set; }
        public IInputService unityInputService { get; private set; }
        public ILogService logService { get; private set; }
        public ILoadService loadService { get; private set; }

        public Services(IFindObjectService findObjectService, IInputService entitasInputService,
            IInputService unityInputService, ILogService logService, ILoadService loadService)
        {
            this.findObjectService = findObjectService;
            this.entitasInputService = entitasInputService;
            this.unityInputService = unityInputService;
            this.logService = logService;
            this.loadService = loadService;
        }
    }
}