using UnityEngine;

namespace Combat
{
    public class UnitPointer : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        public void SetVisibility(bool isVisible)
        {
            spriteRenderer.enabled = isVisible;
        }
    }
}