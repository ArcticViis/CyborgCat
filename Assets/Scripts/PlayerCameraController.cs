using UnityEngine;
using System.Collections;

namespace Werecat
{
    public class PlayerCameraController : MonoBehaviour
    {
        [SerializeField]
        private Vector3 cameraOffset = Vector3.zero;
        [SerializeField]
        private float lookSensitivity = 3f;
        public float LookSensitivity
        {
            get { return lookSensitivity; }
        }
        [SerializeField]
        private float lookMinMAx = 85f;
        [SerializeField]
        private Transform pivot;
        [SerializeField]
        private float sweepr = 1f;
        private float distanceOffset;

        private Camera cam;
        private Rigidbody rb;


        private float cameraXRotation = 0f;
        // Use this for initialization
        void Start()
        {
            cam = Camera.main;
            rb = GetComponent<Rigidbody>();
        }

        void Update()
        {
            CameraCollision();
        }
        void LateUpdate()
        {
            UpdateCamera();
            
        }
        void UpdateCamera()
        {
            cameraXRotation = Mathf.Clamp(cameraXRotation - Input.GetAxisRaw("Mouse Y") * lookSensitivity, -lookMinMAx, lookMinMAx);
            cameraOffset.z -= Input.GetAxis("Mouse ScrollWheel")* Time.fixedDeltaTime * 30 ;
            pivot.localPosition = new Vector3(cameraOffset.x, cameraOffset.y, 0);
            
            pivot.localEulerAngles = new Vector3(cameraXRotation, pivot.localEulerAngles.y, 0);
            cam.transform.position = pivot.TransformPoint(Vector3.forward * -(cameraOffset.z - distanceOffset));
            cam.transform.LookAt(pivot);
        }

        void CameraCollision() // http://wiki.unity3d.com/index.php/SmoothFollowWithCameraBumper
        {
            float _distance = cameraOffset.z;
            RaycastHit _hit;

            if (Physics.Raycast(pivot.position , pivot.forward * -1, out _hit, (_distance + 0.5f)))
                {
                Debug.DrawLine(pivot.position, _hit.point);
                distanceOffset = cameraOffset.z - _hit.distance + 0.8f;
                distanceOffset = Mathf.Clamp(distanceOffset, 0, cameraOffset.z);

            }
            else {
                distanceOffset = 0;
            }
        }
    }
}

