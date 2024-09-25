using System;
using System.Collections.Generic;
using Party;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

namespace Items
{
    public class StoreManager : MonoBehaviour
    {
        [SerializeField] private PartyData partyData;
        [SerializeField] private StoreData storeData;
        [SerializeField] private GameObject itemPrefab;
        [SerializeField] private Transform itemsParent;
        [SerializeField] private GameEvent moneyEvent;
        [SerializeField] private GameEvent exitEvent;
        private readonly Dictionary<ItemData, Item> _items = new ();

        #region Methods

        private void InitializeItems()
        {
            foreach (var itemData in storeData.items)
            {
                if (itemData.right == 0) continue;
                
                var newItem = Instantiate(itemPrefab, itemsParent);
                var itemComponent = newItem.GetComponent<Item>();
                itemComponent.Initialize(itemData.left, this);
                _items.Add(itemData.left, itemComponent);
            }
        }

        public void BuyItem(ItemData itemData)
        {
            storeData.DecreaseItemStock(itemData);
            if (storeData.GetItemStock(itemData).right == 0)
                Destroy(_items[itemData].gameObject);
            
            partyData.money -= itemData.price;
            moneyEvent.Raise();
            CheckPlayerMoney();
            
            partyData.AddItem(itemData);
        }

        public void LeaveStore()
        {
            SceneManager.LoadScene("World");
            exitEvent.Raise();
        }

        public void CheckPlayerMoney()
        {
            foreach (var itemPair in _items)
            {
                if (itemPair.Key.price > partyData.money)
                    itemPair.Value.DisableButton();
            }
        }

        #endregion

        #region MB Callbacks

        private void Awake()
        {
            InitializeItems();
            CheckPlayerMoney();
        }

        #endregion
    }
}
