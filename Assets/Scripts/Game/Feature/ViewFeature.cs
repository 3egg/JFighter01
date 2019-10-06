using Game.System.View;
using Game.View;

namespace Game.Feature
{
    public class ViewFeature : global::Feature
    {
        public ViewFeature(Contexts contexts) : base("View")
        {
            init(contexts);
        }

        private void init(Contexts contexts)
        {
            Add(new InitViewSystem(contexts));
        }
    }
}