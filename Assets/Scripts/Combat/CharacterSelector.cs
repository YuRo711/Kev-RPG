using System;
using System.Collections.Generic;
using UnityEngine;

namespace Combat
{
    public class CharacterSelector : MonoBehaviour
    {
        #region Fields

        [SerializeField] private EncounterManager manager;
        
        private PlayerUnit _chosenPlayer;
        private List<PlayerUnit> _playerUnits;
        private List<Enemy> _enemies;
        private int _selectIndex;
        private int _maxIndex;
        private bool _isPlayerSelected;

        #endregion

        
        #region Public Methods

        public void SetPlayers(List<PlayerUnit> playerUnits)
        {
            _playerUnits = playerUnits;
            _maxIndex = _playerUnits.Count;
            _selectIndex = 0;
            _isPlayerSelected = false;
            SelectUnit(_playerUnits[_selectIndex]);
        }
        public void SetEnemies(List<Enemy> enemies)
        {
            _enemies = enemies;
        }

        #endregion

        
        #region Private Methods

        private void ProcessInput()
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
                MoveSelection(1);
            else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
                MoveSelection(-1);
            else if (Input.GetKeyDown(KeyCode.Return))
                ConfirmPlayerChoice();
        }

        private void MoveSelection(int indexChange)
        {
            if (_isPlayerSelected)
                MoveEnemySelection(indexChange);
            else
                MovePlayerSelection(indexChange);
        }

        private void MovePlayerSelection(int indexChange)
        {
            DeselectUnit(_playerUnits[_selectIndex]);
            _selectIndex = Math.Abs((_selectIndex + indexChange) % _maxIndex);
            SelectUnit(_playerUnits[_selectIndex]);
        }

        private void MoveEnemySelection(int indexChange)
        {
            DeselectUnit(_playerUnits[_selectIndex]);
            _selectIndex = (_selectIndex + indexChange) % _maxIndex;
            SelectUnit(_playerUnits[_selectIndex]);
        }

        private void SelectUnit(BattleUnit unit)
        {
            unit.Select();
        }

        private void DeselectUnit(BattleUnit unit)
        {
            unit.Deselect();
        }

        private void ConfirmPlayerChoice()
        {
            manager.SelectPlayerUnit(_playerUnits[_selectIndex]);
            
            _isPlayerSelected = true;
            _selectIndex = 0;
            _maxIndex = _enemies.Count;
        }

        #endregion


        #region MonoBehaviour Callbacks

        private void Update()
        {
            ProcessInput();
        }

        #endregion
    }
}