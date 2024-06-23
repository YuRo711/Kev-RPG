using System;
using System.Collections.Generic;
using UnityEngine;

namespace Combat
{
    public class EncounterManager : MonoBehaviour
    {
        #region Fields

        private PlayerUnit _selectedPlayer;
        private Enemy _selectedEnemy;

        #endregion

        #region Public Fields

        public void SelectPlayerUnit(PlayerUnit playerUnit)
        {
            _selectedPlayer = playerUnit;
        }

        public void PlayerAttack()
        {
            _selectedPlayer.Attack(_selectedEnemy);
        }

        #endregion
    }
}