using System.Collections.Generic;
using Entitas;
using NotImplementedException = System.NotImplementedException;

namespace Game.System.Game
{
    /// <summary>
    /// 人物动画状态改变
    /// </summary>
    public class PlayerAniStateSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _contexts;
        public PlayerAniStateSystem(Contexts context) : base(context.game)
        {
            _contexts = context;
        }


        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameComponentPlayerAniState);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasGameComponentPlayerAniState;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            //发送一个消息?
        }
    }
}