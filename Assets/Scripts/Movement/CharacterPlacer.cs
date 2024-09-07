using System;
using Combat;
using Party;
using UnityEngine;

namespace Player
{
    public class CharacterPlacer : MonoBehaviour
    {
        [SerializeField] private Transform characterTransform;
        [SerializeField] private PartyData partyData;
        
        public void RememberPosition()
        {
            partyData.lastPosition = characterTransform.position;
        }
        
        public void PlaceCharacters()
        {
            if (partyData.lastPosition != Vector3.zero)
            {
                foreach (var character in FindObjectsOfType<MovingCharacter>())
                {
                    character.transform.position = partyData.lastPosition;
                }
            }
        }
    }
}