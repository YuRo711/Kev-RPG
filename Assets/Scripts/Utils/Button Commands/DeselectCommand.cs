using Combat;

namespace Utils
{
    public class DeselectCommand : ICommand
    {
        private readonly CombatSelector _selector;
        
        public DeselectCommand(CombatSelector selector)
        {
            _selector = selector;
        }
        
        public void Execute()
        {
            _selector.UndoSelection();
        }
    }
}