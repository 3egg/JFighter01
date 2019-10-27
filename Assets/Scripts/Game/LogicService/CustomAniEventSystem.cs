using System;
using System.Collections.Generic;
using System.Linq;
using Controller;
using UnityEditor.Animations;
using UnityEngine;
using Utils;

namespace Game.LogicService
{
    public class CustomAniEventSystem
    {
        private Dictionary<PlayerAniStateName, AnimatorState> _stateDic;
        private Dictionary<PlayerAniStateName, CustomerSkillAniController> _aniSkill;

        public CustomAniEventSystem(Animator animator)
        {
            _stateDic = new Dictionary<PlayerAniStateName, AnimatorState>();
            _aniSkill = new Dictionary<PlayerAniStateName, CustomerSkillAniController>();
            initAnimatorState(animator);
            addCustomerAniEventScript();
        }

        private void initAnimatorState(Animator animator)
        {
            AnimatorController aniCon = animator.runtimeAnimatorController as AnimatorController;
            AnimatorStateMachine aniStateMachine = aniCon.layers[0].stateMachine;

            foreach (var state in aniStateMachine.states)
            {
                foreach (PlayerAniStateName name in Enum.GetValues(typeof(PlayerAniStateName)))
                {
                    if (state.state.name == name.ToString())
                    {
                        _stateDic[name] = state.state;
                    }
                }

                if (!_stateDic.ContainsValue(state.state))
                {
                    Debug.Log("can not find enum state : " + state.state);
                }
            }
        }

        private void addCustomerAniEventScript()
        {
            foreach (var state in _stateDic)
            {
                var behaviours = state.Value.behaviours.Where(temp => temp is CustomerSkillAniController).ToList();
                if (behaviours.Count < 1)
                {
                    _aniSkill[state.Key] = state.Value.AddStateMachineBehaviour<CustomerSkillAniController>();
                }
                else
                {
                    _aniSkill[state.Key] = behaviours[0] as CustomerSkillAniController;
                }
            }
        }

        public void addEventListener(PlayerAniStateName name, Action onStateEnterAction, Action onStateUpdateAction,
            Action onStateExitAction)
        {
            if (_aniSkill.ContainsKey(name))
            {
                _aniSkill[name]._onStateEnterAction = onStateEnterAction;
                _aniSkill[name]._onStateUpdateAction = onStateUpdateAction;
                _aniSkill[name]._onStateExitAction = onStateExitAction;
            }
        }
    }

    public enum PlayerAniStateName
    {
        idle,
        walk,
        run,
        idleSword,
        walkSword,
        runSword,
    }
}