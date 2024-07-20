using System;
using UnityEngine;
using UnityEngine.UI;

namespace Combat
{
    public class EndBattleUI : MonoBehaviour
    {
        #region Fields

        [SerializeField] private GameObject gameOverUI;
        [SerializeField] private GameObject winUI;
        [SerializeField] private Image overlay;

        #endregion
        
        #region Unity Methods

        public void GameOver()
        {
            overlay.enabled = true;
            gameOverUI.SetActive(true);
        }

        public void WinScreen()
        {
            overlay.enabled = true;
            winUI.SetActive(true);
        }

        #endregion
    }
}