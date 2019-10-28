using Const;
using Game.LogicService;
using UnityEngine;

namespace Controller
{
    public class SkillAniController : StateMachineBehaviour
    {
        private PlayerInputSystem _playerInputSystem;
        //private TrailComboManager _manager;

        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (_playerInputSystem == null)
            {
                _playerInputSystem = PlayerInputSystem.single;
                //_manager = FindObjectOfType<TrailComboManager>();
            }
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            var clipInfos = animator.GetCurrentAnimatorClipInfo(layerIndex);
            if (clipInfos.Length > 0)
            {
                var code = _playerInputSystem.getSkillCode(clipInfos[0].clip.name, "attack", "");
                if (animator.GetInteger(Constant.SKILL_NAME) == code)
                {
                    animator.SetInteger(Constant.SKILL_NAME, 0);
                }
            }
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            
        }

        // OnStateMove is called right after Animator.OnAnimatorMove()
        //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    // Implement code that processes and affects root motion
        //}

        // OnStateIK is called right after Animator.OnAnimatorIK()
        //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    // Implement code that sets up animation IK (inverse kinematics)
        //}
    }
}