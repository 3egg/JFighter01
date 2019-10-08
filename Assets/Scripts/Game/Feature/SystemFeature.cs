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
            Add(new InputUpButtonSystem(contexts));
            Add(new InputDownButtonSystem(contexts));
            Add(new InputRightButtonSystem(contexts));
            Add(new InputLeftButtonSystem(contexts));
            Add(new InputAttackOButtonSystem(contexts));
            Add(new InputAttackXButtonSystem(contexts));
        }
    }
}