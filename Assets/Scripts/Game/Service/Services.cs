using System.Collections.Generic;
using System.Linq;
using Manager;
using Module.Timer;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Game.Service
{
    public interface IServicesManager : IService
    {
    }

    public class ServicesManager : IServicesManager
    {
        private Dictionary<int, HashSet<IService>> servicesMap;
        private HashSet<IService> services;


        public IFindObjectService findObjectService { get; private set; }
        public IInputService entitasInputService { get; private set; }
        public IInputService unityInputService { get; private set; }
        public ILogService logService { get; private set; }
        public ILoadService loadService { get; private set; }
        public ITimerService timerService { get; private set; }

        public ServicesManager(GameParentManager parentManager)
        {
            services = new HashSet<IService>();
            servicesMap = new Dictionary<int, HashSet<IService>>();
            IService[] servicesArray =
            {
                new FindObjectService(),
                new EntitasInputService(),
                new LogService(),
                new LoadService(parentManager),
                new TimerService(new TimerManager()),
                new UnityInputService()
            };
            initServices(servicesArray);
            var result = from temp in servicesMap orderby temp.Key select temp;
            servicesMap = result.ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        /// <summary>
        /// 优先级0开始
        /// </summary>
        /// <param name="priority"></param>
        /// <param name="service"></param>
        private void addIService(int priority, IService service)
        {
            if (priority < 0)
            {
                Debug.LogError("优先级不能为负");
                return;
            }

            if (!servicesMap.ContainsKey(priority))
            {
                servicesMap[priority] = new HashSet<IService>();
            }

            servicesMap[priority].Add(service);
        }

        public void init(Contexts contexts)
        {
            //initServices(this);
            foreach (var service in servicesMap)
            {
                foreach (var ser in service.Value)
                {
                    ser.init(contexts);
                }
            }
        }

        private void initServices(IService[] servicesArray)
        {
            foreach (var service in servicesArray)
            {
                addIService(service.getPriority(), service);
            }
        }

        public void update()
        {
            foreach (var service in this.services)
            {
                service.update();
            }
        }

        public int getPriority()
        {
            return 0;
        }
    }
}