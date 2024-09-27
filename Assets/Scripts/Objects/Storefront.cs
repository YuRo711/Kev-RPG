using Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

namespace Objects
{
    public class Storefront : PlayerBoxObject
    {
        [SerializeField] private GameEvent enterEvent;
        
        public override void OnInteract()
        {
            if (!IsPlayerInBox)
                return;
            
            enterEvent.Raise();
            SceneManager.LoadScene("Store");
        }
    }
}