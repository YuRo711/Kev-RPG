using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Utils;

namespace Player
{
    public class PlayerMovement : MovingCharacter
    {
        #region Fields

        public List<FollowingCharacter> followers = new ();
        
        [SerializeField] private int traceLimit;
        [SerializeField] private int traceDistance;
        [SerializeField] private float speed;
        private ShiftingArray<Vector2> _trace;

        #endregion
        
        #region Private Methods

        private void Move(float inputX, float inputY)
        {
            characterRigidbody.MovePosition(transform.position + new Vector3(inputX, inputY) * 
                (Time.deltaTime * speed));
            
            AnimateMovement(inputX, inputY);
        }

        private void LeaveTrace()
        {
            _trace.ShiftRight(transform.position);

            var followerIndex = 1;
            foreach (var follower in followers)
            {
                follower.Follow(_trace[traceDistance * followerIndex]);
                followerIndex++;
            }
        }

        private void GetKeyInput()
        {
            var inputX = Input.GetAxis("Horizontal");
            var inputY = Input.GetAxis("Vertical");
        
            Move(inputX, inputY);
            if (inputX != 0 || inputY != 0)
                LeaveTrace();
        }

        #endregion

        #region MonoBehaviour Callbacks

        protected override void Awake()
        {
            base.Awake();
            _trace = new ShiftingArray<Vector2>(traceLimit);
        }

        private void Update()
        {
            GetKeyInput();
        }

        #endregion
    }
}
