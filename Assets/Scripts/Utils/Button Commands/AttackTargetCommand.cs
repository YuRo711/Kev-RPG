using Combat;

namespace Utils
{
    public class AttackTargetCommand : ICommand
    {
        private readonly CharacterSelector _selector;
        private readonly EncounterManager _manager;
        
        public AttackTargetCommand(CharacterSelector selector, EncounterManager manager)
        {
            _manager = manager;
            _selector = selector;
        }
        
        public void Execute()
        {
            var onSelect = new AttackCommand(_manager);
            _selector.ActivateEnemySelection(onSelect);
        }
    }
}