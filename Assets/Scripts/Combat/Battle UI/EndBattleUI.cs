using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Combat
{
    public class EndBattleUI : MonoBehaviour
    {
        #region Fields

        [SerializeField] private GameObject gameOverUI;
        [SerializeField] private GameObject winUI;
        [SerializeField] private GameObject keyUI;
        [SerializeField] private TMP_Text coins;
        [SerializeField] private Image overlay;

        #endregion
        
        #region Unity Methods

        public void GameOver()
        {
            overlay.enabled = true;
            gameOverUI.SetActive(true);
        }

        public void WinScreen(int reward, bool isKey)
        {
            overlay.enabled = true;
            coins.text = reward.ToString();
            winUI.SetActive(true);
            keyUI.SetActive(isKey);
        }

        public void GoToMap()
        {
            SceneManager.LoadScene("World");
        }

        #endregion
    }
}