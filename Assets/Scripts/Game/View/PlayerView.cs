using Entitas;
using Entitas.Unity;
using Game.interfaces;
using Game.Service;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Game.View
{
    public class PlayerView : ViewService,IPlayerBehaviour
    {
        public override void init(Contexts contexts,IEntity entity)
        {
            gameObject.Link(entity);
        }

        public void up()
        {
            throw new NotImplementedException();
        }

        public void down()
        {
            throw new NotImplementedException();
        }

        public void left()
        {
            throw new NotImplementedException();
        }

        public void right()
        {
            throw new NotImplementedException();
        }

        public void attackO()
        {
            throw new NotImplementedException();
        }

        public void attackX()
        {
            throw new NotImplementedException();
        }
    }
}