using System;
using UnityEngine;

namespace Items
{
    public class StoreManager : MonoBehaviour
    {
        [SerializeField] private StoreData storeData;
        [SerializeField] private GameObject itemPrefab;
        [SerializeField] private Transform itemsParent;

        #region Methods

        private void InitializeItems()
        {
            foreach (var itemData in storeData.items)
            {
                var newItem = Instantiate(itemPrefab, itemsParent);
                newItem.GetComponent<Item>().Initialize(itemData);
            }
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
