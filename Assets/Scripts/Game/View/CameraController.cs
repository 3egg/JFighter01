using System;
using System.Collections.Generic;
using Const;
using Controller;
using Entitas;
using Entitas.Unity;
using Game.Component;
using Game.Enums;
using Game.Service;
using UnityEngine;

namespace Game.View
{
    /// <summary>
    /// 相机控制监听
    /// </summary>
    public class CameraController : ViewBase, IGameComponentCameraStateListener
    {
        private Dictionary<CameraParent, Transform> _parentDic;
        private CameraMove _cameraMove;

        public void OnGameComponentCameraState(GameEntity entity, CameraAnimationName state)
        {
            switch (state)
            {
                case CameraAnimationName.START_GAME_ANI:
                    Transform cameraParent = getCameraParent(CameraParent.IN_GAME);
                    if (cameraParent != null)
                        _cameraMove.move(cameraParent);
                    break;
            }
        }

        private void initCamera()
        {
            var temp = transform.GetComponentInChildren<Camera>();
            if (temp == null)
            {
                Debug.LogError("can not find camera");
            }
            else
            {
                _cameraMove = temp.gameObject.AddComponent<CameraMove>();
            }

            if (_cameraMove == null) return;
            Transform parent = null;
            //是不是本关开始的部分
            if (LevelController.single.levelPartIndex == LevelPartID.ONE)
            {
                parent = getCameraParent(CameraParent.START);
            }
            else
            {
                parent = getCameraParent(CameraParent.IN_GAME);
            }

            if (parent != null) _cameraMove.initCamera(parent);
        }

        private void initParentDic()
        {
            _parentDic = new Dictionary<CameraParent, Transform>();
            Transform temp;
            foreach (CameraParent parent in Enum.GetValues(typeof(CameraParent)))
            {
                temp = transform.Find(parent.ToString());
                if (temp != null)
                {
                    _parentDic[parent] = temp;
                }
                else
                {
                    Debug.LogError("can not find parent: " + parent + "相机父物体");
                }
            }
        }

        //Entitas的数据载体,相当于把整个controller上面的物体交给entitas管理
        public override void init()
        {
            initParentDic();
            initCamera();

            GameEntity entity =
                Contexts.sharedInstance.game.SetGameComponentCameraState(CameraAnimationName.START_GAME_ANI);
            gameObject.Link(entity);
            //相当于外部就知道了
            entity.AddGameComponentCameraStateListener(this);
            // 进入游戏时,相机位置初始化,开场动画,判断数据
        }


        private Transform getCameraParent(CameraParent parent)
        {
            _parentDic.TryGetValue(parent, out var cameraParent);
            return cameraParent;
        }
    }
}