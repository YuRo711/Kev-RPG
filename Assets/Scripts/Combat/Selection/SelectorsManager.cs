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
        private bool recentUndoFlag;

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

            recentUndoFlag = true;
            currentSelector.UndoSelection();
            currentSelector = currentSelector is UnitMenu ? playerSelector : CreateMenu();
            currentSelector.Activate();
        }

        private void ConfirmSelection()
        {
            currentSelector.OnSelect();
            if (currentSelector == enemySelector)
            {
                ((PlayerUnit)playerSelector.currentUnit).hasMadeTurn = true;
                manager.SelectEnemy((Enemy)enemySelector.currentUnit);
                _onSelectTarget?.Execute();
            }
            else if (currentSelector == playerSelector && !recentUndoFlag)
            {
                manager.SelectPlayerUnit((PlayerUnit)playerSelector.currentUnit);
                currentSelector = CreateMenu();
            }
            else if (!recentUndoFlag)
            {
                currentSelector = enemySelector;
            }
            currentSelector.Activate();
            recentUndoFlag = false;
        }

        private UnitMenu CreateMenu()
        {
            var menuObject = Instantiate(menuPrefab, 
                ((MonoBehaviour)playerSelector.currentUnit).transform);
            var menu = menuObject.GetComponent<UnitMenu>();
            menu.selectorsManager = this;
            return menu;
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