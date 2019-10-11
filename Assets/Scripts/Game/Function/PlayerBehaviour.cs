using Game.interfaces;
using Manager;
using model;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Game.Function
{
    /// <summary>
    /// 玩家行为类
    /// </summary>
    public class PlayerBehaviour : IPlayerBehaviour
    {
        private readonly Transform playTransform;
        private readonly PlayerDataModel model;

        public PlayerBehaviour(Transform player, PlayerDataModel model)
        {
            playTransform = player;
            this.model = model;
        }

        public void idle()
        {
            
        }

        public void forward()
        {
            move(model.speed, Vector3.forward);
            playerOrientation(Vector3.zero);
        }

        public void back()
        {
            move(model.speed, Vector3.back);
            playerOrientation(Vector3.up * 180);
        }

        public void left()
        {
            move(model.speed, Vector3.left);
            playerOrientation(Vector3.up * -90);
        }

        public void right()
        {
            move(model.speed, Vector3.right);
            playerOrientation(Vector3.up * 90);
        }

        public void attackO()
        {
            throw new NotImplementedException();
        }

        public void attackX()
        {
            throw new NotImplementedException();
        }

        private void move(float speed, Vector3 direction)
        {
            playTransform.Translate(Time.deltaTime * speed * direction, Space.World);
        }

        private void playerOrientation(Vector3 direction)
        {
            playTransform.eulerAngles = direction;
        }
    }
}