using System.Collections.Generic;
using Entitas;
using Game.LogicService;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Game.System
{
    public class PlayerAniStateSystem : ReactiveSystem<ControllerEntity>, IInitializeSystem
    {
        private Contexts _contexts;
        private Animator _playerAnimator;

        public void Initialize()
        {
            _playerAnimator = _contexts.player.GetEntities()[0].player.player.GetComponent<Animator>();
            _contexts.controller.CreateEntity().AddHumanAniStateController(new CustomAniEventSystem(_playerAnimator));
        }

        public PlayerAniStateSystem(Contexts context) : base(context.controller)
        {
            _contexts = context;
        }

        protected override ICollector<ControllerEntity> GetTrigger(IContext<ControllerEntity> context)
        {
            return context.CreateCollector(ControllerMatcher.HumanAniStateController);
        }

        protected override bool Filter(ControllerEntity entity)
        {
            return entity.hasAnimatorSkillController;
        }

        protected override void Execute(List<ControllerEntity> entities)
        {
            var entity = entities.SingleEntity();
            //entity.humanAniStateController.customAniEventSystem.addEventListener();
        }
    }
}