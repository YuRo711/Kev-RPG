using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Combat
{
    public class CombatSelector : MonoBehaviour
    {
        #region Fields
        
        protected List<IBattleSelectable> units;
        protected int _selectIndex;
        protected int _maxIndex;

        public IBattleSelectable currentUnit;

        #endregion

        #region Unity Methods
        
        public void SetUnits(List<IBattleSelectable> battleUnits)
        {
            units = battleUnits;
            Debug.Log(name + units);
            _maxIndex = battleUnits.Count;
            _selectIndex = 0;
        }
        
        public virtual void Activate()
        {
            units[_selectIndex].Select();
            currentUnit = units[_selectIndex];
        }

        public virtual void MoveSelection(int indexChange)
        {
            units[_selectIndex].Deselect();
            _selectIndex = Math.Abs((_selectIndex + indexChange) % _maxIndex);
            units[_selectIndex].Select();
            currentUnit = units[_selectIndex];
        }

        public virtual void UndoSelection()
        {
            units[_selectIndex].Deselect();
        }
        
        public virtual void OnSelect() {}
        
        #endregion
    }
}