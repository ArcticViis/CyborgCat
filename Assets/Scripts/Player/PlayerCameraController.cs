using UnityEngine;
using System.Collections;

namespace Werecat
{
    public class PlayerCameraController : MonoBehaviour
    {
        [SerializeField]
        private Vector3 cameraOffset = Vector3.zero;
        [SerializeField]
        private Vector3 cameraZoomOffset = Vector3.zero;
        [SerializeField]
        private float cameraZoomSpeed = 0.8f;


        private Vector3 privcameraOffset = Vector3.zero;
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
        //private float sweepr = 1f;
        private float distanceOffset;


        [SerializeField]
        private float minFOV = 60f;
        [SerializeField]
        private float maxFOV = 70f;
        [SerializeField]
        //private float fovChangeSpeed = 0.2f;


        private Camera cam;
        private PlayerSettings ps;
        //private Rigidbody rb;

        public bool clamp = true;
        private float cameraXRotation = 0f;
        // Use this for initialization
        void Start()
        {
            cam = Camera.main;
            ps = GetComponent<PlayerSettings>();
            //rb = GetComponent<Rigidbody>();
            privcameraOffset = cameraOffset;
            cam.transform.parent = pivot;
            cam.transform.localEulerAngles = Vector3.zero;
            cam.transform.localPosition = new Vector3(0, 0, -2) ;
        }

        void Update()
        {
            
            CameraZoom(Input.GetButton("Fire2"));
            UpdateCamera();

        }
        void LateUpdate()
        {
            CameraCollision();
            
            

        }
        void UpdateCamera()
        {
            if (clamp)
            {
                cameraXRotation = Mathf.Clamp(cameraXRotation - Input.GetAxisRaw("Mouse Y") * ps.LookSensitivityX, -lookMinMAx, lookMinMAx);
            }
            else
            {
                cameraXRotation -= Input.GetAxisRaw("Mouse Y") * ps.LookSensitivityX;
            }
            //Debug.Log(new Vector2(Input.GetAxisRaw("Mouse X"),Input.GetAxisRaw("Mouse Y")) .ToString());
  
            //privcameraOffset.z -= Input.GetAxis("Mouse ScrollWheel")* Time.fixedDeltaTime * 30 ;
            pivot.localPosition = new Vector3(privcameraOffset.x, privcameraOffset.y, 0);
            
            pivot.localEulerAngles = new Vector3(cameraXRotation, pivot.localEulerAngles.y, 0);
            //cam.transform.position = pivot.TransformPoint(Vector3.forward * -(privcameraOffset.z - distanceOffset));
            //cam.transform.LookAt(pivot);
            //cam.transform.rotation = pivot.rotation;
        }

        void CameraCollision() 
        {
            Vector3 pivPos = pivot.position;
            float _distance = cameraOffset.z;
            RaycastHit _hit;

            if (Physics.Raycast(pivPos, pivot.forward * -1, out _hit, (_distance + 0.5f)))
                {
                Debug.DrawLine(pivPos, _hit.point);
                //Debug.Log(pivPos);
                distanceOffset = cameraOffset.z - _hit.distance + 0.8f;
                distanceOffset = Mathf.Clamp(distanceOffset, 0, cameraOffset.z);

            }
            else {
                distanceOffset = 0;
            }
        }

        void CameraZoom(bool zoom)
        {

            if (zoom)
            {
                privcameraOffset = Vector3.Lerp(privcameraOffset, cameraZoomOffset, Time.deltaTime * cameraZoomSpeed);
                Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, minFOV , Time.deltaTime * cameraZoomSpeed);
            }
            if (!zoom)
            {
                privcameraOffset = Vector3.Lerp(privcameraOffset, cameraOffset, Time.deltaTime * cameraZoomSpeed);
                Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, maxFOV , Time.deltaTime * cameraZoomSpeed);
            }
        }
        public void CameraPunch()
        {
            iTween.PunchPosition(Camera.main.gameObject, Vector3.one, 1);
        }
    }
}

