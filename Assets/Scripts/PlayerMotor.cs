using UnityEngine;
using System.Collections;


namespace Werecat
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(PlayerCameraController))]
    public class PlayerMotor : MonoBehaviour
    {

        [SerializeField]
        private float movementSpeed = 5f;
        [SerializeField]
        private float jumpPower = 5f;
        private float looksens;


        private PlayerCameraController pcc;
        private Rigidbody rb;
        //comment added testing git
        //public Vector3 pivot = Vector3.zero;
        #region Inputs
        private float forwardScale;
        private float rightScale;
        #endregion

        // Use this for initialization
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            pcc = GetComponent<PlayerCameraController>();
            looksens = pcc.LookSensitivity;
        }

        // Update is called once per frame
        void Update()
        {
            UpdateInput();
        }
        void FixedUpdate()
        {

            Movement();
            Turning();

        }

        void LateUpdate()
        {
        }
        void UpdateInput()
        {
            forwardScale = Input.GetAxisRaw("Vertical");
            rightScale = Input.GetAxisRaw("Horizontal");
        }
        void Movement()
        {
            Vector3 _forward = forwardScale * transform.forward;
            Vector3 _right = rightScale * transform.right;
            Vector3 _movement = (_forward + _right).normalized * movementSpeed;

            rb.MovePosition(transform.position + _movement * Time.fixedDeltaTime);
        }

        void Turning()
        {
            float _rotationY = Input.GetAxisRaw("Mouse X");
            transform.Rotate(new Vector3(0, _rotationY * looksens, 0));
        }
    }
}

