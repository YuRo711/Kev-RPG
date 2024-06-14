using UnityEngine;

namespace Player
{
    public class FollowingCharacter : MovingCharacter
    {
        [SerializeField] private MovingCharacter following;
        
        #region Private Methods

        protected override void Move(float inputX, float inputY)
        {
            
            AnimateMovement(inputX, inputY);
        }

        #endregion

        #region MonoBehaviour Callbacks

        private void Update()
        {
        }

        #endregion
        
    }
}