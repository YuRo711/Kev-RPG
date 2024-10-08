using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Items
{
    public class Item : MonoBehaviour
    {
        public ItemData itemData;
        [SerializeField] private Image image;
        [SerializeField] private TMP_Text priceText;
        [SerializeField] private TMP_Text nameText;
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
            image.sprite = _itemData.sprite;
            priceText.text = _itemData.price.ToString();
            nameText.text = _itemData.itemName;
            itemData = _itemData;
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