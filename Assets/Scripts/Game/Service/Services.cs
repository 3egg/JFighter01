namespace Game.Service
{
    public class Services
    {
        public IFindObjectService findObjectService { get; private set; }
        public IInputService inputService { get; private set; }

        public Services(IFindObjectService findObjectService,IInputService inputService)
        {
            this.findObjectService = findObjectService;
            this.inputService = inputService;
        }
        
        
    }
}