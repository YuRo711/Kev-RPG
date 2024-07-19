using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;

namespace Combat
{
    public class EncounterManager : MonoBehaviour
    {
        #region Fields

        private PlayerUnit _selectedPlayer;
        private Enemy _selectedEnemy;
        private List<PlayerUnit> _playerUnits;
        
        [SerializeField] private GameEvent turnEvent;
        [SerializeField] private GameEvent playerTurnEvent;

        #endregion

        #region Public Fields

        public void SelectPlayerUnit(PlayerUnit playerUnit)
        {
            _selectedPlayer = playerUnit;
        }

        public void SelectEnemy(Enemy enemy)
        {
            _selectedEnemy = enemy;
        }

        public void PlayerAttack()
        {
            _selectedPlayer.Attack(_selectedEnemy);
            ConfirmPlayerTurn();
        }
        
        public void SetPlayers(List<PlayerUnit> playerUnits)
        {
            _playerUnits = playerUnits;
        }

        #endregion

        #region Private Methods

        private void ConfirmPlayerTurn()
        {
            playerTurnEvent.Raise();
            CheckPlayerAvailable();
        }

        private void CheckPlayerAvailable()
        {
            if (!_playerUnits.All(unit => unit.hasMadeTurn))
            {
                NextTurn();
            }
        }

        private void NextTurn()
        {
            turnEvent.Raise();
        }

        #endregion
    }
}