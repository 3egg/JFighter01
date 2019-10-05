namespace Game.Service
{
    public class Services
    {
        public IFindObjectService findObjectService { get; private set; }

        public Services(IFindObjectService findObjectService)
        {
            this.findObjectService = findObjectService;
        }
    }
}