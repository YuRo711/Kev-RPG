using Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

namespace Objects
{
    public class Storefront : PlayerBoxObject
    {
        [SerializeField] private GameEvent enterEvent;
        
        public void OnInteract()
        {
            enterEvent.Raise();
            SceneManager.LoadScene("Store");
        }
    }
}