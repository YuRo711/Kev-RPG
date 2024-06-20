using System;
using UnityEngine;
using UnityEngine.UI;

namespace Combat
{
    public class EncounterCreator : MonoBehaviour
    {
        #region Fields
        
        [SerializeField] private EncounterData encounterData;
        [SerializeField] private Image bgImage;

        #endregion

        #region Public Methods

        public void CreateEncounter()
        {
            bgImage.sprite = encounterData.background;
        }

        #endregion

        #region MonoBehaviour Callbacks

        private void Awake()
        {
            CreateEncounter();
        }

        #endregion
    }
}