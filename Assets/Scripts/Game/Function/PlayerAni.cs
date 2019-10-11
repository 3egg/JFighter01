using Const;
using Game.Enums;
using Game.interfaces;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Game.Function
{
    public class PlayerAni : IPlayerAni
    {
        private Animator animator;

        public PlayerAni(Animator animator)
        {
            this.animator = animator;
        }

        public void play(int aniIndex)
        {
            animator.SetInteger(Constant.PLAYER_PARA_NAME, aniIndex);
        }

        public void idle()
        {
            play(PlayerAniIndex.IDLE);
        }

        public void forward()
        {
            move();
        }

        public void back()
        {
            move();
        }

        public void left()
        {
            move();
        }

        public void right()
        {
            move();
        }

        public void attackO()
        {
            throw new NotImplementedException();
        }

        public void attackX()
        {
            throw new NotImplementedException();
        }

        private void play(PlayerAniIndex index)
        {
            play((int) index);
        }

        private void move()
        {
            play(PlayerAniIndex.WALK);
        }
    }
}