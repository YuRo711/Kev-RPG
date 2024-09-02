using System.Linq;
using Combat;
using UnityEngine;
using Utils;

namespace Items
{
    [CreateAssetMenu(menuName = "Store data")]
    public class StoreData : ScriptableObject
    {
        public SerializablePair<ItemData, int>[] items;
        
        public SerializablePair<ItemData, int> GetItemStock(ItemData itemData)
        {
            return items
                .First(item => item.left.itemName == itemData.itemName);
        }

        public void DecreaseItemStock(ItemData itemData)
        {
            GetItemStock(itemData).right--;
        }
    }
}