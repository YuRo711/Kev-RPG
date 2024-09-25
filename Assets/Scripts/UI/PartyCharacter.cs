using Combat;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PartyCharacter : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private TMP_Text nameText;

        public void SetData(UnitData unitData)
        {
            nameText.text = unitData.name;
            image.sprite = unitData.UnitSprite;
        }
    }
}