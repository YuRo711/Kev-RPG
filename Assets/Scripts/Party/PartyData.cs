using System.Collections.Generic;
using Combat;
using Items;
using UnityEngine;

namespace Party
{
    [CreateAssetMenu(menuName = "Party data")]
    public class PartyData : ScriptableObject
    {
        public UnitData[] charactersData;
        public int money;
        public List<ItemData> inventory;
        public Vector3 lastPosition;
        
        public void AddItem(ItemData item)
        {
            inventory.Add(item);
        }
    }
}