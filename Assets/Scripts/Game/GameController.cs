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
        private GameParentManager parentManager;
        private Contexts contexts;

        // Start is called before the first frame update
        void Start()
        {
            initManager();
            var services = new Services(new FindObjectService(), new EntitasInputService(), new UnityInputService(),
                new LogService(), new LoadService(parentManager));
            _systems = new InitFeature(Contexts.sharedInstance, services);
            _systems.Initialize();
            contexts = Contexts.sharedInstance;
            Contexts.sharedInstance.game.SetGameComponentGameState(GameState.START);
        }

        private void initManager()
        {
            parentManager = transform.GetOrAddComponent<GameParentManager>();
            //get cameraController
            parentManager.init();
            //add cameraControl;ler script
            var cameraController = parentManager.getParentTrans(ParentName.CameraController);
            var controller = cameraController.gameObject.AddComponent<CameraController>();
            var entity = contexts.game.CreateEntity();
            entity.AddGameComponentCameraState(CameraAnimationName.START_GAME_ANI);
            controller.init(contexts, entity);
        }

        // Update is called once per frame
        void Update()
        {
            _systems.Execute();
            _systems.Cleanup();
        }

        private void OnDestroy()
        {
            _systems.TearDown();
        }
    }
}