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

        #region Public Methods

        public int TotalPlayers() => _playerUnits.Count;

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

        public bool TryAttackPlayer(Enemy enemy, int position)
        {
            var player = _playerUnits.ElementAtOrDefault(position);
            if (player == null)
                return false;
            if (!player.IsAlive())
                return false;
            
            enemy.Attack(_playerUnits[position]);
            return true;
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