using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Combat
{
    public class FadingText : MonoBehaviour
    {
        [SerializeField] private float fadingDuration;
        [SerializeField] private float maxY;
        [SerializeField] private TMP_Text text;
        
        #region Public Methods

        public void SetText(string newText)
        {
            text.text = newText;
            StartFading();
        }

        #endregion
        
        #region Private Methods

        private async void StartFading()
        {
            await Fade();
        }

        private async UniTask Fade()
        {
            var waitingTime = 0f;
            var deltaY = maxY / (fadingDuration / 0.02f);
            
            while (waitingTime < fadingDuration)
            {
                text.color = Color.Lerp(Color.white, Color.clear, waitingTime / fadingDuration);
                text.transform.position += Vector3.up * deltaY;
                
                waitingTime += 0.02f;
                await UniTask.WaitForSeconds(0.02f);
            }
        }

        #endregion
    }
}