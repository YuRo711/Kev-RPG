using System;
using System.Collections.Generic;
using Items;
using Party;
using UnityEngine;
using Utils;
using Random = UnityEngine.Random;

namespace Objects
{
    public class Chest : PlayerBoxObject
    {
        [SerializeField] private int maxValue;
        [SerializeField] private PartyData partyData;
        [SerializeField] private GameEvent moneyEvent;
        
        [SerializeField] private bool containsKey;
        [SerializeField] private ItemData keyData;

        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Sprite openSprite;
        
        [SerializeField] private int number;
        private bool _isOpen;

        public override void OnInteract()
        {
            if (!IsPlayerInBox || _isOpen) return;
            
            partyData.money += (int)(Random.value * maxValue);
            moneyEvent.Raise();
            
            if (containsKey)
                partyData.AddItem(keyData);

            _isOpen = true;
            OpenSprite();
        }

        private void OpenSprite()
        {
            spriteRenderer.sprite = openSprite;
        }
    }
}