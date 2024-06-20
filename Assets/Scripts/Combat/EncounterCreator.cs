using System;
using Party;
using UnityEngine;
using UnityEngine.UI;

namespace Combat
{
    public class EncounterCreator : MonoBehaviour
    {
        #region Fields
        
        [Header("Data")]
        [SerializeField] private EncounterData encounterData;
        [SerializeField] private PartyData partyData;
        
        [Header("Objects")]
        [SerializeField] private Image bgImage;
        [SerializeField] private Transform[] enemyPositions;
        [SerializeField] private Transform[] playerPositions;

        [Header("Prefabs")] 
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private GameObject playerPrefab;

        private EncounterManager _manager;

        #endregion

        #region Private Methods

        private void CreateEncounter()
        {
            bgImage.sprite = encounterData.background;
            CreateEnemies();
            CreatePlayers();
        }

        private void CreateEnemies()
        {
            for (int i = 0; i < encounterData.enemies.Length; i++)
            {
                var enemy = Instantiate(enemyPrefab, enemyPositions[i]);
                enemy.GetComponent<Enemy>()
                    .CreateUnit(encounterData.enemies[i], _manager);
            }
        }

        private void CreatePlayers()
        {
            for (int i = 0; i < partyData.charactersData.Length; i++)
            {
                var unit = Instantiate(playerPrefab, playerPositions[i]);
                unit.GetComponent<PlayerUnit>()
                    .CreateUnit(partyData.charactersData[i], _manager);
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