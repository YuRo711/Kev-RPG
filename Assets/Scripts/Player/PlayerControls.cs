using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerControls : MovingCharacter
    {
        [SerializeField] private float speed;
        
        #region Private Methods

        protected override void Move(float inputX, float inputY)
        {
            characterRigidbody.MovePosition(transform.position + new Vector3(inputX, inputY) * 
                (Time.deltaTime * speed));
            
            AnimateMovement(inputX, inputY);
        }

        private void GetKeyInput()
        {
            var inputX = Input.GetAxis("Horizontal");
            var inputY = Input.GetAxis("Vertical");
        
            Move(inputX, inputY);
        }

        #endregion

        #region MonoBehaviour Callbacks

        private void Update()
        {
            GetKeyInput();
        }

        #endregion
    }
}
