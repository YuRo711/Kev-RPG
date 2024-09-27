using Cysharp.Threading.Tasks;
using Items;
using UnityEngine;
using Utils;

namespace UI
{
    public class KeyAnimation : GameEventListener
    {
        #region Fields

        [SerializeField] private ItemData keyData;
        [SerializeField] private UIOverlay overlay;
        [SerializeField] private Transform keyTransform;
        [SerializeField] private float duration;
        [SerializeField] private float waitTime;

        #endregion
        
        #region Methods

        public void ShowKey()
        {
            _ = Appear();
        }

        private async UniTask Appear()
        {
            overlay.Activate();
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
            
            overlay.Deactivate();
        }
        
        #endregion
    }
}