using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Combat
{
    public class UnitMenu : MonoBehaviour
    {
        #region Fields
        
        public CharacterSelector selector;
        public EncounterManager manager;

        [SerializeField] private ActionButton[] buttons;
        private int _selectIndex;

        #endregion
        
        #region Public Methods
        
        public void MoveSelection(int indexChange)
        {
            buttons[_selectIndex].Deselect();
            _selectIndex = Math.Abs((_selectIndex + indexChange) % buttons.Length);
            buttons[_selectIndex].Select();
        }

        public void Select()
        {
            buttons[_selectIndex].OnClick();
            Hide();
        }

        public void Hide()
        {
            Destroy(gameObject);
        }

        #endregion

        #region MonoBehaviour Callbacks

        private void Awake()
        {
            _selectIndex = 0;
            buttons[0].Select();
        }

        #endregion
    }
}