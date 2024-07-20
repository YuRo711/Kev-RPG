using System;
using UnityEngine;

namespace Utils
{
    public class InputDetector : MonoBehaviour
    {
        [SerializeField] private GameEvent eEvent;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
                eEvent.Raise();
        }
    }
}