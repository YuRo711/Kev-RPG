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
        [SerializeField] private Enemy[] enemyPositions;

        private EncounterManager _manager;

        #endregion

        #region Private Methods

        private void CreateEncounter()
        {
            bgImage.sprite = encounterData.background;
            CreateEnemies();
        }

        private void CreateEnemies()
        {
            for (int i = 0; i < encounterData.enemies.Length; i++)
            {
                enemyPositions[i].CreateUnit(encounterData.enemies[i], _manager);
            }
        }

        #endregion

        #region MonoBehaviour Callbacks

        private void Awake()
        {
            _manager = new EncounterManager();
            CreateEncounter();
        }

        #endregion
    }
}