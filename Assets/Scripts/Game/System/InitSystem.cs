using Const;
using DG.Tweening;
using Entitas;
using Game.Enums;
using UnityEngine;
using Constant = Game.Enums.Constant;

namespace Game.System
{
    public class InitSystem : IInitializeSystem
    {
        private Transform _playerParent;
        private Transform _cameraParent;
        private Contexts _contexts;

        public InitSystem(Contexts contexts)
        {
            _contexts = contexts;
        }

        public void Initialize()
        {
            _playerParent = findTransformByName(Constant.PlayerRoot1);
            _cameraParent = findTransformByName(Constant.CameraRoot1);
            //todo load from savedump
            initPlayer();
            initCamera();
        }

        private void initPlayer()
        {
            var prefab = Resources.Load<GameObject>(Constant.PlayerPrefabPath);
            var player = Object.Instantiate(prefab, _playerParent);
            _contexts.player.CreateEntity().AddPlayer(InputBtn.NULL, player.transform);
        }

        private void initCamera()
        {
            var camera = Camera.main.transform;
            camera.SetParent(_cameraParent);
            camera.SetParent(findTransformByName(Constant.CameraRootInGame));
            camera.DOLocalMove(Vector3.zero, 1);
            camera.DOLocalRotate(Vector3.zero, 1);
        }

        private Transform findTransformByName(string objName)
        {
            return GameObject.Find(objName).transform;
        }
    }
}