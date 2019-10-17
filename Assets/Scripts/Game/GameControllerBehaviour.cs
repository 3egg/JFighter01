using UnityEngine;

/**
 *
 * GameControllerBehaviour is the entry point to Match One
 *
 * The only purpose of this class is to redirect and forward
 * the Unity lifecycle events to the GameController
 *
 */

namespace Game
{
    public class GameControllerBehaviour : MonoBehaviour
    {

        GameController _gameController;

        void Awake() => _gameController = new GameController(Contexts.sharedInstance);
        void Start() => _gameController.Initialize();
        void Update() => _gameController.Execute();
    }
}
