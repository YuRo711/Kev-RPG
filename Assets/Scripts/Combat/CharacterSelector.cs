using System;
using System.Collections.Generic;
using UnityEngine;

namespace Combat
{
    public class CharacterSelector : MonoBehaviour
    {
        #region Fields

        [SerializeField] private EncounterManager manager;
        [SerializeField] private GameObject unitMenuPrefab;
        
        private PlayerUnit _chosenPlayer;
        private List<PlayerUnit> _playerUnits;
        private List<Enemy> _enemies;
        private UnitMenu _unitMenu;
        private int _selectIndex;
        private int _maxIndex;
        private bool _isPlayerSelected;
        private bool _isActionSelected;

        #endregion

        
        #region Public Methods

        public void SetPlayers(List<PlayerUnit> playerUnits)
        {
            _playerUnits = playerUnits;
            _maxIndex = _playerUnits.Count;
            _selectIndex = 0;
            _isPlayerSelected = false;
            _isActionSelected = false;
            SelectUnit(_playerUnits[_selectIndex]);
        }
        public void SetEnemies(List<Enemy> enemies)
        {
            _enemies = enemies;
        }

        public void UndoSelection()
        {
            if (_isActionSelected)
            {
                DeselectUnit(_enemies[_selectIndex]);
                _isActionSelected = false;
                ShowUnitMenu();
            }
            else if (_isPlayerSelected)
            {
                _unitMenu.Hide();
                _isPlayerSelected = false;
            }
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
                ConfirmChoice();
            else if (Input.GetKeyDown(KeyCode.Escape))
                UndoSelection();
        }

        private void MoveSelection(int indexChange)
        {
            if (_isPlayerSelected && _isActionSelected)
                MoveEnemySelection(indexChange);
            else if (_isPlayerSelected)
                MoveActionSelection(indexChange);
            else
                MovePlayerSelection(indexChange);
        }

        private void MovePlayerSelection(int indexChange)
        {
            DeselectUnit(_playerUnits[_selectIndex]);
            _selectIndex = Math.Abs((_selectIndex + indexChange) % _maxIndex);
            SelectUnit(_playerUnits[_selectIndex]);
        }

        private void MoveActionSelection(int indexChange)
        {
            _unitMenu.MoveSelection(indexChange);
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

        private void ConfirmChoice()
        {
            if (_isPlayerSelected && _isActionSelected)
                ConfirmEnemyChoice();
            else if (_isPlayerSelected)
                ConfirmActionChoice();
            else
                ConfirmPlayerChoice();
        }

        private void ConfirmPlayerChoice()
        {
            manager.SelectPlayerUnit(_playerUnits[_selectIndex]);
            ShowUnitMenu();
            
            _isPlayerSelected = true;
            _selectIndex = 0;
            _maxIndex = _enemies.Count;
        }
        
        private void ShowUnitMenu()
        {
            _unitMenu = Instantiate(unitMenuPrefab, _playerUnits[_selectIndex].transform)
                .GetComponent<UnitMenu>();
            _unitMenu.selector = this;
            _unitMenu.manager = manager;
            
        }

        private void ConfirmActionChoice()
        {
            _unitMenu.Select();
            _isActionSelected = true;
        }

        private void ConfirmEnemyChoice()
        {
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