using System;
using UnityEngine;
using Utils;

namespace Combat
{
    public class SelectorsManager : MonoBehaviour
    {
        #region Fields
        
        private CombatSelector currentSelector;
        private ICommand _onSelectTarget;

        public PlayerSelector playerSelector;
        public CombatSelector enemySelector;
        
        [SerializeField] private EncounterManager manager;
        [SerializeField] private GameObject menuPrefab;

        #endregion
        
        #region Unity Methods

        public void ResetAllSelection()
        {
            playerSelector.ResetTurns();
            UndoSelection();
            UndoSelection();
        }

        public void ActivatePlayerSelection()
        {
            currentSelector = playerSelector;
            playerSelector.Activate();
        }

        public void SetCommand(ICommand command)
        {
            _onSelectTarget = command;
        }
        
        private void ProcessInput()
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
                currentSelector.MoveSelection(1);
            else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
                currentSelector.MoveSelection(-1);
            else if (Input.GetKeyDown(KeyCode.Return))
                ConfirmSelection();
            else if (Input.GetKeyDown(KeyCode.Escape))
                UndoSelection();
        }

        public void UndoSelection()
        {
            if (currentSelector == playerSelector) return;
            
            currentSelector.UndoSelection();
            currentSelector = currentSelector == enemySelector ? CreateMenu() : playerSelector;
            currentSelector.Activate();
        }

        private void ConfirmSelection()
        {
            if (currentSelector == enemySelector)
            {
                ((PlayerUnit)playerSelector.currentUnit).hasMadeTurn = true;
                manager.SelectEnemy((Enemy)enemySelector.currentUnit);
                _onSelectTarget?.Execute();
                return;
            }
            if (currentSelector == playerSelector)
            {
                manager.SelectPlayerUnit((PlayerUnit)playerSelector.currentUnit);
                currentSelector = CreateMenu();
            }
            currentSelector.Activate();
        }

        private UnitMenu CreateMenu()
        {
            var menuObject = Instantiate(menuPrefab, 
                ((MonoBehaviour)playerSelector.currentUnit).transform);
            return menuObject.GetComponent<UnitMenu>();
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