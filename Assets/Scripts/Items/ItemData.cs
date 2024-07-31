using Combat;
using UnityEngine;
using Utils;

namespace Items
{
    [CreateAssetMenu(menuName = "Item data")]
    public class ItemData : ScriptableObject
    {
        public string itemName;
        public Sprite sprite;
        public int price;
    }
}