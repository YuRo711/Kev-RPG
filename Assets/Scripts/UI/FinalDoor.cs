using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace UI
{
    public class FinalDoor : MonoBehaviour
    {
        [SerializeField] private bool isLeft;

        private async UniTask Move()
        {
            Vector3 finalPosition;
            if (isLeft)
                finalPosition = Vector3.left * 2000;
            else
                finalPosition = Vector3.right * 1000;

            while (transform.position != finalPosition)
            {
                transform.position += isLeft ? Vector3.left * 0.1f : Vector3.right * 0.1f;
                await UniTask.WaitForSeconds(0.05f);
            }
        }
        
        private void Awake()
        {
            _ = Move();
        }
    }
}