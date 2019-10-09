using Game.System.Game;

namespace Game.Feature
{
    public class GameFeature : global::Feature
    {
        public GameFeature(Contexts contexts)
        {
            init();
            excute();
            reactiveSystem(contexts);
        }

        private void init()
        {
        }

        private void excute()
        {
        }

        private void reactiveSystem(Contexts contexts)
        {
            Add(new GameStartSystem(contexts));
            Add(new GamePauseSystem(contexts));
            Add(new GameEndSystem(contexts));
        }
    }
}