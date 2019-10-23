using Game.System;

namespace Game
{
    public sealed class GameSystems : Feature
    {
        public GameSystems(Contexts contexts)
        {
            Add(new InitSystem(contexts));
            Add(new PlayerSystem(contexts));
            Add(new InputSystem(contexts));
            Add(new PlayerSkillSystem(contexts));
            Add(new PlayerAnimatorSystem(contexts));
        }
    }
}