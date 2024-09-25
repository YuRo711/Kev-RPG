using System;
using Party;
using UnityEngine;

namespace UI
{
    public class PartyUI : MonoBehaviour
    {
        #region Fields

        [SerializeField] private UIOverlay overlay;
        [SerializeField] private GameObject parentObject;
        [SerializeField] private GameObject itemPrefab;
        [SerializeField] private GameObject characterPrefab;

        [SerializeField] private PartyData partyData;

        private bool _isActive;

        #endregion

        #region Methods

        public void Exit()
        {
            overlay.Deactivate();
            parentObject.SetActive(false);
            _isActive = false;
        }

        private void Show()
        {
            overlay.Activate();
            parentObject.SetActive(true);
            _isActive = true;
        }

        #endregion

        #region MB Callbacks

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                if (_isActive)
                    Exit();
                else
                    Show();
            }
        }

        #endregion
    }
    
}