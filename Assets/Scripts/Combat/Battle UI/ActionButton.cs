using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Combat
{
    public class ActionButton : MonoBehaviour
    {
        #region Fields

        [SerializeField] private UnitMenu unitMenu;
        [SerializeField] private string buttonName;
        [SerializeField] private Image image;

        private static Dictionary<string, ICommand> _commands;

        #endregion

        
        #region Methods

        public void OnClick()
        {
            _commands[buttonName].Execute();
        }

        public void Select()
        {
            image.color = Color.yellow;;
        }

        public void Deselect()
        {
            image.color = Color.white;;
        }

            
        private void Start()
        {
            _commands = new()
            {
                {"back", new DeselectCommand(unitMenu.selector)},
                {"attack", new AttackCommand(unitMenu.manager)},
            };
        }

        #endregion
    }
}