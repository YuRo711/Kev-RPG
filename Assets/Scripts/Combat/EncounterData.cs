using UnityEngine;
using UnityEngine.Serialization;
using Utils;

namespace Combat
{
    [CreateAssetMenu(menuName = "Encounter data")]
    public class EncounterData : ScriptableObject
    {
        #region Fields & Properties

        public Sprite background;
        public UnitData[] enemies;
        public int rewardMoney;
        public bool rewardKey;

        #endregion

        public EncounterData(Sprite bg, UnitData[] enemiesData, int money)
        {
            background = bg;
            enemies = enemiesData;
            rewardMoney = money;
        }

        public void SetKey()
        {
            rewardKey = true;
        }
    }
}
