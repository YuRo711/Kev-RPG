using Party;
using UnityEngine;
using Utils;

namespace Objects
{
    public class Chest : PlayerBoxObject
    {
        [SerializeField] private int maxValue;
        [SerializeField] private PartyData partyData;
        [SerializeField] private GameEvent moneyEvent;

        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Sprite openSprite;
        private bool isOpen;

        public void OnInteract()
        {
            if (!IsPlayerInBox || isOpen) return;
            
            partyData.money += (int)(Random.value * maxValue);
            moneyEvent.Raise();

            isOpen = true;
            spriteRenderer.sprite = openSprite;
        }
    }
}