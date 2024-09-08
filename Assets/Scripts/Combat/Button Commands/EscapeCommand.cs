using Utils;

namespace Combat
{
    public class EscapeCommand : ICommand
    {
        private readonly EncounterManager _manager;
        
        public EscapeCommand(EncounterManager manager)
        {
            _manager = manager;
        }
        
        public void Execute()
        {
            _manager.EscapeBattle();
        }
    }
}