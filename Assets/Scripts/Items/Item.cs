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
            image.sprite = itemData.sprite;
            priceText.text = itemData.price.ToString();
            nameText.text = itemData.itemName;
        }
    }
}