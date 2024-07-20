using Combat;

namespace Utils
{
    public class DeselectCommand : ICommand
    {
        private readonly SelectorsManager _selector;
        
        public DeselectCommand(SelectorsManager selector)
        {
            _selector = selector;
        }
        
        public void Execute()
        {
            _selector.UndoSelection();
        }
    }
}