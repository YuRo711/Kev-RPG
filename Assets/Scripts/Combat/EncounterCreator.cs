using System;
using System.Collections.Generic;
using Party;
using UnityEngine;
using UnityEngine.Serialization;
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
        [SerializeField] private EncounterManager manager;
        [SerializeField] private CharacterSelector selector;

        [Header("Prefabs")] 
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private GameObject playerPrefab;

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
            var enemyList = new List<Enemy>();
            for (int i = 0; i < encounterData.enemies.Length; i++)
            {
                var enemy = Instantiate(enemyPrefab, enemyPositions[i]);
                var enemyComponent = enemy.GetComponent<Enemy>();
                enemyComponent.CreateUnit(encounterData.enemies[i], manager);
                enemyList.Add(enemyComponent);
            }
            selector.SetEnemies(enemyList);
        }

        private void CreatePlayers()
        {
            var playerList = new List<PlayerUnit>();
            for (int i = 0; i < partyData.charactersData.Length; i++)
            {
                var unit = Instantiate(playerPrefab, playerPositions[i]);
                var unitComponent =unit.GetComponent<PlayerUnit>();
                unitComponent.CreateUnit(partyData.charactersData[i], manager);
                playerList.Add(unitComponent);
            }
            selector.SetPlayers(playerList);
            manager.SetPlayers(playerList);
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