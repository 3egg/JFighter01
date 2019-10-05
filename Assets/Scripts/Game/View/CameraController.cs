using Entitas;
using Entitas.Unity;
using Game.Component;
using Game.Enums;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Game.View
{
    /// <summary>
    /// 相机控制监听
    /// </summary>
    public class CameraController : MonoBehaviour, IView,IGameComponentCameraStateListener
    {
        public void OnGameComponentCameraState(GameEntity entity, CameraAnimationName state)
        {
        }

        //Entitas的数据载体,相当于把整个controller上面的物体交给entitas管理
        public void Init()
        {
            GameEntity entity = Contexts.sharedInstance.game.CreateEntity();
            gameObject.Link(entity);
            //相当于外部就知道了
            entity.AddGameComponentCameraStateListener(this);
            print("test");
        }
    }
}