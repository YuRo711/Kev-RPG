using System;
using System.Collections.Generic;
using Party;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Items
{
    public class StoreManager : MonoBehaviour
    {
        [SerializeField] private PartyData partyData;
        [SerializeField] private StoreData storeData;
        [SerializeField] private GameObject itemPrefab;
        [SerializeField] private Transform itemsParent;
        private readonly Dictionary<ItemData, GameObject> _items = new ();

        #region Methods

        private void InitializeItems()
        {
            foreach (var itemData in storeData.items)
            {
                if (itemData.right == 0) continue;
                
                var newItem = Instantiate(itemPrefab, itemsParent);
                newItem.GetComponent<Item>().Initialize(itemData.left, this);
                _items.Add(itemData.left, newItem);
            }
        }

        public void BuyItem(ItemData itemData)
        {
            storeData.DecreaseItemStock(itemData);
            if (storeData.GetItemStock(itemData).right == 0)
                Destroy(_items[itemData]);
            partyData.money -= itemData.price;
        }

        public void LeaveStore()
        {
            SceneManager.LoadScene("World");
        }

        #endregion

        #region MB Callbacks

        private void Awake()
        {
            InitializeItems();
        }

        #endregion
    }
}
