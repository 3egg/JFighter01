using System.Collections.Generic;
using Const;
using Entitas;
using UnityEngine;
using Utils;


namespace Game.System
{
    public class PlayerAnimatorSystem : ReactiveSystem<ControllerEntity>, IInitializeSystem
    {
        private Contexts _contexts;
        private Animator _player;

        public void Initialize()
        {
            _player = _contexts.player.GetEntities()[0].player.player.GetComponent<Animator>();
            _contexts.controller.CreateEntity().AddAnimatorSkillController(0);
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
            if (skillCode <= 0)
            {
                return;
            }

            _player.SetInteger(Constant.SKILL_NAME, skillCode);
        }
    }
}