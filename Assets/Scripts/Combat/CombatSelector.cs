using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Combat
{
    public class CombatSelector : GameEventListener
    {
        #region Fields
        
        private List<IBattleSelectable> units;
        private int _selectIndex;
        private int _maxIndex;

        #endregion

        #region Unity Methods
        
        public void SetUnits(List<IBattleSelectable> battleUnits)
        {
            units = battleUnits;
            _maxIndex = battleUnits.Count;
            _selectIndex = 0;
            units[_selectIndex].Select();
        }

        public void MoveSelection(int indexChange)
        {
            units[_selectIndex].Deselect();
            _selectIndex = Math.Abs((_selectIndex + indexChange) % _maxIndex);
            units[_selectIndex].Select();
        }

        public virtual void UndoSelection()
        {
            units[_selectIndex].Deselect();
        }
        
        #endregion
    }
}