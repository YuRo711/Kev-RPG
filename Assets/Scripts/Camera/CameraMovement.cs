namespace Camera
{
    using UnityEngine;
    public class CameraMovement : MonoBehaviour
    {
        #region Fields
        
        [SerializeField] private Transform cameraTarget;
        [SerializeField] private Camera cam;

        #endregion

        #region Methods

        public void ChangeCameraTarget(Transform newCameraTargetTransform)
        {
            cameraTarget = newCameraTargetTransform;
        }

        private void UpdateCameraPosition()
        {
            var position = cam.transform.position;
            var targetPosition = new Vector3(cameraTarget.position.x, cameraTarget.position.y, position.z);

            cam.transform.position = targetPosition;
        }

        #endregion

        #region MonoBehaviour Callbacks

        private void Awake()
        {
            cam ??= GetComponent<Camera>();
        }

        private void Update()
        {
            UpdateCameraPosition();
        }

        #endregion
    }
}