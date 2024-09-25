using Combat;
using Utils;

namespace Combat
{
    public class AttackCommand : ICommand
    {
        private readonly EncounterManager _manager;
        
        public AttackCommand(EncounterManager manager)
        {
            _manager = manager;
        }
        
        public void Execute()
        {
            _manager.PlayerAttack();
        }
    }
}