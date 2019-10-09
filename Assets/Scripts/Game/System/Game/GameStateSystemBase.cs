using System.Collections.Generic;
using Entitas;
using Game.Enums;
using NotImplementedException = System.NotImplementedException;

namespace Game.System.Game
{
    public abstract class GameStateSystemBase :  ReactiveSystem<GameEntity>
    {
        protected Contexts contexts;
        public GameStateSystemBase(Contexts context) : base(context.game)
        {
            this.contexts = context;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameComponentGameState);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasGameComponentGameState && filterCondition(entity);
        }

        protected abstract bool filterCondition(GameEntity entity);

    }
    
    public class GameStartSystem : GameStateSystemBase
    {
        public GameStartSystem(Contexts context) : base(context)
        {
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var playerBehaviour = contexts.game.gameComponentLoadService.loadService.loadPlayer();
        }

        protected override bool filterCondition(GameEntity entity)
        {
            return entity.gameComponentGameState.gameState == GameState.START;
        }
    }
    
    public class GamePauseSystem : GameStateSystemBase
    {
        public GamePauseSystem(Contexts context) : base(context)
        {
        }

        protected override void Execute(List<GameEntity> entities)
        {
            throw new NotImplementedException();
        }

        protected override bool filterCondition(GameEntity entity)
        {
            return entity.gameComponentGameState.gameState == GameState.PAUSE;
        }
    }
    
    public class GameEndSystem : GameStateSystemBase
    {
        public GameEndSystem(Contexts context) : base(context)
        {
        }

        protected override void Execute(List<GameEntity> entities)
        {
            throw new NotImplementedException();
        }

        protected override bool filterCondition(GameEntity entity)
        {
            return entity.gameComponentGameState.gameState == GameState.END;
        }
    }
}