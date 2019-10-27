using System;
using UnityEngine;

namespace Controller
{
    /// <summary>
    /// 自定义动画事件
    /// </summary>
    public class CustomerSkillAniController : StateMachineBehaviour
    {
        public Action _onStateEnterAction { get; set; }
        public Action _onStateUpdateAction { get; set; }
        public Action _onStateExitAction { get; set; }

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _onStateEnterAction?.Invoke();
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _onStateUpdateAction?.Invoke();
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _onStateExitAction?.Invoke();
        }
    }
}
