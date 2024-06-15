using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public abstract class MovingCharacter : MonoBehaviour
    {
        #region Fields
        
        [SerializeField] protected Rigidbody2D characterRigidbody;
        [SerializeField] protected Animator animator;
        
        private int _animatorDirectionHash;
        private int _animatorIsMovingHash;

        #endregion

        #region Methods
        
        protected void AnimateMovement(float inputX, float inputY)
        {
            if (inputX != 0)
            {
                animator.SetInteger(_animatorDirectionHash,
                    inputX > 0 ? (int)MoveDirections.Right : (int)MoveDirections.Left);
                animator.SetBool(_animatorIsMovingHash, true);
            }
            else if (inputY != 0)
            {
                animator.SetInteger(_animatorDirectionHash,
                    inputY > 0 ? (int)MoveDirections.Up : (int)MoveDirections.Down);
                animator.SetBool(_animatorIsMovingHash, true);
            }
            else
            {
                animator.SetBool(_animatorIsMovingHash, false);
            }
        }
        
        #endregion

        #region MonoBehaviour Callbacks

        protected virtual void Awake()
        {
            _animatorDirectionHash = Animator.StringToHash("Direction");
            _animatorIsMovingHash = Animator.StringToHash("IsMoving");
        }
        
        #endregion
    }
}