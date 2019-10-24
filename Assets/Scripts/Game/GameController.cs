using System;
using Entitas;
using Game.LogicService;
using UnityEngine;

/**
 *
 * The GameController creates and manages all systems in Match One
 *
 */

namespace Game
{
    public class GameController
    {
        readonly Systems _systems;

        public GameController(Contexts contexts)
        {
            // This is the heart of Match One:
            // All logic is contained in all the sub systems of GameSystems
            _systems = new GameSystems(contexts);
        }

        public void Initialize()
        {
            // This calls Initialize() on all sub systems
            _systems.Initialize();
        }

        public void Execute()
        {
            // This calls Execute() and Cleanup() on all sub systems
            _systems.Execute();
            _systems.Cleanup();
        }
    }
}
