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
        private float sprintSpeed = 10f;
        [SerializeField]
        private float jumpPower = 5f;
        [SerializeField]
        private float looksens;
        [SerializeField]
        private float groundCheckDistance = 1f;

        private bool isGrounded = true;

        private PlayerCameraController pcc;
        private Rigidbody rb;

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
            CheckGround();
            Jump();
        }
        void FixedUpdate()
        {
            Movement();
            Turning();
        }

        void CheckGround()
        {
            isGrounded = false;
            Ray ray = new Ray(transform.position, transform.up * -1);
            if (Physics.Raycast(ray, groundCheckDistance)) isGrounded = true;
            
            //Debug.DrawLine(transform.position, transform.position + transform.up * -groundCheckDistance);
        }
        void Movement()
        {
            Vector3 _forward = Input.GetAxisRaw("Vertical") * transform.forward;
            Vector3 _right = Input.GetAxisRaw("Horizontal") * transform.right;
            Vector3 _movement = (_forward + _right).normalized * ( Input.GetButton("Sprint") ? sprintSpeed : movementSpeed );
            rb.MovePosition(transform.position + _movement * Time.fixedDeltaTime);
        }
        void Jump()
        {
            if(Input.GetButtonDown("Jump") && isGrounded) rb.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
        }

        void Turning()
        {
            float _rotationY = Input.GetAxisRaw("Mouse X");
            transform.Rotate(new Vector3(0, _rotationY * looksens, 0));
        }
    }
}

