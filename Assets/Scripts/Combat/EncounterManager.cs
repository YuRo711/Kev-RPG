using System;
using System.Collections.Generic;
using UnityEngine;

namespace Combat
{
    public class EncounterManager : MonoBehaviour
    {
        #region Fields

        private PlayerUnit _selectedPlayer;

        #endregion

        #region Public Fields

        public void SelectPlayerUnit(PlayerUnit playerUnit)
        {
            _selectedPlayer = playerUnit;
        }

        #endregion
    }
}