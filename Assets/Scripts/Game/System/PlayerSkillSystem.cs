using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Game.System
{
    public class PlayerSkillSystem : ReactiveSystem<InputEntity>, IInitializeSystem
    {
        private Contexts _contexts;

        public PlayerSkillSystem(Contexts context) : base(context.input)
        {
            _contexts = context;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.InputSkill);
        }

        protected override bool Filter(InputEntity entity)
        {
            return entity.hasInputSkill && entity.inputSkill.isValid;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            var skillCode = entities.SingleEntity().inputSkill.skillCode;
            _contexts.controller.ReplaceAnimatorSkillController(skillCode);
            //发出信号,当前播放技能,动画,声音,特效
            entities.SingleEntity().ReplaceInputSkill(false, 0);
        }

        public void Initialize()
        {
            _contexts.input.SetInputSkill(false, 0);
        }
    }
}