using Cysharp.Threading.Tasks;
using Items;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UI
{
    public class KeyAnimation : MonoBehaviour
    {
        #region Fields

        [SerializeField] private ItemData[] keyData;
        [SerializeField] private Transform keyTransform;
        [SerializeField] private float duration;
        [SerializeField] private float waitTime;
        [SerializeField] private Image image;
        [SerializeField] private UIOverlay overlay;

        #endregion
        
        #region Methods

        public void ShowKey(int keyId)
        {
            Debug.Log(keyId);
            image.sprite = keyData[keyId].sprite;
            image.enabled = true;
            overlay.Activate();
            _ = Appear(keyId);
        }

        private async UniTask Appear(int keyId)
        {
            keyTransform.localScale = Vector3.zero;

            while (keyTransform.localScale != Vector3.one)
            {
                keyTransform.localScale += Vector3.one * 0.01f;
                await UniTask.WaitForSeconds(duration / 100);
            }

            await UniTask.WaitForSeconds(waitTime);

            while (keyTransform.localScale != Vector3.zero)
            {
                keyTransform.localScale -= Vector3.one * 0.01f;
                await UniTask.WaitForSeconds(duration / 100);
            }
            
            image.enabled = false;
            if (keyId != 1)
                overlay.Deactivate();
        }
        
        #endregion
    }
}