using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Combat
{
    public class CombatSelector : GameEventListener
    {
        #region Fields

        public bool isActive;
        [SerializeField] private CombatSelector previousSelector;
        [SerializeField] private CombatSelector nextSelector;
        
        private List<IBattleUnit> units;
        private int _selectIndex;
        private int _maxIndex;
        private ICommand _onSelect;

        #endregion

        #region Public Methods
        
        public void SetUnits(List<IBattleUnit> battleUnits)
        {
            units = battleUnits;
            _maxIndex = battleUnits.Count;
            _selectIndex = 0;
            units[_selectIndex].Select();
        }

        public void SetCommand(ICommand command)
        {
            _onSelect = command;
        }

        public void UndoSelection()
        {
            isActive = false;
            previousSelector?.Activate();
        }
        
        #endregion

        #region Private Methods

        private void Activate()
        {
            isActive = true;
        }
        
        private void ProcessInput()
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
                MoveSelection(1);
            else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
                MoveSelection(-1);
            else if (Input.GetKeyDown(KeyCode.Return))
                ConfirmSelection();
            else if (Input.GetKeyDown(KeyCode.Escape))
                UndoSelection();
        }

        private void MoveSelection(int indexChange)
        {
            units[_selectIndex].Deselect();
            _selectIndex = Math.Abs((_selectIndex + indexChange) % _maxIndex);
            units[_selectIndex].Select();
        }

        private void ConfirmSelection()
        {
            isActive = false;
            nextSelector?.Activate();
            _onSelect?.Execute();
        }
        
        #endregion

        #region MonoBehaviour Callbacks

        private void Update()
        {
            if (!isActive) return;
            
            ProcessInput();
        }

        #endregion
    }
}