using Combat;
using UnityEngine;

namespace Utils
{
    public class DeselectCommand : ICommand
    {
        private readonly SelectorsManager _selectorManager;
        
        public DeselectCommand(SelectorsManager selectorManager)
        {
            _selectorManager = selectorManager;
        }
        
        public void Execute()
        {
            _selectorManager.UndoSelection();
        }
    }
}