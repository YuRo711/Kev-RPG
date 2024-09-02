using Combat;
using UnityEngine;
using Utils;

namespace Items
{
    [CreateAssetMenu(menuName = "Store data")]
    public class StoreData : ScriptableObject
    {
        public ItemData[] items;
    }
}