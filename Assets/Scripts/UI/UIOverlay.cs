using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIOverlay : MonoBehaviour
    {
        [SerializeField] private Image image;

        public void Activate()
        {
            image.enabled = true;
        }

        public void Deactivate()
        {
            image.enabled = false;
        }
    }
}