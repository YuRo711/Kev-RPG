using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerControls : MonoBehaviour
    {
        #region Fields

        [SerializeField] private float speed;
        [SerializeField] private Rigidbody2D playerRigidbody;
        [SerializeField] private Animator animator;

        private int _animatorDirectionHash;
        private int _animatorIsMovingHash;

        #endregion

        #region Private Methods

        private void GetKeyInput()
        {
            var inputX = Input.GetAxis("Horizontal");
            var inputY = Input.GetAxis("Vertical");
        
            Move(inputX, inputY);
        }

        private void Move(float inputX, float inputY)
        {
            playerRigidbody.MovePosition(transform.position + new Vector3(inputX, inputY) * 
                (Time.fixedDeltaTime * speed));

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

        private void Awake()
        {
            _animatorDirectionHash = Animator.StringToHash("Direction");
            _animatorIsMovingHash = Animator.StringToHash("IsMoving");
        }

        private void FixedUpdate()
        {
            GetKeyInput();
        }

        #endregion
    }
}
