using Game.System.View;
using Game.View;

namespace Game.Feature
{
    public class ViewFeature : global::Feature
    {
        public ViewFeature(Contexts contexts) : base("View")
        {
            Init();
        }

        private void Init()
        {
            Add(new InitViewSystem());
        }
        
    }
}