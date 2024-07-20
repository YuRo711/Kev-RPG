using Combat;

namespace Utils
{
    public class AttackTargetCommand : ICommand
    {
        private readonly CombatSelector _selector;
        private readonly EncounterManager _manager;
        
        public AttackTargetCommand(CombatSelector selector, EncounterManager manager)
        {
            _manager = manager;
            _selector = selector;
        }
        
        public void Execute()
        {
            var onSelect = new AttackCommand(_manager);
            _selector.SetCommand(onSelect);
        }
    }
}