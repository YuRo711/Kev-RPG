using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Items
{
    public class StoreItem : Item
    {
        [SerializeField] private Button buyButton;
        [SerializeField] private Image buyButtonImage;
        private StoreManager _storeManager;

        private void Awake()
        {
            if (itemData != null)
                Initialize(itemData, null);
        }

        public void Initialize(ItemData _itemData, StoreManager storeManager)
        {
            _storeManager = storeManager;
            Initialize(_itemData);
        }

        public void DisableButton()
        {
            buyButton.interactable = false;
            buyButtonImage.color = Color.gray;
        }

        public void EnableButton()
        {
            buyButton.interactable = true;
            buyButtonImage.color = Color.white;
        }

        public void Buy()
        {
            _storeManager.BuyItem(itemData);
        }
    }
}