using UnityEngine;
using UnityEngine.UI;

namespace Combat
{
    public class UnitPointer : MonoBehaviour
    {
        [SerializeField] private Image image;

        public void SetVisibility(bool isVisible)
        {
            image.enabled = isVisible;
        }
    }
}