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

        private void Awake()
        {
            if (itemData != null)
                Initialize(itemData);
        }

        public void Initialize(ItemData _itemData)
        {
            image.sprite = _itemData.sprite;
            priceText.text = _itemData.price.ToString();
            nameText.text = _itemData.itemName;
        }
    }
}