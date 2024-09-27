using UI;
using UnityEngine;
using Utils;

namespace Objects
{
    public class Door : PlayerBoxObject
    {
        [SerializeField] private DoorUI doorUI;
        
        public override void OnInteract()
        {
            if (!IsPlayerInBox)
                return;
            
            doorUI.Show();
        }
    }
}