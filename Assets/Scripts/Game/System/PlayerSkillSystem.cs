using System.Collections.Generic;
using Entitas;
using NotImplementedException = System.NotImplementedException;

namespace Game.System
{
    public class PlayerSkillSystem : ReactiveSystem<InputEntity>
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
            throw new NotImplementedException();
        }
    }
}