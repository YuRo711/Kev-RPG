using System;
using System.Collections.Generic;
using UnityEngine;

namespace Combat
{
    public class EncounterManager : MonoBehaviour
    
    {
        #region Fields

        private PlayerUnit _chosenPlayer;
        private List<PlayerUnit> _playerUnits;
        private List<Enemy> _enemies;

        #endregion

        #region Public Methods

        public void SetPlayers(List<PlayerUnit> playerUnits)
        {
            _playerUnits = playerUnits;
            SelectUnit(playerUnits[0]);
        }
        public void SetEnemies(List<Enemy> enemies)
        {
            _enemies = enemies;
        }

        #endregion

        #region Private Methods

        private void SelectUnit(BattleUnit unit)
        {
            unit.Select();
        }

        #endregion
    }
}