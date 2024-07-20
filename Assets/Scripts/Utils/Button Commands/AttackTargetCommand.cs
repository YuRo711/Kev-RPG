using Combat;

namespace Utils
{
    public class AttackTargetCommand : ICommand
    {
        private readonly SelectorsManager _selector;
        private readonly EncounterManager _manager;
        
        public AttackTargetCommand(SelectorsManager selector, EncounterManager manager)
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