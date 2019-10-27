using System;
using UnityEngine;

namespace Controller
{
    /// <summary>
    /// 自定义动画事件
    /// </summary>
    public class CustomerSkillAniController : StateMachineBehaviour
    {
        public Action<Animator, AnimatorStateInfo> onStateEnterAction { get; set; }
        public Action<Animator, AnimatorStateInfo> onStateUpdateAction { get; set; }
        public Action<Animator, AnimatorStateInfo> onStateExitAction { get; set; }

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            onStateEnterAction?.Invoke(animator,stateInfo);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            onStateUpdateAction?.Invoke(animator,stateInfo);
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            onStateExitAction?.Invoke(animator,stateInfo);
        }
    }
}
