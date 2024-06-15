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
        private ShiftingArray<MoveDirections> _directionTrace;

        #endregion
        
        #region Private Methods

        private void Move(float inputX, float inputY)
        {
            characterRigidbody.MovePosition(transform.position + new Vector3(inputX, inputY) * 
                (Time.fixedDeltaTime * speed));
        }

        private void LeaveTrace(MoveDirections moveDirection)
        {
            _trace.ShiftRight(transform.position);
            _directionTrace.ShiftRight(moveDirection);
            
            if (_trace.MaxIndex < traceDistance)
                return;

            var followerIndex = 1;
            foreach (var follower in followers)
            {
                follower.Follow(_trace[traceDistance * followerIndex],
                    _directionTrace[traceDistance * followerIndex]);
                followerIndex++;
            }
        }

        private void GetKeyInput()
        {
            var inputX = Input.GetAxis("Horizontal");
            var inputY = Input.GetAxis("Vertical");
        
            Move(inputX, inputY);
            
            var moveDirection = GetMovementDirection(inputX, inputY);
            AnimateMovement(moveDirection);
            
            if (inputX != 0 || inputY != 0)
                LeaveTrace(moveDirection);
        }

        #endregion

        #region MonoBehaviour Callbacks

        protected override void Awake()
        {
            base.Awake();
            _trace = new ShiftingArray<Vector2>(traceLimit);
            _directionTrace = new ShiftingArray<MoveDirections>(traceLimit);
        }

        private void FixedUpdate()
        {
            GetKeyInput();
        }

        #endregion
    }
}
