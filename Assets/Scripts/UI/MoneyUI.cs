using System;
using Party;
using TMPro;
using UnityEngine;
using Utils;

namespace UI
{
    public class MoneyUI : GameEventListener
    {
        [SerializeField] private TMP_Text uiText;
        [SerializeField] private PartyData partyData;

        public void OnMoneyChange()
        {
            uiText.text = partyData.money.ToString();
        }
    }
}