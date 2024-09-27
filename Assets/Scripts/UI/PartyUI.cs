using System;
using Items;
using Party;
using UnityEngine;

namespace UI
{
    public class PartyUI : MonoBehaviour
    {
        #region Fields

        [SerializeField] private UIOverlay overlay;
        [SerializeField] private GameObject itemPrefab;
        [SerializeField] private GameObject characterPrefab;
        
        [SerializeField] private GameObject parentObject;
        [SerializeField] private Transform characterParent;
        [SerializeField] private Transform itemParent;

        [SerializeField] private PartyData partyData;

        private bool _isActive;

        #endregion

        #region Methods

        public void UpdateCharacters()
        {
            foreach (Transform child in characterParent)
                Destroy(child.gameObject);
            
            foreach (var character in partyData.charactersData)
            {
                var characterObject = Instantiate(characterPrefab, characterParent);
                characterObject.GetComponent<PartyCharacter>().SetData(character);
            }
        }

        public void UpdateItems()
        {
            foreach (Transform child in itemParent)
                Destroy(child.gameObject);
            
            foreach (var item in partyData.inventory)
            {
                var itemObject = Instantiate(itemPrefab, itemParent);
                var itemComponent = itemObject.GetComponent<InventoryItem>();
                itemComponent.Initialize(item);
            }
        }

        public void Exit()
        {
            overlay.Deactivate();
            parentObject.SetActive(false);
            _isActive = false;
        }

        private void Show()
        {
            overlay.Activate();
            parentObject.SetActive(true);
            _isActive = true;
        }

        #endregion

        #region MB Callbacks

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                if (_isActive)
                    Exit();
                else
                    Show();
            }
        }

        private void Start()
        {
            UpdateItems();
            UpdateCharacters();
        }

        #endregion
    }
    
}