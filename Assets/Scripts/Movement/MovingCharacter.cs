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

        protected MoveDirections GetMovementDirection(float inputX, float inputY)
        {
            if (inputX != 0)
            {
                return inputX > 0 ? MoveDirections.Right : MoveDirections.Left;
            }
            if (inputY != 0)
            {
                return inputY > 0 ? MoveDirections.Up : MoveDirections.Down;
            }
            return MoveDirections.None;
        }
        
        protected void AnimateMovement(MoveDirections moveDirection)
        {
            if (moveDirection != MoveDirections.None)
            {
                animator.SetInteger(_animatorDirectionHash, (int)moveDirection);
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