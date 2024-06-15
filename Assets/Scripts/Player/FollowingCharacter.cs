using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Player
{
    public class FollowingCharacter : MovingCharacter
    {
        #region Fields
        
        [SerializeField] private PlayerMovement following;

        #endregion

        #region Public Methods

        public void Follow(Vector2 newPos, MoveDirections direction)
        {
            characterRigidbody.MovePosition(newPos);
            AnimateMovement(direction);
        }

        public void Stop()
        {
            AnimateMovement(MoveDirections.None);
        }

        #endregion

        #region MonoBehaviour Callbacks

        protected override void Awake()
        {
            base.Awake();
            following.followers.Add(this);
        }

        #endregion
        
    }
}