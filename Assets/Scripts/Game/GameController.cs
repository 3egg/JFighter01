using System;
using Entitas;
using Game.Feature;
using Game.Service;
using UnityEngine;

namespace Game
{
    public class GameController : MonoBehaviour
    {
        private Systems _systems;

        // Start is called before the first frame update
        void Start()
        {
            var services = new Services(new FindObjectService());
            _systems = new InitFeature(Contexts.sharedInstance, services);
            _systems.Initialize();
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