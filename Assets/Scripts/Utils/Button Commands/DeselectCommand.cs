using Combat;

namespace Utils
{
    public class DeselectCommand : ICommand
    {
        private readonly CharacterSelector _selector;
        
        public DeselectCommand(CharacterSelector selector)
        {
            _selector = selector;
        }
        
        public void Execute()
        {
            _selector.ExitMenu();
        }
    }
}