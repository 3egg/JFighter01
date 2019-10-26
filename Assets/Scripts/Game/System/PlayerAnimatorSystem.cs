using System.Collections.Generic;
using System.Linq;
using Const;
using Controller;
using Entitas;
using Game.LogicService;
using Game.View;
using Manager;
using Model;
using UnityEngine;
using Utils;


namespace Game.System
{
    public class PlayerAnimatorSystem : ReactiveSystem<ControllerEntity>, IInitializeSystem
    {
        private Contexts _contexts;
        private Animator _playerAnimator;
        private List<Skills> _skillses;

        public void Initialize()
        {
            _playerAnimator = _contexts.player.GetEntities()[0].player.player.GetComponent<Animator>();
            _contexts.controller.CreateEntity().AddAnimatorSkillController(0);
            _skillses = LoadManager.single.loadJson<SkillModel>(Enums.Constant.HumanSkillJsonPath).Skills;
        }

        public PlayerAnimatorSystem(Contexts context) : base(context.controller)
        {
            _contexts = context;
        }

        protected override ICollector<ControllerEntity> GetTrigger(IContext<ControllerEntity> context)
        {
            return context.CreateCollector(ControllerMatcher.AnimatorSkillController);
        }

        protected override bool Filter(ControllerEntity entity)
        {
            return entity.hasAnimatorSkillController;
        }

        protected override void Execute(List<ControllerEntity> entities)
        {
            var entity = entities.SingleEntity();
            var skillCode = entity.animatorSkillController.skillCode;

            if (returnSkillCode(skillCode)) return;


            _playerAnimator.SetInteger(Constant.SKILL_NAME, skillCode);
            _playerAnimator.SetBool(Constant.IS_IDLE_SWORD, true);

            showSkillCodeOnUI(skillCode);
        }

        /// <summary>
        /// skillcode = 0,或者不在json配置里面就不放这个技能,或者一下按下太多skillcode了,就把skillcode截取一下
        /// </summary>
        /// <param name="skillCode"></param>
        /// <returns></returns>
        private bool returnSkillCode(int skillCode)
        {
            if (skillCode <= 0)
            {
                return true;
            }

            if (skillCode.ToString().ToCharArray().Length > 5)
            {
                skillCode = int.Parse(skillCode.ToString().Substring(0, 4));
            }

            if (_skillses.Where(t =>
                    {
                        var level = LevelController.single.levelIndex == LevelID.ONE ? 1 : 2;
                        return t.Code.Equals(PlayerInputSystem.single.convertIntToString(skillCode)) &&
                               level >= t.Level;
                    }).ToList()
                    .Count < 1)
            {
                return true;
            }

            return false;
        }

        private void showSkillCodeOnUI(int skillCode)
        {
            Object.FindObjectOfType<HumanSkillView>().showItem(skillCode.ToString());
        }
    }
}