using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Combat
{
    public class CharacterSelector : GameEventListener
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
        private bool _isChoosingEnemy;
        private ICommand _onSelect;

        #endregion

        
        #region Public Methods

        public void SetPlayers(List<PlayerUnit> playerUnits)
        {
            _playerUnits = playerUnits;
            _maxIndex = _playerUnits.Count;
            _selectIndex = 0;
            _isPlayerSelected = false;
            _isChoosingEnemy = false;
            SelectUnit(_playerUnits[_selectIndex]);
        }
        public void SetEnemies(List<Enemy> enemies)
        {
            _enemies = enemies;
        }

        public void UndoSelection()
        {
            if (_isChoosingEnemy)
            {
                DeselectUnit(_enemies[_selectIndex]);
                _isChoosingEnemy = false;
                ShowUnitMenu();
            }
            else if (_isPlayerSelected)
            {
                _unitMenu.Hide();
                _isPlayerSelected = false;
                _isChoosingEnemy = false;
            }
        }

        public void ActivateEnemySelection(ICommand commandOnSelect)
        {
            _isChoosingEnemy = true;
            _onSelect = commandOnSelect;
            _selectIndex = 0;
            SelectUnit(_enemies[0]);
        }

        public void ReloadSelection()
        {
            UndoSelection();
            UndoSelection();
            MovePlayerSelection(1);
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
            if (_isPlayerSelected && _isChoosingEnemy)
                MoveEnemySelection(indexChange);
            else if (_isPlayerSelected)
                MoveActionSelection(indexChange);
            else
                MovePlayerSelection(indexChange);
        }

        private void MovePlayerSelection(int indexChange)
        {
            DeselectUnit(_playerUnits[_selectIndex]);
            while (_playerUnits[_selectIndex].hasMadeTurn)
            {
                _selectIndex = Math.Abs((_selectIndex + indexChange) % _maxIndex);
            }
            SelectUnit(_playerUnits[_selectIndex]);
        }

        private void MoveActionSelection(int indexChange)
        {
            _unitMenu.MoveSelection(indexChange);
        }

        private void MoveEnemySelection(int indexChange)
        {
            DeselectUnit(_enemies[_selectIndex]);
            _selectIndex = (_selectIndex + indexChange) % _maxIndex;
            SelectUnit(_enemies[_selectIndex]);
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
            if (_isPlayerSelected && _isChoosingEnemy)
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
        }

        private void ConfirmEnemyChoice()
        {
            _playerUnits[_selectIndex].hasMadeTurn = true;
            manager.SelectEnemy(_enemies[_selectIndex]);
            _onSelect.Execute();
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