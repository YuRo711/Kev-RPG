using System;
using System.Collections.Generic;
using System.Linq;
using Items;
using Party;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

namespace Combat
{
    public class EncounterManager : MonoBehaviour
    {
        #region Fields

        public PartyData partyData;
        public int rewardMoney;
        public ItemData keyData;

        private PlayerUnit _selectedPlayer;
        private Enemy _selectedEnemy;
        
        private List<PlayerUnit> _playerUnits;
        private List<Enemy> _enemies;
        
        [SerializeField] private GameEvent turnEvent;
        [SerializeField] private GameEvent playerTurnEvent;
        [SerializeField] private GameEvent enemyTurnEvent;
        [SerializeField] private EndBattleUI endBattleUI;
        [SerializeField] private GameEvent endBattleEvent;

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
            Debug.Log(enemy.name + " attacked " + _playerUnits[position].name);
            return true;
        }
        
        public void SetPlayers(List<PlayerUnit> playerUnits)
        {
            _playerUnits = playerUnits;
        }
        
        public void SetEnemies(List<Enemy> enemies)
        {
            _enemies = enemies;
        }

        public void RemoveEnemy(Enemy enemy)
        {
            _enemies.Remove(enemy);
        }
        
        public void EscapeBattle()
        {
            SceneManager.LoadScene("World");
            endBattleEvent.Raise();
        }

        #endregion

        #region Private Methods

        private void ConfirmPlayerTurn()
        {
            _selectedPlayer.hasMadeTurn = true;
            _selectedPlayer.Deselect();
            CheckPlayerAvailable();
        }

        private void CheckPlayerAvailable()
        {
            if (_enemies.All(enemy => !enemy.IsAlive()))
            {
                WinEncounter();
                return;
            }
            
            if (_playerUnits.All(unit => !unit.IsAlive()))
            {
                GameOver();
                return;
            }
            
            if (_playerUnits.All(unit => unit.hasMadeTurn))
            {
                Debug.Log("enemy turn");
                EnemiesTurn();
                return;
            }
            
            Debug.Log("player turn");
            playerTurnEvent.Raise();
        }

        private void NextTurn()
        {
            turnEvent.Raise();
        }

        private void EnemiesTurn()
        {
            enemyTurnEvent.Raise();
            foreach (var enemy in _enemies)
            {
                enemy.MakeTurn();
            }
            NextTurn();
        }

        private void WinEncounter()
        {
            partyData.money += rewardMoney;
            if (keyData != null)
                partyData.AddItem(keyData);
            endBattleUI.WinScreen(rewardMoney, keyData != null);
        }

        private void GameOver()
        {
            endBattleUI.GameOver();
        }

        #endregion
    }
}