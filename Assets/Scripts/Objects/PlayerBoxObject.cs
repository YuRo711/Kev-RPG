using System;
using Player;
using UnityEngine;

namespace Utils
{
    public class PlayerBoxObject : GameEventListener
    {
        [SerializeField] private BoxCollider2D boxCollider;
        protected bool IsPlayerInBox;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.CompareTag("Player"))
                return;

            IsPlayerInBox = true;
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (!other.gameObject.CompareTag("Player"))
                return;

            IsPlayerInBox = false;
        }

        public virtual void OnInteract() { }
    }
}