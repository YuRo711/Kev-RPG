using System;
using Combat;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;
using Random = UnityEngine.Random;
using Vector2 = System.Numerics.Vector2;

namespace Player
{
    public class RandomEncounters : MonoBehaviour
    {
        #region Fields

        [SerializeField] private EncounterData[] encountersArray;
        [SerializeField] private MovingCharacter player;
        [SerializeField] private float tickDuration;
        [SerializeField] private float encounterProbability;
        [SerializeField] private float keyProbability;
        [SerializeField] private GameEvent moneyEvent;
        [SerializeField] private GameEvent endBattleEvent;
        [SerializeField] private GameEvent startBattleEvent;

        private bool isActive;

        #endregion

        #region Unity Methods

        private void StartTimer()
        {
            _ = Tick();
        }

        private async UniTask Tick()
        {
            while (isActive)
            {
                if (player.isMoving)
                {
                    var randomValue = Random.value;
                    if (randomValue <= encounterProbability)
                    {
                        GenerateEncounter();
                        return;
                    }
                }
                await UniTask.WaitForSeconds(tickDuration);
            }
        }

        private void GenerateEncounter()
        {
            var index = (int)(Random.value * encountersArray.Length);
            var encounterData = encountersArray[index];
            
            var keyRandom = Random.value;
            if (keyRandom <= keyProbability)
                encounterData.SetKey();
            
            CurrentEncounter.EncounterData = encounterData;
            startBattleEvent.Raise();
            
            SceneManager.LoadScene("Combat");
        }

        #endregion

        #region MB Callbacks

        private void Start()
        {
            moneyEvent.Raise();
            endBattleEvent.Raise();
            isActive = true;
            StartTimer();
        }

        #endregion
    }
}