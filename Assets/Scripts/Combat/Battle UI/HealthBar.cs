using System;
using UnityEngine;
using UnityEngine.UI;

namespace Combat
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider slider;

        public void UpdateSlider(float health)
        {
            slider.value = health;
        }
    }
}