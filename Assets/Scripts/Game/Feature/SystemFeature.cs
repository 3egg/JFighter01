using Game.System.Input;

namespace Game.Feature
{
    public class SystemFeature : global::Feature
    {
        public SystemFeature(Contexts contexts) : base("System")
        {
            addInputSystem(contexts);
        }

        private void addInputSystem(Contexts contexts)
        {
            Add(new InputNullSystem(contexts));
            Add(new InputForwardButtonSystem(contexts));
            Add(new InputBackButtonSystem(contexts));
            Add(new InputRightButtonSystem(contexts));
            Add(new InputLeftButtonSystem(contexts));
            Add(new InputAttackOButtonSystem(contexts));
            Add(new InputAttackXButtonSystem(contexts));
        }
    }
}