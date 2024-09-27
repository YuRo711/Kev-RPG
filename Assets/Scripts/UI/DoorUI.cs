using Party;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UI
{
    public class DoorUI : MonoBehaviour
    {
        #region Fields

        [SerializeField] private UIOverlay overlay;
        [SerializeField] private GameObject parentObject;
        [SerializeField] private Image[] keyImages;

        #endregion

        #region Methods

        public void Exit()
        {
            overlay.Deactivate();
            parentObject.SetActive(false);
        }

        public void Show()
        {
            overlay.Activate();
            parentObject.SetActive(true);
        }

        public void AddKey(int keyId)
        {
            keyImages[keyId].enabled = true;
        }

        #endregion
    }
}