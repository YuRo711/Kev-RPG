using Combat;
using UnityEngine;

namespace Party
{
    [CreateAssetMenu(menuName = "Party data")]
    public class PartyData : ScriptableObject
    {
        public UnitData[] charactersData;
        public int money;
    }
}