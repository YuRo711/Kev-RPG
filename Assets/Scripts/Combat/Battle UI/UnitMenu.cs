using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using Utils;

namespace Combat
{
    public class UnitMenu : CombatSelector
    {
        #region Fields
        
        public EncounterManager manager;
        public SelectorsManager selectorsManager;

        #endregion
        
        #region Unity Methods

        public override void Activate()
        {
            units = GetComponentsInChildren<IBattleSelectable>().ToList();
            _maxIndex = units.Count;
            base.Activate();
        }

        public override void UndoSelection()
        {
            base.UndoSelection();
            Destroy(gameObject);
        }

        public override void OnSelect()
        {
            ((ActionButton)units[_selectIndex]).OnClick();
            Destroy(gameObject);
        }

        #endregion
    }
}