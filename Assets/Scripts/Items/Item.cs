using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Items
{
    public abstract class Item : MonoBehaviour
    {
        public ItemData itemData;
        [SerializeField] protected Image image;
        [SerializeField] protected TMP_Text priceText;
        [SerializeField] protected TMP_Text nameText;
        

        public void Initialize(ItemData _itemData)
        {
            image.sprite = _itemData.sprite;
            priceText.text = _itemData.price.ToString();
            nameText.text = _itemData.itemName;
            itemData = _itemData;
        }
    }
}