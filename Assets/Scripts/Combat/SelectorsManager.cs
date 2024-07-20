using System;
using UnityEngine;
using Utils;

namespace Combat
{
    public class SelectorsManager : MonoBehaviour
    {
        #region Fields
        
        private CombatSelector currentSelector;
        private ICommand _onSelectTarget;

        public CombatSelector playerSelector;
        public CombatSelector enemySelector;
        public CombatSelector menuSelector;

        #endregion
        
        #region Unity Methods

        public void ActivatePlayerSelection()
        {
            currentSelector = playerSelector;
        }

        public void SetCommand(ICommand command)
        {
            _onSelectTarget = command;
        }
        
        private void ProcessInput()
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
                currentSelector.MoveSelection(1);
            else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
                currentSelector.MoveSelection(-1);
            else if (Input.GetKeyDown(KeyCode.Return))
                ConfirmSelection();
            else if (Input.GetKeyDown(KeyCode.Escape))
                UndoSelection();
        }

        private void UndoSelection()
        {
            if (currentSelector == playerSelector) return;
            
            currentSelector.UndoSelection();
            currentSelector = currentSelector == enemySelector ? menuSelector : playerSelector;
        }

        private void ConfirmSelection()
        {
            if (currentSelector == enemySelector)
                _onSelectTarget?.Execute();
        }

        #endregion

        #region MonoBehaviour Callbacks

        private void Update()
        {
            ProcessInput();
        }

        #endregion
    }
}