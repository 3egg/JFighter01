using Controller;
using UnityEditor.Animations;
using UnityEngine;

namespace Game.LogicService
{
    public class CustomAniEventSystem
    {
        public CustomAniEventSystem(Animator animator)
        {
            AnimatorController aniCon = animator.runtimeAnimatorController as AnimatorController;
            AnimatorStateMachine aniStateMachine = aniCon.layers[0].stateMachine;
            foreach (var state in aniStateMachine.states)
            {
                Debug.Log(state.state.name);
            }
        }
    }
}