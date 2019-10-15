using System;
using Entitas;
using Game.Enums;
using Game.Feature;
using Game.Service;
using Game.View;
using Manager;
using UnityEngine;
using Utils;

namespace Game
{
    public class GameController : MonoBehaviour
    {
        private Systems _systems;
        private Contexts contexts;
        private IServicesManager servicesManager;

        // Start is called before the first frame update
        void Start()
        {
            contexts = Contexts.sharedInstance;
            initManager();

            _systems = new InitFeature(Contexts.sharedInstance);
            _systems.Initialize();
            Contexts.sharedInstance.game.SetGameComponentGameState(GameState.START);
            servicesManager.init(contexts);
            var timer = contexts.game.gameComponentTimerService.timerService.createTimer(1,false);
            timer.addCompleteLister(()=>Debug.Log("test"));
        }


        private void initManager()
        {
            var parentManager = transform.GetOrAddComponent<GameParentManager>();
            //get cameraController
            parentManager.init();
            //add cameraControl;ler script
            var cameraController = parentManager.getParentTrans(ParentName.CameraController);
            var controller = cameraController.gameObject.AddComponent<CameraController>();
            var entity = contexts.game.CreateEntity();
            entity.AddGameComponentCameraState(CameraAnimationName.NULL);
            controller.init(contexts, entity);

            ModelManager.single.init();
            servicesManager = new ServicesManager(parentManager);
        }

        // Update is called once per frame
        void Update()
        {
            servicesManager.update();
            _systems.Execute();
            _systems.Cleanup();
        }

        private void OnDestroy()
        {
            _systems.TearDown();
        }
    }
}