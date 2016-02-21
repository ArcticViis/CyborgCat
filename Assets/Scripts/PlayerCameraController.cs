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

        private Camera cam;
        private Rigidbody rb;


        private float cameraXRotation = 0f;
        // Use this for initialization
        void Start()
        {
            cam = Camera.main;
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void LateUpdate()
        {
            UpdateCamera();
            //CameraCollision();
        }
        void UpdateCamera()
        {
            cameraXRotation = Mathf.Clamp(cameraXRotation - Input.GetAxisRaw("Mouse Y") * lookSensitivity, -lookMinMAx, lookMinMAx);

            pivot.localPosition = new Vector3(cameraOffset.x, cameraOffset.y, 0);
            
            pivot.localEulerAngles = new Vector3(cameraXRotation, pivot.localEulerAngles.y, 0);
            cam.transform.position = pivot.TransformPoint(Vector3.forward * cameraOffset.z);
            cam.transform.LookAt(pivot);
        }

        void CameraCollision()
        {
            float _distance = cameraOffset.z;
            RaycastHit _hit;
            if(cam.GetComponent<Rigidbody>().SweepTest(cam.transform.forward * -1f, out _hit, 2f))
            {
                Debug.Log("sweep");
                _distance += sweepr * Time.deltaTime;
                _distance = Mathf.Clamp(_distance, -5f, 0f);
            }
            if (cam.GetComponent<Rigidbody>().SweepTest(cam.transform.forward * -2f, out _hit, 2f))
            { Debug.Log("sweep2"); }
            else
            {
                Debug.Log("back");
                _distance -= sweepr* Time.deltaTime ;
                _distance = Mathf.Clamp(_distance, -5f, 0f);
            }
            cameraOffset.z = _distance;



        }
    }
}

