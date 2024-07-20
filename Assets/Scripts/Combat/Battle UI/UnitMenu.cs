using System;
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

        public override void UndoSelection()
        {
            base.UndoSelection();
            Destroy(gameObject);
        }

        #endregion
    }
}