using System;
using System.Collections.Generic;
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

        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Sprite openSprite;
        
        [SerializeField] private int number;
        private static readonly List<bool> ChestsOpen = new ();

        public void OnInteract()
        {
            if (!IsPlayerInBox || ChestsOpen[number]) return;
            
            partyData.money += (int)(Random.value * maxValue);
            moneyEvent.Raise();

            ChestsOpen[number] = true;
            OpenSprite();
        }

        private void OpenSprite()
        {
            spriteRenderer.sprite = openSprite;
        }

        private void Start()
        {
            if (ChestsOpen.Count <= number)
                ChestsOpen.Add(false);
        }
    }
}